// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.AnalyticsMiddleTier.Common;
using System.Data;

namespace EdFi.AnalyticsMiddleTier.Tests
{
    public interface ITestHarnessBase
    {
        Engine DataStandardEngine { get; }
        IOrm Orm { get; }
        string DataStandardVersionFolderName { get; }
        string DataStandardBaseVersionFolderName { get; }
        string TestDataFolderName { get; }
        (bool success, string errorMessage) Install(int timeoutSeconds = 30, params Component[] components);
        (bool success, string errorMessage) LoadTestCaseData<T>(string testCaseFile);
        IDbConnection OpenConnection();
        void PrepareDatabase();
        (bool success, string errorMessage) RunTestCase<T>(string testCaseFile);
    }
}
