// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using EdFi.AnalyticsMiddleTier.Common;

namespace EdFi.AnalyticsMiddleTier.Tests.DataStandardConfiguration
{
    public abstract class DatabaseConnection : IDatabaseConnection
    {
        private DbConnectionStringParameters _dbConnectionStringParam;

        public abstract IOrm Orm { get; }

        public abstract IDatabaseMigrationStrategy DatabaseMigrationStrategy { get; }

        public abstract IUninstallStrategy UninstallStrategy { get; }

        protected abstract string DefaultDatabaseNamePrefix { get; }

        protected abstract string EnvParameterDataBaseNamePrefix { get; }

        public string DatabaseName =>
            DbConnectionStringParameter.UseDefaultConnectionString
                ? DbConnectionStringParameter.DefaultDataBaseName
                : GetEnvironmentVariable(DbConnectionStringParameter.EnvParameterDataBaseName);

        public abstract string MainDatabaseConnectionString { get; }

        public abstract string ConnectionString { get; }

        protected DbConnectionStringParameters DbConnectionStringParameter
            => _dbConnectionStringParam ??= new DbConnectionStringParameters(DefaultDatabaseNamePrefix, EnvParameterDataBaseNamePrefix);

        private readonly DotEnvHelper _dotEnvHelper;

        protected DatabaseConnection(string versionFileSuffix)
        {
            _dotEnvHelper = new DotEnvHelper();
            DbConnectionStringParameter.DatabaseVersionSuffix = versionFileSuffix;
        }

        protected string GetEnvironmentVariable(string key)
            => ((Environment.GetEnvironmentVariable("GA_USE_GITHUB_ENV", EnvironmentVariableTarget.Process) ?? "false").ToLower().Equals("true"))
                ? Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.Process) ?? string.Empty
                : _dotEnvHelper.Value(key) ?? string.Empty;

        protected bool UseEnvironmentConnectionString(string key)
        {
            string useDefaultConnectionString = GetEnvironmentVariable(key).ToLower();
            return String.IsNullOrWhiteSpace(useDefaultConnectionString) || useDefaultConnectionString == "true";
        }

        protected class DbConnectionStringParameters
        {
            public bool UseDefaultConnectionString { get; set; }

            public string Server { get; set; }

            public string IntegratedSecurity { get; set; }

            public string User { get; set; }

            public string Pass { get; set; }

            public string AdminUser { get; set; }

            public string AdminUserPass { get; set; }

            public string Port { get; set; }

            public string Pooling { get; set; }

            public string DatabaseVersionSuffix { get; set; }

            public string DefaultDatabaseNamePrefix { get; }

            public string EnvParameterDataBaseNamePrefix { get; }

            public string DefaultDataBaseName => $"{DefaultDatabaseNamePrefix}{DatabaseVersionSuffix}";

            public string EnvParameterDataBaseName => $"{EnvParameterDataBaseNamePrefix}{DatabaseVersionSuffix.ToUpper()}";

            public DbConnectionStringParameters(string defaultDatabaseNamePrefix, string envParameterDataBaseNamePrefix)
            {
                DefaultDatabaseNamePrefix = defaultDatabaseNamePrefix;
                EnvParameterDataBaseNamePrefix = envParameterDataBaseNamePrefix;
            }
        }
    }
}
