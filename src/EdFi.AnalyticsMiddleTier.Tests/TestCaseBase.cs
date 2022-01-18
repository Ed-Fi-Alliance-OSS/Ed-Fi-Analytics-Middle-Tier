// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Tests.DataStandardConfiguration;
using NUnit.Framework;

namespace EdFi.AnalyticsMiddleTier.Tests
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [NonParallelizable]
    [TestFixtureSource(typeof(DataStandardTestFixture))]
    [Category("IntegrationTest")]
    public abstract class TestCaseBase
    {
        protected ITestHarnessBase DataStandard { get; set; }
        protected IDataStandardTestFixtureBase fixtureList { get; set; }
        protected (bool success, string errorMessage) Result { get; set; }

        protected TestCaseBase() => fixtureList = new DataStandardTestFixture();

        protected void SetDataStandard(ITestHarnessBase dataStandard) => this.DataStandard = dataStandard;

        protected void PrepareTestDatabase()
        {
            foreach (var dataStandard in fixtureList.GetFixturesList())
            {
                dataStandard.PrepareDatabase();
            }
        }

        [TestFixtureSource(typeof(DataStandardTestFixturePostgres))]
        public class TestCasePostgreSQL : TestCaseBase
        {
            protected TestCasePostgreSQL() => fixtureList = new DataStandardTestFixturePostgres();
        }
    }
}
