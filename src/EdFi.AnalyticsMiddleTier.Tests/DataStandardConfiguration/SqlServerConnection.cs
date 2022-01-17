﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using EdFi.AnalyticsMiddleTier.Common;
// ReSharper disable StringLiteralTypo

namespace EdFi.AnalyticsMiddleTier.Tests.DataStandardConfiguration
{
    public class SqlServerConnection : DatabaseConnection
    {
        protected override string DefaultDatabaseNamePrefix => "AnalyticsMiddleTier_Testing_Ds";

        protected override string EnvParameterDataBaseNamePrefix => "SQLSERVER_DATABASE_DS";

        public SqlServerConnection(string versionFileSuffix) : base(versionFileSuffix)
        {
            Initialize();
        }
        private void Initialize()
        {
            UseDefaultConnectionString = UseEnvironmentConnectionString("USE_MSSQL_DEFAULT_CONN_STRING");

            Server = GetEnvironmentVariable("SQLSERVER_SERVER");

            IntegratedSecurity = GetEnvironmentVariable("SQLSERVER_INTEGRATED_SECURITY");

            User = GetEnvironmentVariable("SQLSERVER_USER");

            Pass = GetEnvironmentVariable("SQLSERVER_PASS");

            AdminUser = GetEnvironmentVariable("SQLSERVER_ADMIN_USER") ?? "sa";

            AdminUserPass = GetEnvironmentVariable("SQLSERVER_ADMIN_PASS");
        }

        public override string MainDatabaseConnectionString
            => String.Format(GetConnectionStringFormat(), Server, "master", IntegratedSecurity, AdminUser, AdminUserPass);

        public override string ConnectionString
            => String.Format(GetConnectionStringFormat(), Server, DatabaseName, IntegratedSecurity, User, Pass);

        public override IOrm Orm => new DapperWrapper(new SqlConnection(ConnectionString));

        public override IDatabaseMigrationStrategy DatabaseMigrationStrategy => new SqlServerMigrationStrategy(Orm);

        public override IUninstallStrategy UninstallStrategy => new SqlServerUninstallStrategy(Orm);

        private string GetConnectionStringFormat()
        {
            var integratedSecurityList = new List<string> { "true", "sspi" };
            bool useIntegratedSecurity = integratedSecurityList
                .Any(s => IntegratedSecurity.ToLower().Contains(s));

            if (UseDefaultConnectionString)
            {
                return "server=localhost;database={1};integrated security=sspi";
            }
            else if (useIntegratedSecurity)
            {
                return "server={0};database={1};integrated security={2};";
            }
            else
            {
                return "server={0};database={1};User={3};Password={4}";
            }
        }
    }
}
