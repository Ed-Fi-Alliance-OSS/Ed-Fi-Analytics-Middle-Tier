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
        protected void PrepareTestData<T>(string testCaseFolder, string xmlLoadFile) =>
            PrepareTestData<T>(testCaseFolder, xmlLoadFile, false, null);

        protected void PrepareTestData<T>(string testCaseFolder, string xmlLoadFile, params Component[] components) =>
            PrepareTestData<T>(testCaseFolder, xmlLoadFile, false, components);

        protected void PrepareTestData<T>(string testCaseFolder, string xmlLoadFile, bool useCurrentDataStandard) =>
            PrepareTestData<T>(testCaseFolder, xmlLoadFile, useCurrentDataStandard, null);

        protected void PrepareTestData<T>(string testCaseFolder, string xmlLoadFile, bool useCurrentDataStandard,
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
                    $"{testCaseFolder}.{currentDataStandard.GetTestDataFolderName(useCurrentDataStandard)}.{xmlLoadFile}";

                currentDataStandard.PrepareDatabase();
                Result = currentDataStandard.LoadTestCaseData<T>(xmlLoadFilePath);
                Result.success.ShouldBeTrue($"Error while loading data: '{Result.errorMessage}'");
                if (components == null || components.Length == 0)
                {
                    Result = currentDataStandard.Install(10);
                }
                else
                {
                    Result = currentDataStandard.Install(10, components);
                }

                Result.success.ShouldBeTrue($"Error while installing Base: '{Result.errorMessage}'");
            }
        }
    }
}

