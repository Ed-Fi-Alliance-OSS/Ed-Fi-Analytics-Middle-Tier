// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Tests.DataStandardConfiguration;
using NUnit.Framework;

namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [TestFixtureSource(typeof(DataStandardTestFixtureDs3))]
    public abstract class When_querying_a_view_ds3 : When_querying_a_view
    {
        protected When_querying_a_view_ds3() => fixtureList = new DataStandardTestFixtureDs3();
    }
}
