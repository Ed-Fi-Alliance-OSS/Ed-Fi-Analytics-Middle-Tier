// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Tests.Common;
using NUnit.Framework;

namespace EdFi.AnalyticsMiddleTier.Tests
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [NonParallelizable]
    [TestFixtureSource(typeof(DataStandardTestFixture))]
    public abstract class TestCaseBase
    {
        protected TestHarnessBase DataStandard { get; set; }
        protected IDataStandardTestFixtureBase fixtureList { get; set; }
        protected (bool success, string errorMessage) Result { get; set; }

        protected TestCaseBase() => fixtureList = new DataStandardTestFixture();

        protected void SetDataStandard(TestHarnessBase dataStandard) => this.DataStandard = dataStandard;

        protected ITestHarnessBase[] GetFixturesList() => fixtureList.GetFixturesList();

        protected void PrepareTestDatabase()
        {
            foreach (var dataStandard in fixtureList.GetFixturesList())
            {
                ITestHarnessBase currentDataStandard;
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

        [TestFixtureSource(typeof(DataStandardTestFixturePostgres))]
        public abstract class TestCasePostgreSQL : TestCaseBase
        {
            protected TestCasePostgreSQL() => fixtureList = new DataStandardTestFixturePostgres();
        }
    }
}
