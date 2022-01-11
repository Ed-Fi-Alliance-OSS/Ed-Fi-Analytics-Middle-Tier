// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System.Collections.Generic;
using EdFi.AnalyticsMiddleTier.Common;

namespace EdFi.AnalyticsMiddleTier.Tests
{
    public class PostgresConnectionString : DatabaseConnectionString {

        public PostgresConnectionString(DataStandard dataStandard)
        {
            DatabaseDataStandard = dataStandard;
            DefaultDataBaseName = new Dictionary<DataStandard, string>()
            {
                { DataStandard.Ds32, "edfi_ods_tests_ds32" },
                { DataStandard.Ds33, "edfi_ods_tests_ds33" }
            };
            ParameterDataBaseName = new Dictionary<DataStandard, string>()
            {
                { DataStandard.Ds32, "POSTGRES_DATABASE_DS32" },
                { DataStandard.Ds33, "POSTGRES_DATABASE_DS33" }
            };
            Initialize();
        }
        private void Initialize()
        {
            DatabaseEngine = Engine.PostgreSQL;

            UseDefaultConnectionString = UseEnvironmentConnectionString("USE_POSTGRES_DEFAULT_CONN_STRING");

            Server = GetEnvironmentVariable("POSTGRES_HOST");

            Port = GetEnvironmentVariable("POSTGRES_PORT");

            Pooling = GetEnvironmentVariable("POSTGRES_POOLING");

            User = GetEnvironmentVariable("POSTGRES_USER");

            Pass = GetEnvironmentVariable("POSTGRES_PASS");
        }            
    
        public override string GetDatabaseConnectionString() {
            if (UseDefaultConnectionString)
            {
                return $"User ID=postgres;Host=localhost;Port=5432;Database={DatabaseName};Pooling=false";
            }
            else
            {
                return $"User ID={User};Host={Server};Port={Port};Database={DatabaseName};Pooling={Pooling};password={Pass}";
            }
        }
    }
}
