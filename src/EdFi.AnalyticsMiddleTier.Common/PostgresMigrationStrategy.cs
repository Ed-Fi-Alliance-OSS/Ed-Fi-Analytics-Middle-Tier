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
        protected IOrm Orm { get; set; }
        public PostgresMigrationStrategy(IOrm orm)
        {
            Orm = orm ?? throw new ArgumentNullException(nameof(orm), "ORM cannot be null");
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

        public DataStandard GetDataStandardVersion() => DataStandard.Ds32;
    }
}
