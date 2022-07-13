// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Reflection;
using DbUp;
using DbUp.Engine;

namespace EdFi.AnalyticsMiddleTier.Common
{
    public class SqlServerMigrationStrategy : IDatabaseMigrationStrategy
    {
        public const string JournalingSchema = "dbo";
        public const string JournalingVersionsTable = "AnalyticsMiddleTierSchemaVersion";
        public const string DataStandardVersionTemplate =
            @"IF (SELECT OBJECT_ID('edfi.AddressType')) IS NOT NULL
             BEGIN
            	SELECT 'Ds2' AS version
             END
             ELSE IF (SELECT OBJECT_ID('dbo.VersionLevel')) IS NOT NULL
             BEGIN
            	SELECT 'Ds31' AS version
             END
			 ELSE IF (SELECT OBJECT_ID('edfi.Survey')) IS NOT NULL
             BEGIN
            	SELECT 'Ds33' AS version
             END
             ELSE IF (SELECT OBJECT_ID('dbo.DeployJournal'))  IS NOT NULL
             BEGIN
            	SELECT 'Ds32' AS version
             END
             ELSE
             BEGIN
            	SELECT 'InvalidDs' AS version
             END";

        private readonly IOrm _orm;
        public SqlServerMigrationStrategy(IOrm orm)
        {
            _orm = orm ?? throw new ArgumentNullException(nameof(orm), "ORM cannot be null");
        }
        public DatabaseUpgradeResult Migrate(Assembly assembly, string directoryName, string connectionString,
            int timeoutSeconds)
        {
            return DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(assembly, s => s.Contains($".{directoryName}.MSSQL"))
                .WithExecutionTimeout(TimeSpan.FromSeconds(timeoutSeconds))
                .JournalToSqlTable(JournalingSchema, JournalingVersionsTable)
                .WithTransaction()
                .LogToConsole()
                .Build()
                .PerformUpgrade();
        }



        public DataStandard GetDataStandardVersion()
        {
            var sql = DataStandardVersionTemplate;
            var result = _orm.ExecuteScalar<String>(sql);
            DataStandard dataStandardVersion = (DataStandard) Enum.Parse(typeof(DataStandard), result, true);
            return dataStandardVersion;
        }
    }
}
