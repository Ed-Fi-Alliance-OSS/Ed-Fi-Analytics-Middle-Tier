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
        protected TestHarness DataStandard { get; set; }

        protected static TestHarness[] FixtureDataProvider()=>(new []{ TestHarness.DataStandard2, TestHarness.DataStandard31, TestHarness.DataStandard32, TestHarness.DataStandard32PG });

        protected void SetDataStandard(TestHarness dataStandard)
        {
            this.DataStandard = dataStandard;
        }
    }

}
