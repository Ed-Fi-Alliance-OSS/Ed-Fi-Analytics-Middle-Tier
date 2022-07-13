// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using Dapper;
using EdFi.AnalyticsMiddleTier.Common;
using EdFi.AnalyticsMiddleTier.Tests.DataStandardConfiguration;
using Microsoft.SqlServer.Dac;

namespace EdFi.AnalyticsMiddleTier.Tests
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class TestHarnessSqlServer : TestHarnessBase
    {
        private string _snapshotName => $"{_databaseName}_ss";

        public static TestHarnessSqlServer DataStandard2
            = new TestHarnessSqlServer(new SqlServerDataStandardSettings(DataStandard.Ds2));

        public static TestHarnessSqlServer DataStandard31
            = new TestHarnessSqlServer(new SqlServerDataStandardSettings(DataStandard.Ds31));

        public static TestHarnessSqlServer DataStandard32
            = new TestHarnessSqlServer(new SqlServerDataStandardSettings(DataStandard.Ds32));

        public static TestHarnessSqlServer DataStandard33
            = new TestHarnessSqlServer(new SqlServerDataStandardSettings(DataStandard.Ds33));

        protected TestHarnessSqlServer(IDataStandardSettings dataStandardSettings) : base(dataStandardSettings)
        {
        }

        public override void PrepareDatabase()
        {
            using (var connection = new SqlConnection(_mainDatabaseConnectionString))
            {
                if (NotUsingSnapshots())
                {
                    Console.WriteLine("Not using snapshots for Analytics Middle Tier integration testing");
                    DropSnapshotIfItExists();
                    LoadDacpac();
                }
                else
                {
                    if (TestDatabaseExists() && SnapshotExists())
                    {
                        ReloadFromSnapshotBackup();
                    }
                    else
                    {
                        LoadDacpac();
                        CreateSnapshot();
                    }
                }

                bool NotUsingSnapshots()
                {
                    const string analyticsMiddleTierNoSnapshots = "ANALYTICSMIDDLETIER_NO_SNAPSHOTS";

                    var noSnapshotsEnvVar = Environment.GetEnvironmentVariable(analyticsMiddleTierNoSnapshots)
                                                ?? "false";

                    if (bool.TryParse(noSnapshotsEnvVar, out bool avoidSnapshot))
                    {
                        return avoidSnapshot;
                    }

                    return false;
                }

                bool TestDatabaseExists()
                {
                    return connection.ExecuteScalar<int>(
                               $"SELECT 1 FROM sys.databases WHERE[name] = '{_databaseName}'") == 1;
                }

                bool SnapshotExists()
                {
                    return connection.ExecuteScalar<int>(
                               $"SELECT 1 FROM sys.databases WHERE [name] = '{_snapshotName}'") == 1;
                }

                void ReloadFromSnapshotBackup()
                {
                    connection.Execute($"ALTER DATABASE[{_databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                    connection.Execute($@"
                        IF EXISTS(SELECT 1 FROM sys.databases WHERE [name] = '{_snapshotName}')
                        BEGIN
                            RESTORE DATABASE {_databaseName} FROM DATABASE_SNAPSHOT = '{_snapshotName}'
                        END
                        ");
                    connection.Execute($"ALTER DATABASE [{_databaseName}] SET MULTI_USER");
                }

                void LoadDacpac()
                {
                    var dacService = new DacServices(_connectionString);
                    using (var dacpac = DacPackage.Load(GetDacFilePath()))
                    {
                        dacService.Deploy(dacpac, _databaseName, true, CreateDeployOptions());
                    }
                }

                DacDeployOptions CreateDeployOptions()
                {
                    return new DacDeployOptions
                    {
                        CreateNewDatabase = true
                    };
                }

                string GetDacFilePath()
                {
                    // ReSharper disable once AssignNullToNotNullAttribute
                    return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), _databaseBackupFile);
                }

                void CreateSnapshot()
                {
                    var defaultFilePathForSqlDbFiles = $@"
                        WITH pathname as (
                            SELECT [physical_name]
                            FROM [{_databaseName}].[sys].[database_files]
                            WHERE [type_desc] = 'ROWS'
                        )
                        SELECT REPLACE(REPLACE([physical_name], '{_databaseName}_Primary.mdf', ''),'{_databaseName}.mdf','') as FilePath
                        FROM pathname
                        ";
                    var filePath = connection.ExecuteScalar<string>(defaultFilePathForSqlDbFiles);

                    var createOrReplaceSnapshotTemplate = $@"
                        CREATE DATABASE {_snapshotName} ON
                          (Name = {_databaseName}, FileName = '{filePath}{_snapshotName}.ss')
                        AS SNAPSHOT OF {_databaseName}
                        ";
                    connection.Execute(createOrReplaceSnapshotTemplate);
                }

#pragma warning disable CS8321 // Local function is declared but never used
                void DropSnapshotIfItExists()
#pragma warning restore CS8321 // Local function is declared but never used
                {
                    // ReSharper disable once InvertIf - easier to read this way
                    if (SnapshotExists())
                    {
                        var dropSnapshotHistory =
                            $"EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'{_snapshotName}'";
                        connection.Execute(dropSnapshotHistory);

                        var dropSnapshot = $@"DROP DATABASE {_snapshotName}";
                        connection.Execute(dropSnapshot);
                    }
                }
            }
        }

        public override IDbConnection OpenConnection()
        {
            IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
