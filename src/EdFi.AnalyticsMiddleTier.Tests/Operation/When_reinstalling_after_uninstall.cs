// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Tests.Dimensions;
using NUnit.Framework;
using Shouldly;

namespace EdFi.AnalyticsMiddleTier.Tests.Operation
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [Parallelizable(ParallelScope.Children)]
    public class When_reinstalling_after_uninstall: When_querying_a_view_postgres
    {
        public When_reinstalling_after_uninstall(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            DataStandard.PrepareDatabase();

            Result = DataStandard.Install();
            Result.success.ShouldBe(true, "initial installation");

            Result = DataStandard.Uninstall();
            Result.success.ShouldBe(true, "uninstall");
        }

        [SetUp]
        public void Act()
        {
            Result = DataStandard.Install();
        }

        [Test]
        public void Then_result_success_should_be_true() => Result.success.ShouldBe(true);

        [Test]
        public void Then_error_message_should_be_null_or_empty() => Result.errorMessage.ShouldBeNullOrEmpty();

    }
}