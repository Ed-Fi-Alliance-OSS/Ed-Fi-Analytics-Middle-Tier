// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Common;
using EdFi.AnalyticsMiddleTier.Tests.Common;
using NUnit.Framework;
using Shouldly;

namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [TestFixtureSource(typeof(DataStandardTestFixture))]
    [Parallelizable(ParallelScope.Fixtures)]
    public abstract class When_querying_a_view : TestCaseBase
    {
        protected void PrepareTestData<T>(string testCaseFolder, string xmlLoadFile, DataStandard useCompatibleVersion) =>
            PrepareTestData<T>(testCaseFolder, xmlLoadFile, false, useCompatibleVersion, null);

        protected void PrepareTestData<T>(string testCaseFolder, string xmlLoadFile, DataStandard useCompatibleVersion, params Component[] components) =>
            PrepareTestData<T>(testCaseFolder, xmlLoadFile, false, useCompatibleVersion, components);

        protected void PrepareTestData<T>(string testCaseFolder, string xmlLoadFile, bool useCurrentDataStandard, DataStandard useCompatibleVersion) =>
            PrepareTestData<T>(testCaseFolder, xmlLoadFile, useCurrentDataStandard, useCompatibleVersion, null);

        protected void PrepareTestData<T>(string testCaseFolder, string xmlLoadFile, bool useCurrentDataStandard, DataStandard useCompatibleVersion,
            params Component[] components)
        {
            foreach (var dataStandard in fixtureList.GetFixturesList())
            {
                ITestHarnessBase currentDataStandard;
                if (dataStandard.GetType().ToString().Contains("TestHarnessSQLServer"))
                {
                    currentDataStandard = ((TestHarnessSQLServer) dataStandard);
                }
                else
                {
                    currentDataStandard = ((TestHarnessPostgres) dataStandard);
                }

                string xmlLoadFilePath =
                    $"{testCaseFolder}.{currentDataStandard.GetTestDataFolderName(useCurrentDataStandard, useCompatibleVersion)}.{xmlLoadFile}";

                currentDataStandard.PrepareDatabase();
                currentDataStandard.LoadTestCaseData<T>(xmlLoadFilePath);
                if (components == null || components.Length == 0)
                {
                    currentDataStandard.Install(10);
                }
                else
                {
                    currentDataStandard.Install(10, components);
                }
            }
        }
    }
}

