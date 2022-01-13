// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using EdFi.AnalyticsMiddleTier.Common;

namespace EdFi.AnalyticsMiddleTier.Tests.DataStandardConfiguration
{
    public abstract class DatabaseConnectionString : IDatabaseConnectionString
    {
        public abstract IOrm Orm { get; }

        public abstract IDatabaseMigrationStrategy DatabaseMigrationStrategy { get; }

        public abstract IUninstallStrategy UninstallStrategy { get; }

        public string DatabaseName =>
            UseDefaultConnectionString
                ? DefaultDataBaseName
                : GetEnvironmentVariable(EnvParameterDataBaseName);

        public DataStandard DatabaseDataStandard { get; protected set;}

        public abstract string MainDatabaseConnectionString { get; }

        public abstract string ConnectionString { get; }

        protected bool UseDefaultConnectionString { get; set; }

        protected string Server { get; set; }
                
        protected string IntegratedSecurity { get; set; }

        protected string User { get; set; }

        protected string Pass { get; set; }

        protected string AdminUser { get; set; }

        protected string AdminUserPass { get; set; }

        protected string Port { get; set; }

        protected string Pooling { get; set; }

        protected string DatabaseVersionSuffix { get; set; }

        protected abstract string DefaultDatabaseNamePrefix { get; }

        protected abstract string EnvParameterDataBaseNamePrefix { get; }

        protected string DefaultDataBaseName => $"{DefaultDatabaseNamePrefix}{DatabaseVersionSuffix}";

        protected string EnvParameterDataBaseName => $"{EnvParameterDataBaseNamePrefix}{DatabaseVersionSuffix.ToUpper()}";

        private readonly DotEnvHelper _dotEnvHelper;

        protected DatabaseConnectionString(string versionFileSuffix)
        {
            _dotEnvHelper = new DotEnvHelper();
            DatabaseVersionSuffix = versionFileSuffix;
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
    }
}