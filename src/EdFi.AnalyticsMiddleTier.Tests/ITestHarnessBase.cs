// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.AnalyticsMiddleTier.Common;
using System;
using System.Data;

namespace EdFi.AnalyticsMiddleTier.Tests
{
    public interface ITestHarnessBase
    {
        DataStandard DataStandardVersion { get; set; }
        Func<string, int, Component[], (bool success, string errorMessage)> InstallDelegate { get; set; }
        IOrm Orm { get; set; }

        void ExecuteQuery(string sqlCommand); 
        T ExecuteScalarQuery<T>(string sqlCommand);
        (bool success, string errorMessage) Install(int timeoutSeconds = 30, params Component[] components);
        (bool success, string errorMessage) LoadTestCaseData<T>(string testCaseFile);
        string GetTestDataFolderName { get; }
        IDbConnection OpenConnection();
        void PrepareDatabase();
        (bool success, string errorMessage) RunTestCase<T>(string testCaseFile);
        bool ScalarFunctionExists(string scalarFunctionName);
        bool ScalarFunctionExists(string scalarFunctionName, string schema);
        bool TableExists(string tableName);
        bool TableExists(string schemaName, string tableName);
        string ToString();
        (bool success, string errorMessage) Uninstall();
        (bool success, string errorMessage) Uninstall(bool uninstallAll);
        bool ViewExists(string viewName);
        bool ViewExists(string viewName, string schema);
    }
}
