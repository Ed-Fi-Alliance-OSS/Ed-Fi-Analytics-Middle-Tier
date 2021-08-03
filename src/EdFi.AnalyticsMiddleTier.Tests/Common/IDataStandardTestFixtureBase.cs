using System.Collections;

namespace EdFi.AnalyticsMiddleTier.Tests.Common
{
    public interface IDataStandardTestFixtureBase : IEnumerable
    {
        ITestHarnessBase[] GetFixturesList();
    }
}