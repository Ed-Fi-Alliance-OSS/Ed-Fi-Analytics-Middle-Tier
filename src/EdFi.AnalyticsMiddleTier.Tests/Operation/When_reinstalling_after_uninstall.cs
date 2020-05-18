// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using Shouldly;

namespace EdFi.AnalyticsMiddleTier.Tests.Operation
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_reinstalling_after_uninstall
    {
        protected abstract TestHarness _dataStandard { get; }

        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            _dataStandard.PrepareDatabase();

            Result = _dataStandard.Install();
            Result.success.ShouldBe(true, "initial installation");

            Result = _dataStandard.Uninstall();
            Result.success.ShouldBe(true, "uninstall");
        }

        [SetUp]
        public void Act()
        {
            Result = _dataStandard.Install();
        }

        [Test]
        public void Then_result_success_should_be_true() => Result.success.ShouldBe(true);

        [Test]
        public void Then_error_message_should_be_null_or_empty() => Result.errorMessage.ShouldBeNullOrEmpty();

        [TestFixture]
        public class Given_data_standard_two : When_reinstalling_after_uninstall
        {
            protected override TestHarness _dataStandard => TestHarness.DataStandard2;
        }
        [TestFixture]
        public class Given_data_standard_three_one : When_reinstalling_after_uninstall
        {
            protected override TestHarness _dataStandard => TestHarness.DataStandard31;
        }
        [TestFixture]
        public class Given_data_standard_three_two : When_reinstalling_after_uninstall
        {
            protected override TestHarness _dataStandard => TestHarness.DataStandard32;
        }
    }
}