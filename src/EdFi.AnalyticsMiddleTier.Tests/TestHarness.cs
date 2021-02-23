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
using Npgsql;

namespace EdFi.AnalyticsMiddleTier.Tests
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class TestHarness
    {
        public static TestHarness DataStandard2 = new TestHarness
        {
            _dataStandardVersionName = "2",
            _databaseName = "AnalyticsMiddleTier_Testing_Ds2",
            _dacpacName = "EdFi_Ods_2.0.dacpac",
            _dataStandardInstallType = typeof(Install),
            DataStandardVersion = DataStandard.Ds2
        };

        public static TestHarness DataStandard31 = new TestHarness
        {
            _dataStandardVersionName = "3_1",
            _dataStandardFolderName = "3_1",
            _databaseName = "AnalyticsMiddleTier_Testing_Ds31",
            _dacpacName = "EdFi_Ods_3.1.dacpac",
            _dataStandardInstallType = typeof(DataStandard31.Install),
            DataStandardVersion = DataStandard.Ds31
        };

        public static TestHarness DataStandard32 = new TestHarness
        {
            _dataStandardVersionName = "3_2",
            _dataStandardFolderName = "3_1",
            _databaseName = "AnalyticsMiddleTier_Testing_Ds32",
            _dacpacName = "EdFi_Ods_3.2.dacpac",
            _engine = Engine.MSSQL,
            _dataStandardInstallType = typeof(DataStandard32.Install),
            DataStandardVersion = DataStandard.Ds32
        };

        private string _dacpacName;

        private IDatabaseMigrationStrategy _databaseMigrationStrategy;

        private string _databaseName;

        private string _dataStandardFolderName;

        private InstallBase _dataStandardInstallBase;

        private Type _dataStandardInstallType;

        private string _dataStandardVersionName;

        private Engine _engine = Engine.Default;

        private Func<string, int, Component[], (bool success, string errorMessage)> _installDelegate;

        private IUninstallStrategy _uninstallStrategy;

        private TestHarness()
        {
            // private so that this class cannot be instantiated elsewhere
        }

        private string _connectionString => $"server=RUBEN-PC\\MSSQLSERVER19;database={_databaseName};integrated security=sspi";

        private string _snapshotName => $"{_databaseName}_ss";

        private IOrm _orm { get; set; }

        public DataStandard DataStandardVersion { get; set; }

        protected IOrm Orm
        {
            get
            {
                if (_orm == null)
                {
                    if (_engine == Engine.PostgreSQL)
                    {
                        _orm = new DapperWrapper(new NpgsqlConnection(_connectionString));
                    }
                    else
                    {
                        _orm = new DapperWrapper(new SqlConnection(_connectionString));
                    }
                }

                return _orm;
            }
            set => _orm = value;
        }

        protected IDatabaseMigrationStrategy DatabaseMigrationStrategy
        {
            get
            {
                if (_databaseMigrationStrategy == null)
                {
                    if (_engine == Engine.PostgreSQL)
                    {
                        _databaseMigrationStrategy = new PostgresMigrationStrategy(Orm);
                    }
                    else
                    {
                        _databaseMigrationStrategy = new SqlServerMigrationStrategy(Orm);
                    }
                }

                return _databaseMigrationStrategy;
            }
            set => _databaseMigrationStrategy = value;
        }

        protected IUninstallStrategy UninstallStrategy
        {
            get
            {
                if (_uninstallStrategy == null)
                {
                    if (_engine == Engine.PostgreSQL)
                    {
                        _uninstallStrategy = new PostgresUninstallStrategy(Orm);
                    }
                    else
                    {
                        _uninstallStrategy = new SqlServerUninstallStrategy(Orm);
                    }
                }

                return _uninstallStrategy;
            }
            set => _uninstallStrategy = value;
        }

        protected InstallBase DataStandardInstallBase
        {
            get
            {
                _dataStandardInstallBase ??= (InstallBase)Activator.CreateInstance(_dataStandardInstallType,
                    DatabaseMigrationStrategy);
                return _dataStandardInstallBase;
            }
            set => _dataStandardInstallBase = value;
        }

        public string DataStandardFolderName => string.IsNullOrWhiteSpace(_dataStandardFolderName)
            ? ToString()
            : "v_" + _dataStandardFolderName;

        public string CurrentDataStandardFolderName => string.IsNullOrWhiteSpace(_dataStandardFolderName)
            ? ToString()
            : "v_" + _dataStandardVersionName;

        public Func<string, int, Component[], (bool success, string errorMessage)> InstallDelegate
        {
            get
            {
                _installDelegate ??= DataStandardInstallBase.Run;
                return _installDelegate;
            }
            set => _installDelegate = value;
        }

        public (bool success, string errorMessage) Install(int timeoutSeconds = 30, params Component[] components)
        {
            return InstallDelegate(_connectionString, timeoutSeconds, components);
        }

        public (bool success, string errorMessage) Uninstall()
        {
            return UninstallStrategy.Uninstall();
        }

        public T ExecuteScalarQuery<T>(string sqlCommand)
        {
            using (var connection = OpenConnection())
            {
                return connection.ExecuteScalar<T>(sqlCommand);
            }
        }

        public bool ViewExists(string viewName)
        {
            return ViewExists(viewName, "analytics");
        }

        public bool ViewExists(string viewName, string schema)
        {
            using (var connection = OpenConnection())
            {
                var sql =
                    $"select 1 from information_schema.views where table_schema = '{schema}' and table_name='{viewName}'";
                return connection.ExecuteScalar<int>(sql) == 1;
            }
        }

        public bool TableExists(string tableName)
        {
            return TableExists("analytics_config", tableName);
        }

        public bool TableExists(string schemaName, string tableName)
        {
            using (var connection = OpenConnection())
            {
                var sql =
                    $"select 1 from information_schema.tables where table_schema = '{schemaName}' and table_name='{tableName}'";
                return connection.ExecuteScalar<int>(sql) == 1;
            }
        }

        public void ExecuteQuery(string sqlCommand)
        {
            using (var connection = OpenConnection())
            {
                connection.Execute(sqlCommand);
            }
        }

        public void PrepareDatabase()
        {
            using (var connection = new SqlConnection(@"server=RUBEN-PC\MSSQLSERVER19;database=master;integrated security=sspi"))
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
SELECT REPLACE([physical_name], '{_databaseName}_Primary.mdf', '') as FilePath
FROM pathname
";
                    var filePath = connection.ExecuteScalar<string>(defaultFilePathForSqlDbFiles);
                    //var filePath = @"C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER19\MSSQL\DATA\";
                    var createOrReplaceSnapshotTemplate = $@"
CREATE DATABASE {_snapshotName} ON
  (Name = {_databaseName}, FileName = '{filePath}\{_snapshotName}.ss')
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

        public override string ToString()
        {
            return $"v_{_dataStandardVersionName}";
        }

        public (bool success, string errorMessage) RunTestCase<T>(string testCaseFile)
        {
            (bool success, string errorMessage) testCaseResult;
            var testCase = TestCaseSerializer.LoadTestCase<T>(testCaseFile);
            using (testCase.Connection = OpenConnection())
            {
                testCase.LoadControlData();
                testCaseResult = testCase.RunTestCase();
            }

            return testCaseResult;
        }

        public (bool success, string errorMessage) LoadTestCaseData<T>(string testCaseFile)
        {
            try
            {
                var testCase = TestCaseSerializer.LoadTestCase<T>(testCaseFile);
                using (testCase.Connection = OpenConnection())
                {
                    testCase.LoadControlData();
                    return (true, string.Empty);
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        private IDbConnection OpenConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();

            return connection;
        }
    }
}