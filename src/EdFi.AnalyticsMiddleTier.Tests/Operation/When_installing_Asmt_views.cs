// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Common;
using NUnit.Framework;
using Shouldly;

namespace EdFi.AnalyticsMiddleTier.Tests.Operation
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_installing_Asmt_views
    {
        protected abstract TestHarness _dataStandard { get; }

        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            _dataStandard.PrepareDatabase();
        }

        [SetUp]
        public void Act()
        {
            Result = _dataStandard.Install(10, Component.Asmt);
        }

        [Test]
        public void Then_result_success_should_be_true() => Result.success.ShouldBe(true);

        [Test]
        public void Then_error_message_should_be_null_or_empty() => Result.errorMessage.ShouldBeNullOrEmpty();

        [TestCase("asmt_AssessmentFact")]
        [TestCase("asmt_StudentAssessmentFact")]
        [TestCase("asmt_StudentAssessmentObjectiveFact")]
        public void Then_should_create_analytics_view(string viewName) => _dataStandard.ViewExists(viewName).ShouldBe(true);

        [TestFixture]
        public class Given_data_standard_three_one : When_installing_Asmt_views
        {
            protected override TestHarness _dataStandard => TestHarness.DataStandard31;
        }

        [TestFixture]
        public class Given_data_standard_three_two : When_installing_Asmt_views
        {
            protected override TestHarness _dataStandard => TestHarness.DataStandard32;
        }
    }
}