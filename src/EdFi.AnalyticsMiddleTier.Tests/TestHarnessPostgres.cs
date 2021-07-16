// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using Dapper;
using EdFi.AnalyticsMiddleTier.Common;

namespace EdFi.AnalyticsMiddleTier.Tests
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class TestHarnessPostgres : TestHarnessBase, ITestHarnessBase
    {
        public static ITestHarnessBase DataStandard32PG = new TestHarnessPostgres
        {
            _dataStandardVersionName = "PG_3_2",
            _dataStandardFolderName = "PG_3_2",
            _databaseName = "odstest",
            _engine = Engine.PostgreSQL,
            _dataStandardInstallType = typeof(DataStandard32.Install),
            DataStandardVersion = DataStandard.Ds32
        };

        public override string _connectionString => 
            $"User ID=postgres;Password=gapUser123;Host=localhost;Port=5432;Database={_databaseName};Pooling=false;";

        public override void PrepareDatabase()
        {
            // For now I am assuming the ODS exists. So I just truncate all tables.
            using (var connection = OpenConnection())
            {
                var truncateAllTablesLine = connection.ExecuteScalar<string>(
                        @"SELECT 'TRUNCATE TABLE '
	                            || string_agg(format('%I.%I', schemaname, tablename), ', ')
	                            || ' CASCADE'
                            FROM pg_tables
                            WHERE tableowner = 'postgres' AND (schemaname = 'edfi' OR schemaname = 'analytics_config')");

                if (!string.IsNullOrEmpty(truncateAllTablesLine))
                    connection.Execute(truncateAllTablesLine);
            }
        }
    }
}