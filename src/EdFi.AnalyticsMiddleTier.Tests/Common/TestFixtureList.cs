using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EdFi.AnalyticsMiddleTier.Tests
{
    public abstract class TestFixtureListBase : ITestFixtureListBase
    {
        protected ITestHarnessBase[] fixturesList { get; set; }

        public IEnumerator GetEnumerator()
        {
            foreach (var fixture in fixturesList)
            {
                yield return new ITestHarnessBase[] { fixture };
            }
        }
        public ITestHarnessBase[] GetFixturesList()
        {
            return fixturesList;
        }
    }

    public class TestFixtureList : TestFixtureListBase
    {
        public TestFixtureList()
        {
            fixturesList = new ITestHarnessBase[] { TestHarnessSQLServer.DataStandard2, TestHarnessSQLServer.DataStandard31, TestHarnessSQLServer.DataStandard32 };
        }
    }

    public class TestFixtureListDs3 : TestFixtureListBase
    {
        public TestFixtureListDs3()
        {
            fixturesList = new ITestHarnessBase[] { TestHarnessSQLServer.DataStandard31, TestHarnessSQLServer.DataStandard32 };
        }
    }

    public class TestFixtureListPostgres : TestFixtureListBase
    {
        public TestFixtureListPostgres()
        {
            //fixturesList = new ITestHarnessBase[] { TestHarnessSQLServer.DataStandard2, TestHarnessSQLServer.DataStandard31, TestHarnessSQLServer.DataStandard32, TestHarnessPostgres.DataStandard32PG };
            fixturesList = new ITestHarnessBase[] { TestHarnessSQLServer.DataStandard2, TestHarnessSQLServer.DataStandard31, TestHarnessSQLServer.DataStandard32};
        }
    }

    public class TestFixtureListPostgresDs3 : TestFixtureListBase
    {
        public TestFixtureListPostgresDs3()
        {
            //fixturesList = new ITestHarnessBase[] { TestHarnessSQLServer.DataStandard31, TestHarnessSQLServer.DataStandard32, TestHarnessPostgres.DataStandard32PG };
            fixturesList = new ITestHarnessBase[] { TestHarnessSQLServer.DataStandard31, TestHarnessSQLServer.DataStandard32 };
        }
    }
}
