// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Common;
using EdFi.AnalyticsMiddleTier.Tests.Dimensions;
using NUnit.Framework;
using Shouldly;

namespace EdFi.AnalyticsMiddleTier.Tests.Operation.CollectionViews
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SetUpFixture]
    public class CollectionViews : When_querying_a_view
    {
        [OneTimeSetUp]
        public void PrepareDatabase() => PrepareTestDatabase();
    }
}