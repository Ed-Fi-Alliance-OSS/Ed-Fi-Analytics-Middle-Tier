// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections;

namespace EdFi.AnalyticsMiddleTier.Tests.DataStandardConfiguration
{
    public abstract class DataStandardTestFixtureBase : IDataStandardTestFixtureBase
    {
        protected ITestHarnessBase[] FixtureList { get; set; }

        public IEnumerator GetEnumerator()
        {
            foreach (var fixture in FixtureList)
            {
                yield return new[] { fixture };
            }
        }
        public ITestHarnessBase[] GetFixturesList()
        {
            return FixtureList;
        }
    }

    public class DataStandardTestFixture : DataStandardTestFixtureBase
    {
        public DataStandardTestFixture()
        {
            FixtureList = new ITestHarnessBase[] { TestHarnessSqlServer.DataStandard2, TestHarnessSqlServer.DataStandard31, TestHarnessSqlServer.DataStandard32, TestHarnessSqlServer.DataStandard33 };
        }
    }

    public class DataStandardTestFixtureDs3 : DataStandardTestFixtureBase
    {
        public DataStandardTestFixtureDs3()
        {
            FixtureList = new ITestHarnessBase[] { TestHarnessSqlServer.DataStandard31, TestHarnessSqlServer.DataStandard32, TestHarnessSqlServer.DataStandard33 };
        }
    }

    public class DataStandardTestFixtureDs3_3 : DataStandardTestFixtureBase
    {
        public DataStandardTestFixtureDs3_3()
        {
            FixtureList = new ITestHarnessBase[] { TestHarnessSqlServer.DataStandard33, TestHarnessPostgres.DataStandard33PG };
        }
    }

    public class DataStandardTestFixturePostgres : DataStandardTestFixtureBase
    {
        public DataStandardTestFixturePostgres()
        {
            FixtureList = new ITestHarnessBase[] { TestHarnessSqlServer.DataStandard2, TestHarnessSqlServer.DataStandard31, TestHarnessSqlServer.DataStandard32, TestHarnessSqlServer.DataStandard33, TestHarnessPostgres.DataStandard32PG, TestHarnessPostgres.DataStandard33PG };
        }
    }

    public class DataStandardTestFixturePostgresDs3 : DataStandardTestFixtureBase
    {
        public DataStandardTestFixturePostgresDs3()
        {
            FixtureList = new ITestHarnessBase[] { TestHarnessSqlServer.DataStandard31, TestHarnessSqlServer.DataStandard32, TestHarnessSqlServer.DataStandard33, TestHarnessPostgres.DataStandard32PG, TestHarnessPostgres.DataStandard33PG };
        }
    }
}
