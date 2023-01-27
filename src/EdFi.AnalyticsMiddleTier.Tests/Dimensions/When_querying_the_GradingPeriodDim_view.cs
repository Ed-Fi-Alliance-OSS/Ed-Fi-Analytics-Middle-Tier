// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;
using CommonLib = EdFi.AnalyticsMiddleTier.Common;

// ReSharper disable once CheckNamespace
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.GradingPeriodDimTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_GradingPeriodDim_view : When_querying_a_view_postgres
    {
        protected const string TestCasesFolder = "TestCases.GradingPeriodDim";
        protected const string TestCasesDataFileName = "0000_GradingPeriodDim_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_GradingPeriodDim_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }
        [SetUpFixture]
        public class SetupGradingPeriodDimTestCase
            : When_querying_the_GradingPeriodDim_view
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<GradingPeriodDim>(TestCasesFolder, TestCasesDataFileName);
        }
        public class Given_grading_period_54_628530001_20110822
        : When_querying_the_GradingPeriodDim_view
        {
            public Given_grading_period_54_628530001_20110822(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "54_628530001_20110822";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_gradingPeriodKey_should_be_set_correctly()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<GradingPeriodDim>($"{TestCasesFolder}.{_caseIdentifier}_gradingPeriodKey_should_be_set_correctly.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_gradingPeriodDescription_should_not_be_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<GradingPeriodDim>($"{TestCasesFolder}.{_caseIdentifier}_gradingPeriodDescription_should_not_be_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_begin_date_key()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<GradingPeriodDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_begin_date_key.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_end_date_key()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<GradingPeriodDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_end_date_key.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_school_key()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<GradingPeriodDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_school_key.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_total_instructional_days_gt_0()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<GradingPeriodDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_total_instructional_days_gt_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_school_year()
            {
                if (!DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    (bool success, string errorMessage) testResult = DataStandard
                        .RunTestCase<GradingPeriodDim>(
                            $"{TestCasesFolder}.{_caseIdentifier}_should_have_schoolyear.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
                else
                {
                    Assert.Ignore("Data Standard 2 does not have SchoolYear on the GradingPeriod table.");
                }
            }
            [Test]
            public void Then_should_have_school_year_Unknown()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    (bool success, string errorMessage) testResult = DataStandard
                        .RunTestCase<GradingPeriodDim>(
                            $"{TestCasesFolder}.{_caseIdentifier}_should_have_schoolyear_Unknown.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
                else
                {
                    Assert.Ignore("Only Data Standard 2 does not have SchoolYear on the GradingPeriod table.");
                }
            }
        }

        public class Given_grading_period_54_628530001_20111120
        : When_querying_the_GradingPeriodDim_view
        {
            public Given_grading_period_54_628530001_20111120(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "54_628530001_20111120";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_gradingPeriodKey_should_be_set_correctly()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<GradingPeriodDim>($"{TestCasesFolder}.{_caseIdentifier}_gradingPeriodKey_should_be_set_correctly.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_gradingPeriodDescription_should_not_be_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<GradingPeriodDim>($"{TestCasesFolder}.{_caseIdentifier}_gradingPeriodDescription_should_not_be_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_begin_date_key()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<GradingPeriodDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_begin_date_key.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_end_date_key()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<GradingPeriodDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_end_date_key.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_school_key()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<GradingPeriodDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_school_key.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_total_instructional_days_gt_0()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<GradingPeriodDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_total_instructional_days_gt_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_grading_period_54_628530001_21001120
        : When_querying_the_GradingPeriodDim_view
        {
            public Given_grading_period_54_628530001_21001120(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "54_628530001_21001120";

            [Test]
            public void Then_should_return_zero_records()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_zero_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

    }
}
