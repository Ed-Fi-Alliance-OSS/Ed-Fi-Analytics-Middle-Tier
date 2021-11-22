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
            PrepareTestData<T>(testCaseFolder, xmlLoadFile, null);

        protected void PrepareTestData<T>(string testCaseFolder, string xmlLoadFile, params Component[] components)
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
                    $"{testCaseFolder}.{currentDataStandard.GetTestDataFolderName}.{xmlLoadFile}";

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

