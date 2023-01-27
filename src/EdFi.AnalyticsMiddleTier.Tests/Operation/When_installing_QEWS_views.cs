// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.AnalyticsMiddleTier.Common;
using NUnit.Framework;
using Shouldly;
using System.Diagnostics.CodeAnalysis;

// ReSharper disable once CheckNamespace
namespace EdFi.AnalyticsMiddleTier.Tests.Operation
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class When_installing_QEWS_views : When_installing_a_Collection
    {
        public When_installing_QEWS_views(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

        [SetUp]
        public void Act()
        {
            if (DataStandard.DataStandardEngine.Equals(Engine.MSSQL))
            {
                Result = DataStandard.Install(10, Component.Qews);
            }
            else
            {
                Assert.Ignore("Collection QEWS does not exist.");
            }
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
