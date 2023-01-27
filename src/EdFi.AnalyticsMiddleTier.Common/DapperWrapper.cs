// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Dapper;

namespace EdFi.AnalyticsMiddleTier.Common
{
    [ExcludeFromCodeCoverage]
    public sealed class DapperWrapper : IOrm
    {
        private readonly IDbConnection _dbConnection;

        public DapperWrapper(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        }

        public int Execute(string statement)
        {
            return _dbConnection.Execute(statement);
        }

        public T ExecuteScalar<T>(string statement)
        {
            return _dbConnection.ExecuteScalar<T>(statement);
        }

        public IReadOnlyCollection<TEntity> Query<TEntity>(string statement)
            where TEntity : class
        {
            return new ReadOnlyCollection<TEntity>(_dbConnection.Query<TEntity>(statement).AsList());
        }

        public void Dispose()
        {
            _dbConnection?.Dispose();
        }
    }
}

