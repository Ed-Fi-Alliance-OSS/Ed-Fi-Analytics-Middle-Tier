// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [TestFixtureSource(nameof(FixtureDataProviderDs3))]
    public abstract class When_querying_a_view_ds3 : When_querying_a_view
    {
        protected static TestHarness[] FixtureDataProviderDs3() => (new[] { TestHarness.DataStandard31, TestHarness.DataStandard32 });
    }
}