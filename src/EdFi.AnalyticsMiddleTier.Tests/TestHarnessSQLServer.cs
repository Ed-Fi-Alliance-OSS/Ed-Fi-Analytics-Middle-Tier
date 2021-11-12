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
using EdFi.AnalyticsMiddleTier.DataStandard2;
using Microsoft.SqlServer.Dac;

namespace EdFi.AnalyticsMiddleTier.Tests
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class TestHarnessSQLServer : TestHarnessBase
    {
        public TestHarnessSQLServer()
        {
            DataStandardEngine = Engine.MSSQL;
        }

        public static TestHarnessSQLServer DataStandard2 = new TestHarnessSQLServer
        {
            _dataStandardBaseVersion = "v_2",
            _dataStandardVersionName = "2",
            _databaseName = new SQLServerConnectionStringDS2().Database,
            _dacpacName = "EdFi_Ods_2.0.dacpac",
            _dataStandardInstallType = typeof(Install),
            DataStandardVersion = DataStandard.Ds2,
            _connectionString = new SQLServerConnectionStringDS2().ToString()
    };

        public static TestHarnessSQLServer DataStandard31 = new TestHarnessSQLServer
        {
            _dataStandardBaseVersion = "v_3",
            _dataStandardVersionName = "3_1",
            _dataStandardFolderName = "3_1",
            _databaseName = new SQLServerConnectionStringDS31().Database,
            _dacpacName = "EdFi_Ods_3.1.dacpac",
            _dataStandardInstallType = typeof(DataStandard31.Install),
            DataStandardVersion = DataStandard.Ds31,
            _connectionString = new SQLServerConnectionStringDS31().ToString()
        };

        public static TestHarnessSQLServer DataStandard32 = new TestHarnessSQLServer
        {
            _dataStandardBaseVersion = "v_3",
            _dataStandardVersionName = "3_2",
            _dataStandardFolderName = "3_1",
            _databaseName = new SQLServerConnectionStringDS32().Database,
            _dacpacName = "EdFi_Ods_3.2.dacpac",
            DataStandardEngine = Engine.MSSQL,
            _dataStandardInstallType = typeof(DataStandard32.Install),
            DataStandardVersion = DataStandard.Ds32,
            _connectionString = new SQLServerConnectionStringDS32().ToString()
        };

        private string _snapshotName => $"{_databaseName}_ss";

        private string _dacpacName;

        private string GetMasterConnectionString() {
            if ((Environment.GetEnvironmentVariable("GA_USE_GITHUB_ENV", EnvironmentVariableTarget.Process) ?? "false").ToLower().Equals("true"))
            {
                string saPassword = Environment.GetEnvironmentVariable("GA_SA_DB_PWD", EnvironmentVariableTarget.Process);
                return $"server=localhost;database=master;integrated security=false;User=sa;Password={saPassword}";
            }
            else {
                return "server=localhost;database=master;integrated security=sspi";
            }
        }

        public override void PrepareDatabase()
        {
            using (var connection = new SqlConnection(GetMasterConnectionString()))
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
                    //return true;
                    const string analyticsMiddleTierNoSnapshots = "ANALYTICSMIDDLETIER_NO_SNAPSHOTS";

                    var noSnapshotsEnvVar = Environment.GetEnvironmentVariable(analyticsMiddleTierNoSnapshots) ??
                                            "false";

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
                    return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), _dacpacName);
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