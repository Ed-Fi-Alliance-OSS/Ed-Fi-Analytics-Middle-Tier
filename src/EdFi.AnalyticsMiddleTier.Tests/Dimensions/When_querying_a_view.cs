// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Common;
using NUnit.Framework;
using Shouldly;

namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [TestFixtureSource(typeof(TestFixtureList))]
    [Parallelizable(ParallelScope.Fixtures)]
    public abstract class When_querying_a_view
    {
        protected TestHarnessBase DataStandard { get; set; }
        protected ITestFixtureListBase fixtureList { get; set; }
        protected (bool success, string errorMessage) Result { get; set; }

        public When_querying_a_view() => fixtureList = new TestFixtureList();
        
        protected void SetDataStandard(TestHarnessBase dataStandard) => this.DataStandard = dataStandard;

        protected ITestHarnessBase[] GetFixturesList() => fixtureList.GetFixturesList();

        protected void PrepareTestDatabase() {
            foreach (var dataStandard in fixtureList.GetFixturesList())
            {
                ITestHarnessBase currentDataStandard = dataStandard;
                if (dataStandard.GetType().ToString().Contains("TestHarnessSQLServer"))
                {
                    currentDataStandard = ((TestHarnessSQLServer)dataStandard);
                }
                else
                {
                    currentDataStandard = ((TestHarnessPostgres)dataStandard);
                }
                currentDataStandard.PrepareDatabase();
            }
        }

        protected void PrepareTestData<T>(string testCaseFolder, string xmlLoadFile) => PrepareTestData<T>(testCaseFolder, xmlLoadFile, false, null);

        protected void PrepareTestData<T>(string testCaseFolder, string xmlLoadFile, params Component[] components) => PrepareTestData<T>(testCaseFolder, xmlLoadFile, false, components);

        protected void PrepareTestData<T>(string testCaseFolder, string xmlLoadFile, bool useCurrentDataStandard) => PrepareTestData<T>(testCaseFolder, xmlLoadFile, useCurrentDataStandard, null);

        protected void PrepareTestData<T>(string testCaseFolder, string xmlLoadFile, bool useCurrentDataStandard, params Component[] components)
        {
            string xmlLoadFilePath = string.Empty;
            foreach (var dataStandard in fixtureList.GetFixturesList())
            {
                ITestHarnessBase currentDataStandard = dataStandard;
                if (dataStandard.GetType().ToString().Contains("TestHarnessSQLServer"))
                {
                    currentDataStandard = ((TestHarnessSQLServer)dataStandard);
                }
                else
                {
                    currentDataStandard = ((TestHarnessPostgres)dataStandard);
                }
                xmlLoadFilePath = $"{testCaseFolder}.{currentDataStandard.GetTestDataFolderName(useCurrentDataStandard)}.{xmlLoadFile}";
                       
                currentDataStandard.PrepareDatabase();
                Result = currentDataStandard.LoadTestCaseData<T>(xmlLoadFilePath);
                Result.success.ShouldBeTrue($"Error while loading data: '{Result.errorMessage}'");
                if (components == null || components.Length == 0)
                {
                    Result = currentDataStandard.Install(10);
                }
                else
                {
                    Result = currentDataStandard.Install(10,components);
                }
                Result.success.ShouldBeTrue($"Error while installing Base: '{Result.errorMessage}'");
            }
        }

    }
}
