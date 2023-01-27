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
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.DateDimTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_DateDim_view : When_querying_a_view_postgres
    {
        protected const string TestCasesFolder = "TestCases.DateDim";
        protected const string TestCasesDataFileName = "0000_DateDim_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_view_should_match_column_dictionary.json");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [SetUpFixture]
        public class SetupDateDimTestCase
            : When_querying_the_DateDim_view
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<DateDim>(TestCasesFolder, TestCasesDataFileName);
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_calendar_event_date_March_5_2019
        : When_querying_the_DateDim_view
        {
            public Given_calendar_event_date_March_5_2019(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "March_5_2019";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_dateKey_should_be_set_correctly()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<DateDim>($"{TestCasesFolder}.{_caseIdentifier}_dateKey_should_be_set_correctly.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_calendarQuarter_should_be_1()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>($"{TestCasesFolder}.{_caseIdentifier}_calendarQuarter_should_be_1.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_CalendarQuarterName_should_be_first()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_calendarQuarterName_should_be_first.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_calendar_event_date_July_12_2019
        : When_querying_the_DateDim_view
        {
            public Given_calendar_event_date_July_12_2019(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "July_12_2019";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_dateKey_should_be_set_correctly()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>($"{TestCasesFolder}.{_caseIdentifier}_dateKey_should_be_set_correctly.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_calendarQuarter_should_be_3()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>($"{TestCasesFolder}.{_caseIdentifier}_calendarQuarter_should_be_3.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_calendarQuarterName_should_be_third()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_calendarQuarterName_should_be_third.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_calendar_event_date_Jan_1_2019
            : When_querying_the_DateDim_view
        {
            public Given_calendar_event_date_Jan_1_2019(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "Jan_1_2019";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_dateKey_should_be_set_correctly()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>($"{TestCasesFolder}.{_caseIdentifier}_dateKey_should_be_set_correctly.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_calendarQuarter_should_be_1()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>($"{TestCasesFolder}.{_caseIdentifier}_calendarQuarter_should_be_1.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_calendarQuarterName_should_be_first()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_calendarQuarterName_should_be_first.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_calendar_event_date_March_31_2019
            : When_querying_the_DateDim_view
        {
            public Given_calendar_event_date_March_31_2019(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "March_31_2019";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_dateKey_should_be_set_correctly()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>($"{TestCasesFolder}.{_caseIdentifier}_dateKey_should_be_set_correctly.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_calendarQuarter_should_be_1()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>($"{TestCasesFolder}.{_caseIdentifier}_calendarQuarter_should_be_1.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_calendarQuarterName_should_be_first()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_calendarQuarterName_should_be_first.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_calendar_event_date_Apr_1_2019
            : When_querying_the_DateDim_view
        {
            public Given_calendar_event_date_Apr_1_2019(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "Apr_1_2019";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_dateKey_should_be_set_correctly()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>($"{TestCasesFolder}.{_caseIdentifier}_dateKey_should_be_set_correctly.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_calendarQuarter_should_be_2()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>($"{TestCasesFolder}.{_caseIdentifier}_calendarQuarter_should_be_2.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_schoolyear_should_be_2019()
            {

                if (!DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    (bool success, string errorMessage) testResult = DataStandard
                        .RunTestCase<DateDim>(
                            $"{TestCasesFolder}.{_caseIdentifier}_schoolyear_should_be_2019.json");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
                else
                {
                    Assert.Ignore("Data Standard 2 does not have SchoolYear on the CalendarDateCalendarEvent table, thus for Data Standard 2 the value will be null.");
                }
            }
            [Test]
            public void Then_schoolyear_should_be_Unknown()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    (bool success, string errorMessage) testResult = DataStandard
                        .RunTestCase<DateDim>(
                            $"{TestCasesFolder}.{_caseIdentifier}_schoolyear_should_be_Unknown.json");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
                else
                {
                    Assert.Ignore("Only Data Standard 2 does not have SchoolYear on the CalendarDateCalendarEvent table, thus for Data Standard 2 the value will be Unknown.");
                }
            }
            [Test]
            public void Then_calendarQuarterName_should_be_second()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_calendarQuarterName_should_be_second.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_calendar_event_date_Jun_30_2019
            : When_querying_the_DateDim_view
        {
            public Given_calendar_event_date_Jun_30_2019(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "Jun_30_2019";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_dateKey_should_be_set_correctly()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>($"{TestCasesFolder}.{_caseIdentifier}_dateKey_should_be_set_correctly.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_calendarQuarter_should_be_2()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>($"{TestCasesFolder}.{_caseIdentifier}_calendarQuarter_should_be_2.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_calendarQuarterName_should_be_second()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_calendarQuarterName_should_be_second.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_calendar_event_date_July_1_2019
            : When_querying_the_DateDim_view
        {
            public Given_calendar_event_date_July_1_2019(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "July_1_2019";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_dateKey_should_be_set_correctly()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>($"{TestCasesFolder}.{_caseIdentifier}_dateKey_should_be_set_correctly.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_calendarQuarter_should_be_3()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>($"{TestCasesFolder}.{_caseIdentifier}_calendarQuarter_should_be_3.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_calendarQuarterName_should_be_third()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_calendarQuarterName_should_be_third.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_calendar_event_date_Sept_30_2019
            : When_querying_the_DateDim_view
        {
            public Given_calendar_event_date_Sept_30_2019(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "Sept_30_2019";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_dateKey_should_be_set_correctly()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>($"{TestCasesFolder}.{_caseIdentifier}_dateKey_should_be_set_correctly.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_calendarQuarter_should_be_3()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>($"{TestCasesFolder}.{_caseIdentifier}_calendarQuarter_should_be_3.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_calendarQuarterName_should_be_third()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_calendarQuarterName_should_be_third.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_calendar_event_date_Oct_1_2019
            : When_querying_the_DateDim_view
        {
            public Given_calendar_event_date_Oct_1_2019(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "Oct_1_2019";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_dateKey_should_be_set_correctly()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>($"{TestCasesFolder}.{_caseIdentifier}_dateKey_should_be_set_correctly.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_calendarQuarter_should_be_4()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>($"{TestCasesFolder}.{_caseIdentifier}_calendarQuarter_should_be_4.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_calendarQuarterName_should_be_fourth()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_calendarQuarterName_should_be_fourth.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_calendar_event_date_Dec_31_2019
            : When_querying_the_DateDim_view
        {
            public Given_calendar_event_date_Dec_31_2019(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "Dec_31_2019";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_dateKey_should_be_set_correctly()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>($"{TestCasesFolder}.{_caseIdentifier}_dateKey_should_be_set_correctly.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_calendarQuarter_should_be_4()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>($"{TestCasesFolder}.{_caseIdentifier}_calendarQuarter_should_be_4.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_calendarQuarterName_should_be_fourth()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<DateDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_calendarQuarterName_should_be_fourth.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
