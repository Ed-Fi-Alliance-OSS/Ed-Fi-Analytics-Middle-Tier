// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
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
