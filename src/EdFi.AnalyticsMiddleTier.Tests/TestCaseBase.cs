// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace EdFi.AnalyticsMiddleTier.Tests
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [Parallelizable(ParallelScope.Fixtures)]
    public abstract class TestCaseBase
    {
        protected TestHarnessBase DataStandard { get; set; }

        protected TestCaseBase(TestHarnessBase dataStandard)
        {
            this.DataStandard = dataStandard;
        }
    }
}
