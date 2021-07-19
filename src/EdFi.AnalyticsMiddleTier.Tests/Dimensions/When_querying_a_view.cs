// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [TestFixtureSource(nameof(FixtureDataProvider))]
    public abstract class When_querying_a_view
    {
        protected TestHarnessBase DataStandard { get; set; }

        protected static ITestHarnessBase[] FixtureDataProvider()
        {
            return new ITestHarnessBase[] { TestHarnessSQLServer.DataStandard2, TestHarnessSQLServer.DataStandard31, TestHarnessSQLServer.DataStandard32 };
        }

        protected void SetDataStandard(TestHarnessBase dataStandard)
        {
            this.DataStandard = dataStandard;
        }
    }

}
