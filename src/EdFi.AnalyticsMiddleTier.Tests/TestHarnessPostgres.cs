// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data;
using System.Diagnostics.CodeAnalysis;
using Dapper;
using EdFi.AnalyticsMiddleTier.Common;
using EdFi.AnalyticsMiddleTier.Tests.DataStandardConfiguration;
using Npgsql;

namespace EdFi.AnalyticsMiddleTier.Tests
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class TestHarnessPostgres : TestHarnessBase
    {
        public static TestHarnessPostgres DataStandard32PG
                = new TestHarnessPostgres(new PostgresDataStandardSettings(DataStandard.Ds32));

        public static TestHarnessPostgres DataStandard33PG
                = new TestHarnessPostgres(new PostgresDataStandardSettings(DataStandard.Ds33));

        protected TestHarnessPostgres(IDataStandardSettings dataStandardSettings) : base(dataStandardSettings)
        {
        }

        public override void PrepareDatabase()
        {
            Uninstall();

            // For now I am assuming the ODS exists. So I just truncate all tables.
            using (var connection = OpenConnection())
            {
                var truncateAllTablesLine = connection.ExecuteScalar<string>(
                        @"SELECT 'TRUNCATE TABLE ' || string_agg(format('%I.%I', schemaname, tablename), ', ') || ' CASCADE'
                            FROM pg_tables
                            WHERE tableowner = 'postgres'
	                            AND (
		                            schemaname = 'edfi'
		                            OR schemaname = 'analytics_config'
		                            OR schemaname = 'auth'
		                            OR schemaname = 'util'
                                    OR schemaname = 'tpdm'
		                            )");

                if (!string.IsNullOrEmpty(truncateAllTablesLine))
                {
                    connection.Execute(truncateAllTablesLine);
                }
            }
        }

        public override IDbConnection OpenConnection()
        {
            IDbConnection connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
