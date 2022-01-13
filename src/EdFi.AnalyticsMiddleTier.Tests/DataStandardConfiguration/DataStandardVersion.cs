using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using EdFi.AnalyticsMiddleTier.Common;

namespace EdFi.AnalyticsMiddleTier.Tests.DataStandardConfiguration
{
    public class DataStandardVersion
    {
        public Dictionary<DataStandard, (string version, Type typeInstall)> SupportedVersion
        {
            get
            {
                var versions = new Dictionary<DataStandard, (string version, Type typeInstall)>
                {
                    {DataStandard.Ds2, ("2", typeof(DataStandard2.Install))},
                    {DataStandard.Ds31, ("3.1", typeof(DataStandard31.Install))},
                    {DataStandard.Ds32, ("3.2", typeof(DataStandard32.Install))},
                    {DataStandard.Ds33, ("3.3", typeof(DataStandard33.Install))}
                };
                return versions;
            }
        }
    }
}
