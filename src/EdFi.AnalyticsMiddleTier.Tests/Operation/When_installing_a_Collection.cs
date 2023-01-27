// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

// ReSharper disable once CheckNamespace
namespace EdFi.AnalyticsMiddleTier.Tests.Operation
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_installing_a_Collection : TestCaseBase.TestCasePostgreSQL
    {
    }

    [SetUpFixture]
    public class CollectionViews : When_installing_a_Collection
    {
        [OneTimeSetUp]
        public void PrepareDatabase() => PrepareTestDatabase();
    }
}
