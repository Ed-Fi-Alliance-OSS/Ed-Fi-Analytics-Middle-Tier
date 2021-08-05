// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using Dapper;
using EdFi.AnalyticsMiddleTier.Common;
using Npgsql;

namespace EdFi.AnalyticsMiddleTier.Tests
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class TestHarnessBase : ITestHarnessBase
    {
        public Engine DataStandardEngine { get; set; } = Engine.Default;

        protected IDatabaseMigrationStrategy _databaseMigrationStrategy;

        protected string _databaseName;

        protected string _dataStandardFolderName;

        protected InstallBase _dataStandardInstallBase;

        protected Type _dataStandardInstallType;

        protected string _dataStandardVersionName;

        protected Func<string, int, Component[], (bool success, string errorMessage)> _installDelegate;

        protected IUninstallStrategy _uninstallStrategy;

        protected TestHarnessBase()
        {
            // private so that this class cannot be instantiated elsewhere
        }

        public virtual string _connectionString => string.Empty;

        protected IOrm _orm { get; set; }

        public DataStandard DataStandardVersion { get; set; }

        public IOrm Orm
        {
            get
            {
                if (_orm == null)
                {
                    _orm = DataStandardEngine == Engine.PostgreSQL 
                            ? new DapperWrapper(new NpgsqlConnection(_connectionString))
                            : _orm = new DapperWrapper(new SqlConnection(_connectionString));
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
                    if (DataStandardEngine == Engine.PostgreSQL)
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
                    if (DataStandardEngine == Engine.PostgreSQL)
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
            : $"{DataStandardEngine}.v_{_dataStandardFolderName}";

        public string CurrentDataStandardFolderName => string.IsNullOrWhiteSpace(_dataStandardFolderName)
            ? ToString()
            : $"{DataStandardEngine}.v_{_dataStandardVersionName}";

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

        public (bool success, string errorMessage) Uninstall(bool uninstallAll)
        {
            return UninstallStrategy.Uninstall(uninstallAll);
        }

        public string GetTestDataFolderName(bool useCurrentDataStandard)
            => useCurrentDataStandard
                ? $"{CurrentDataStandardFolderName}"
                : $"{DataStandardFolderName}" ;

  
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
            return TableExists(schema, viewName);
        }
        public bool TableExists(string tableName)
        {
            return TableExists("analytics_config", tableName);
        }

        public bool ScalarFunctionExists(string scalarFunctionName)
        {
            return ScalarFunctionExists(scalarFunctionName, "analytics");
        }

        public bool ScalarFunctionExists(string scalarFunctionName, string schema)
        {
            using (var connection = OpenConnection())
            {
                var sql =
                    $"select 1 from information_schema.ROUTINES where SPECIFIC_SCHEMA = '{schema}' and (SPECIFIC_NAME='{scalarFunctionName}' OR SPECIFIC_NAME='{scalarFunctionName.ToLower()}')";
                return connection.ExecuteScalar<int>(sql) == 1;
            }
        }

        public bool TableExists(string schemaName, string tableName)
        {
            using (var connection = OpenConnection())
            {
                var sql = $"select 1 from information_schema.tables where table_schema = '{schemaName.ToLower()}' and (table_name='{tableName.ToLower()}' OR table_name='{tableName}')";
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

        public virtual void PrepareDatabase()
        {

        }

        public override string ToString()
        {
            return $"{DataStandardEngine}.v_{_dataStandardVersionName}";
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

        public virtual IDbConnection OpenConnection()
        {
            throw new NotImplementedException();
        }
    }
}