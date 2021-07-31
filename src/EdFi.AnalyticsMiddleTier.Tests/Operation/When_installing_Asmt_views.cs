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
    [Parallelizable(ParallelScope.Children)]
    public class When_installing_Asmt_views : When_querying_a_view_postgres_ds3
    {
        public When_installing_Asmt_views(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

        [SetUp]
        public void Act()
        {
            Result = DataStandard.Install(10, Component.Asmt);
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

        [TestCase]
        public void Then_should_create_analytics_view_asmt_AssessmentFact() => DataStandard.ViewExists("asmt_assessmentfact").ShouldBe(true);

        [TestCase]
        public void Then_should_create_analytics_view_asmt_StudentAssessmentFact() => DataStandard.ViewExists("asmt_studentassessmentfact").ShouldBe(true);

    }
}