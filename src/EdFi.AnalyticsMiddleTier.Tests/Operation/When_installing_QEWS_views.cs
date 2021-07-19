// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.AnalyticsMiddleTier.Common;
using EdFi.AnalyticsMiddleTier.Tests.Dimensions;
using NUnit.Framework;
using Shouldly;

namespace EdFi.AnalyticsMiddleTier.Tests.Operation
{
    public class When_installing_QEWS_views : When_querying_a_view
    {
        public When_installing_QEWS_views(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            DataStandard.PrepareDatabase();
        }

        [SetUp]
        public void Act()
        {
            Result = DataStandard.Install(10, Component.Qews);
        }

        [OneTimeTearDown]
        public void UnLoadDatabase()
        {
            DataStandard.Uninstall();
        }

        [Test]
        public void Then_result_success_should_be_true() => Result.success.ShouldBe(true);

        [Test]
        public void Then_error_message_should_be_null_or_empty() => Result.errorMessage.ShouldBeNullOrEmpty();

        [Test]
        public void Then_should_create_analytics_view_qews_StudentIndicators() => DataStandard.ViewExists("qews_studentindicators").ShouldBe(true);

        [Test]
        public void Then_should_create_analytics_view_qews_StudentIndicatorsByGradingPeriod() => DataStandard.ViewExists("qews_studentindicatorsbygradingperiod").ShouldBe(true);

        [Test]
        public void Then_should_create_analytics_view_qews_StudentEnrolledSectionGrade() => DataStandard.ViewExists("qews_studentenrolledsectiongrade").ShouldBe(true);

        [Test]
        public void Then_should_create_analytics_view_qews_StudentEnrolledSectionGradeTrend() => DataStandard.ViewExists("qews_studentenrolledsectiongradetrend").ShouldBe(true);

        [Test]
        public void Then_should_create_analytics_view_qews_SchoolRiskTrend() => DataStandard.ViewExists("qews_schoolrisktrend").ShouldBe(true);

        [Test]
        public void Then_should_create_analytics_view_qews_StudentAttendanceTrend() => DataStandard.ViewExists("qews_studentattendancetrend").ShouldBe(true);

        [Test]
        public void Then_should_create_EWS_configuration_table() => DataStandard.TableExists("quicksightews").ShouldBe(true);

    }
}