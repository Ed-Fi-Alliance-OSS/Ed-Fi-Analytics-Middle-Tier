// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;

namespace EdFi.AnalyticsMiddleTier.Common
{
    public interface IOrm : IDisposable
    {
        int Execute(string statement);

        T ExecuteScalar<T>(string statement);

        IReadOnlyCollection<TEntity> Query<TEntity>(string statement) where TEntity : class;
    }
}
