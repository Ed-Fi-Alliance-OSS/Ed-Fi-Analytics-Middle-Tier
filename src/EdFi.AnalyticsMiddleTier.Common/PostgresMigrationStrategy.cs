﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Reflection;
using DbUp;
using DbUp.Engine;

namespace EdFi.AnalyticsMiddleTier.Common
{
    public class PostgresMigrationStrategy : IDatabaseMigrationStrategy
    {
        public const string JournalingSchema = "";
        public const string JournalingVersionsTable = "AnalyticsMiddleTierSchemaVersion";
        public const string DataStandardVersionTemplate =
            @"SELECT CASE 
                WHEN EXISTS (
	                SELECT 1
	                FROM pg_proc p
	                    LEFT JOIN pg_catalog.pg_namespace n ON n.oid = p.pronamespace
	                WHERE proname = 'getedfiodsversion' and nspname = 'util'
                )
			THEN 
				util.getedfiodsversion()
			ELSE
				'NA'
			END AS DS";

        protected IOrm _orm { get; set; }
        public PostgresMigrationStrategy(IOrm orm)
        {
            _orm = orm ?? throw new ArgumentNullException(nameof(orm), "ORM cannot be null");
        }
        public DatabaseUpgradeResult Migrate(Assembly assembly, string directoryName, string connectionString,
            int timeoutSeconds)
        {
            return DeployChanges.To
                .PostgresqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(assembly, s => s.Contains($".{directoryName}.PostgreSQL"))
                .WithExecutionTimeout(TimeSpan.FromSeconds(timeoutSeconds))
                .JournalToPostgresqlTable(JournalingSchema, JournalingVersionsTable)
                .WithTransaction()
                .LogToConsole()
                .Build()
                .PerformUpgrade();
        }

        public DataStandard GetDataStandardVersion()
        {
            var sql = DataStandardVersionTemplate;
            var result = _orm.ExecuteScalar<String>(sql);
            if (result.Equals("5.3"))
                return DataStandard.Ds53;
            else
                return DataStandard.Ds32;
        }
    }
}
