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
    public abstract class When_querying_a_view_postgres : When_querying_a_view
    {
        protected static ITestHarnessBase[] FixtureDataProviderDs3()
        {
            return new ITestHarnessBase[] { TestHarnessSQLServer.DataStandard31, TestHarnessSQLServer.DataStandard32, TestHarnessPostgres.DataStandard32PG };
        }
    }
}