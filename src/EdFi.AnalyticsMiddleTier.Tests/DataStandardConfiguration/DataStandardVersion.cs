using System;
using System.Collections.Generic;
using EdFi.AnalyticsMiddleTier.Common;

namespace EdFi.AnalyticsMiddleTier.Tests.DataStandardConfiguration
{
    public class DataStandardVersion
    {
        public Dictionary<DataStandard, (string version, string minVersion, Type typeInstall)> SupportedVersion
        {
            get
            {
                var versions = new Dictionary<DataStandard, (string version, string minVersion, Type typeInstall)>
                {
                    {DataStandard.Ds2, ("2", String.Empty, typeof(DataStandard2.Install))},
                    {DataStandard.Ds31, ("3.1", String.Empty, typeof(DataStandard31.Install))},
                    {DataStandard.Ds32, ("3.2", String.Empty, typeof(DataStandard32.Install))},
                    {DataStandard.Ds33, ("3.3", String.Empty, typeof(DataStandard33.Install))},
                    {DataStandard.Ds40, ("4.0", "3", typeof(DataStandard40.Install))},
                    {DataStandard.Ds50, ("5.0", "3", typeof(DataStandard50.Install))}
                };
                return versions;
            }
        }
    }
}
