using System.Collections;

namespace EdFi.AnalyticsMiddleTier.Tests
{
    public interface ITestFixtureListBase : IEnumerable
    {
        ITestHarnessBase[] GetFixturesList();
    }
}