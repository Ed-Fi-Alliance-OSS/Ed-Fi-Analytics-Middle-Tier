// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Npgsql;
using System;

namespace EdFi.AnalyticsMiddleTier.Common
{
    public class NpgsqlConnectionStringValidator : IConnectionStringValidator
    {
        protected readonly string _connectionString;

        public NpgsqlConnectionStringValidator(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool IsConnectionStringValid(out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                NpgsqlConnectionStringBuilder connectionStringBuilder = new NpgsqlConnectionStringBuilder(_connectionString);

                if (string.IsNullOrWhiteSpace(connectionStringBuilder.Host))
                {
                    errorMessage = $"{Environment.NewLine}Please specify a data source using the Data Source or Server keyword.";
                }

                if (!connectionStringBuilder.IntegratedSecurity &&
                    (string.IsNullOrWhiteSpace(connectionStringBuilder.Username) ||
                     string.IsNullOrWhiteSpace(connectionStringBuilder.Password)))
                {
                    errorMessage =
                        $"{errorMessage}{Environment.NewLine}Please specify an authentication method using an integrated security or providing a user id and password.";
                }

                if (string.IsNullOrWhiteSpace(connectionStringBuilder.Database))
                {
                    errorMessage = $"{errorMessage}{Environment.NewLine}Please specify a database using the Database or Initial Catalog keyword.";
                }

                return errorMessage == string.Empty;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}
