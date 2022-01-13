// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.AnalyticsMiddleTier.Common;
using Npgsql;

namespace EdFi.AnalyticsMiddleTier.Tests.DataStandardConfiguration
{
    public class PostgresConnection : DatabaseConnection {
        protected override string DefaultDatabaseNamePrefix => "edfi_ods_tests_ds";

        protected override string EnvParameterDataBaseNamePrefix => "POSTGRES_DATABASE_DS";

        public PostgresConnection(string versionFileSuffix) : base(versionFileSuffix)
        {
            Initialize();
        }
        protected void Initialize()
        {
            UseDefaultConnectionString = UseEnvironmentConnectionString("USE_POSTGRES_DEFAULT_CONN_STRING");

            Server = GetEnvironmentVariable("POSTGRES_HOST");

            Port = GetEnvironmentVariable("POSTGRES_PORT");

            Pooling = GetEnvironmentVariable("POSTGRES_POOLING");

            User = GetEnvironmentVariable("POSTGRES_USER");

            Pass = GetEnvironmentVariable("POSTGRES_PASS");
        }            
    
        public override string ConnectionString
            => UseDefaultConnectionString
            ? $"User ID=postgres;Host=localhost;Port=5432;Database={DatabaseName};Pooling=false"
            : $"User ID={User};Host={Server};Port={Port};Database={DatabaseName};Pooling={Pooling};password={Pass}";

        public override string MainDatabaseConnectionString => string.Empty;

        public override IOrm Orm => new DapperWrapper(new NpgsqlConnection(ConnectionString));

        public override IDatabaseMigrationStrategy DatabaseMigrationStrategy => new PostgresMigrationStrategy(Orm);

        public override IUninstallStrategy UninstallStrategy => new PostgresUninstallStrategy(Orm);
    }
}
