// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.Collections.Generic;
using EdFi.AnalyticsMiddleTier.Common;

namespace EdFi.AnalyticsMiddleTier.Tests
{
    public abstract class DatabaseConnectionString : IDatabaseConnectionString
    {
        public string DatabaseName =>
            UseDefaultConnectionString
                ? DefaultDataBaseName[DatabaseDataStandard]
                : GetEnvironmentVariable(ParameterDataBaseName[DatabaseDataStandard]);

        public Engine DatabaseEngine { get; set; }

        public DataStandard DatabaseDataStandard { get; set; }

        protected bool UseDefaultConnectionString { get; set; }

        protected string Server { get; set; }
                
        protected string IntegratedSecurity { get; set; }

        protected string User { get; set; }

        protected string Pass { get; set; }

        protected string AdminUser { get; set; }

        protected string AdminUserPass { get; set; }

        protected string Port { get; set; }

        protected string Pooling { get; set; }
                
        protected Dictionary<DataStandard,string> DefaultDataBaseName { get; set; }

        protected Dictionary<DataStandard, string> ParameterDataBaseName { get; set; }

        private readonly DotEnvHelper _dotEnvHelper;

        public virtual string GetMainDatabaseConnectionString() => String.Empty;

        public virtual string GetDatabaseConnectionString() => String.Empty;

        protected DatabaseConnectionString()
        {
            _dotEnvHelper = new DotEnvHelper();
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
