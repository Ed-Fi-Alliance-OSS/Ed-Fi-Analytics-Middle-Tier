// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace EdFi.AnalyticsMiddleTier.Tests.Operation
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class When_reinstalling_after_uninstall : When_installing_a_Collection
    {
        public When_reinstalling_after_uninstall(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

        [SetUp]
        public void Act()
        {
            Result = DataStandard.Install();
            Result.success.ShouldBe(true, "initial installation");

            Result = DataStandard.Uninstall();
            Result.success.ShouldBe(true, "uninstall");

            Result = DataStandard.Install();
        }

        [OneTimeTearDown]
        public void Uninstall()
        {
            Result = DataStandard.Uninstall();
        }

        [Test]
        public void Then_result_success_should_be_true() => Result.success.ShouldBe(true);

        [Test]
        public void Then_error_message_should_be_null_or_empty() => Result.errorMessage.ShouldBeNullOrEmpty();

    }
}
