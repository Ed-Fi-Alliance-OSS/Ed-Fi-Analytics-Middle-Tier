// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Common;
using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.ChronicAbsenteeismAttendanceFactTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_ChronicAbsenteeismAttendanceFact_view : When_querying_a_view_postgres
    {
        protected const string TestCasesFolder = "TestCases.ChronicAbsenteeismAttendanceFact";
        protected const string TestCasesDataFileName = "0000_ChronicAbsenteeismAttendanceFact_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_ChronicAbsenteeismAttendanceFact_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }
        [SetUpFixture]
        public class SetupChronicAbsenteeismAttendanceFactTestCase
            : When_querying_the_ChronicAbsenteeismAttendanceFact_view
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<ChronicAbsenteeismAttendanceFact>(TestCasesFolder, TestCasesDataFileName, Component.Chrab);
        }
        public class Given_chronic_absenteeism_attendance_fact_193964_867530011_20120502
        : When_querying_the_ChronicAbsenteeismAttendanceFact_view
        {
            public Given_chronic_absenteeism_attendance_fact_193964_867530011_20120502(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "193964_867530011_20120502";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DateKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_DateKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportedAsAbsentFromAnySection_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsAbsentFromAnySection_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportedAsAbsentFromHomeRoom_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsAbsentFromHomeRoom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportedAsAbsentFromSchool_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsAbsentFromSchool_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportedAsIsPresentInAllSections_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsIsPresentInAllSections_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_ReportedAsPresentAtHomeRoom_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsPresentAtHomeRoom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_ReportedAsPresentAtSchool_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsPresentAtSchool_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_chronic_absenteeism_attendance_fact_193964_867530011_20120520
         : When_querying_the_ChronicAbsenteeismAttendanceFact_view
        {
            public Given_chronic_absenteeism_attendance_fact_193964_867530011_20120520(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "193964_867530011_20120520";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DateKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_DateKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportedAsAbsentFromAnySection_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsAbsentFromAnySection_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportedAsAbsentFromHomeRoom_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsAbsentFromHomeRoom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportedAsAbsentFromSchool_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsAbsentFromSchool_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportedAsIsPresentInAllSections_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsIsPresentInAllSections_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_ReportedAsPresentAtHomeRoom_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsPresentAtHomeRoom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_ReportedAsPresentAtSchool_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsPresentAtSchool_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_chronic_absenteeism_attendance_fact_193965_867530013_20120520
         : When_querying_the_ChronicAbsenteeismAttendanceFact_view
        {
            public Given_chronic_absenteeism_attendance_fact_193965_867530013_20120520(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "193965_867530013_20120520";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DateKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_DateKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportedAsAbsentFromHomeRoom_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsAbsentFromHomeRoom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_chronic_absenteeism_attendance_fact_193965_867530014_20120520
         : When_querying_the_ChronicAbsenteeismAttendanceFact_view
        {
            public Given_chronic_absenteeism_attendance_fact_193965_867530014_20120520(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "193965_867530014_20120520";

            [Test]
            public void Then_should_have_ReportedAsPresentAtHomeRoom_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsPresentAtHomeRoom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_chronic_absenteeism_attendance_fact_193969_867530016_20120520
         : When_querying_the_ChronicAbsenteeismAttendanceFact_view
        {
            public Given_chronic_absenteeism_attendance_fact_193969_867530016_20120520(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "193969_867530016_20120520";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DateKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_DateKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportedAsAbsentFromHomeRoom_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsAbsentFromHomeRoom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportedAsAbsentFromAnySection_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsAbsentFromAnySection_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_chronic_absenteeism_attendance_fact_193969_867530016_20120720
         : When_querying_the_ChronicAbsenteeismAttendanceFact_view
        {
            public Given_chronic_absenteeism_attendance_fact_193969_867530016_20120720(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "193969_867530016_20120720";
            [Test]
            public void Then_should_not_return_records()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_not_return_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_chronic_absenteeism_attendance_fact_193975_867530033_20120520
         : When_querying_the_ChronicAbsenteeismAttendanceFact_view
        {
            public Given_chronic_absenteeism_attendance_fact_193975_867530033_20120520(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "193975_867530033_20120520";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DateKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_DateKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportedAsAbsentFromHomeRoom_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsAbsentFromAnySection_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }



        public class Given_chronic_absenteeism_attendance_fact_193985_867530043_20120520
         : When_querying_the_ChronicAbsenteeismAttendanceFact_view
        {
            public Given_chronic_absenteeism_attendance_fact_193985_867530043_20120520(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "193985_867530043_20120520";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DateKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_DateKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportedAsAbsentFromHomeRoom_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsAbsentFromHomeRoom_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_chronic_absenteeism_attendance_fact_200099_867530174_20111103
        : When_querying_the_ChronicAbsenteeismAttendanceFact_view
        {
            public Given_chronic_absenteeism_attendance_fact_200099_867530174_20111103(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "200099_867530174_20111103";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DateKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_DateKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportedAsAbsentFromAnySection_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsAbsentFromAnySection_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportedAsAbsentFromHomeRoom_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsAbsentFromHomeRoom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportedAsAbsentFromSchool_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsAbsentFromSchool_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportedAsIsPresentInAllSections_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsIsPresentInAllSections_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_ReportedAsPresentAtHomeRoom_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsPresentAtHomeRoom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_ReportedAsPresentAtSchool_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsPresentAtSchool_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_chronic_absenteeism_attendance_fact_200099_867530174_20111104
        : When_querying_the_ChronicAbsenteeismAttendanceFact_view
        {
            public Given_chronic_absenteeism_attendance_fact_200099_867530174_20111104(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "200099_867530174_20111104";

            [Test]
            public void Then_should_have_ReportedAsAbsentFromSchool_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsAbsentFromSchool_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

        }

        public class Given_chronic_absenteeism_attendance_fact_189889_867530022_20111205
        : When_querying_the_ChronicAbsenteeismAttendanceFact_view
        {
            public Given_chronic_absenteeism_attendance_fact_189889_867530022_20111205(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "189889_867530022_20111205";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DateKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_DateKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportedAsAbsentFromAnySection_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsAbsentFromAnySection_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportedAsAbsentFromHomeRoom_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsAbsentFromHomeRoom_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportedAsAbsentFromSchool_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsAbsentFromSchool_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportedAsIsPresentInAllSections_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsIsPresentInAllSections_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_ReportedAsPresentAtHomeRoom_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsPresentAtHomeRoom_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_ReportedAsPresentAtSchool_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsPresentAtSchool_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_chronic_absenteeism_attendance_fact_189855_867530012_20120502
        : When_querying_the_ChronicAbsenteeismAttendanceFact_view
        {
            public Given_chronic_absenteeism_attendance_fact_189855_867530012_20120502(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "189855_867530012_20120502";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DateKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_DateKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportedAsIsPresentInAllSections_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsIsPresentInAllSections_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportedAsAbsentFromHomeRoom_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsAbsentFromHomeRoom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportedAsAbsentFromAnySection_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsAbsentFromAnySection_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_return_ReportedAsPresentAtHomeRoom_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_return_ReportedAsPresentAtHomeRoom_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_chronic_absenteeism_attendance_fact_189855_867530013_20120503
        : When_querying_the_ChronicAbsenteeismAttendanceFact_view
        {
            public Given_chronic_absenteeism_attendance_fact_189855_867530013_20120503(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "189855_867530013_20120503";

            [Test]
            public void Then_should_have_ReportedAsPresentAtHomeRoom_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsPresentAtHomeRoom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_chronic_absenteeism_attendance_fact_189936_867530023_20120520
            : When_querying_the_ChronicAbsenteeismAttendanceFact_view
        {
            public Given_chronic_absenteeism_attendance_fact_189936_867530023_20120520(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "189936_867530023_20120520";

            [Test]
            public void Then_should_not_return_records()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_not_return_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_chronic_absenteeism_attendance_fact_189936_867530023_20120820
            : When_querying_the_ChronicAbsenteeismAttendanceFact_view
        {
            public Given_chronic_absenteeism_attendance_fact_189936_867530023_20120820(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "189936_867530023_20120520";

            [Test]
            public void Then_should_not_return_records()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_not_return_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_chronic_absenteeism_attendance_fact_600090441_628530001_20110820
            : When_querying_the_ChronicAbsenteeismAttendanceFact_view
        {
            public Given_chronic_absenteeism_attendance_fact_600090441_628530001_20110820(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "600090441_628530001_20110820";

            [Test]
            public void Then_should_not_return_records()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_not_return_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_chronic_absenteeism_attendance_fact_189854_867530011_20110822
            : When_querying_the_ChronicAbsenteeismAttendanceFact_view
        {
            public Given_chronic_absenteeism_attendance_fact_189854_867530011_20110822(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "189854_867530011_20110822";

            [Test]
            public void Then_should_not_return_records()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_not_return_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_chronic_absenteeism_attendance_fact_189854_867530011_20120502
           : When_querying_the_ChronicAbsenteeismAttendanceFact_view
        {

            public Given_chronic_absenteeism_attendance_fact_189854_867530011_20120502(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "189854_867530011_20120502";

            [Test]
            public void Then_should_have_ReportedAsIsPresentInAllSections_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsIsPresentInAllSections_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_chronic_absenteeism_attendance_fact_200011_867530174_20140502
            : When_querying_the_ChronicAbsenteeismAttendanceFact_view
        {
            public Given_chronic_absenteeism_attendance_fact_200011_867530174_20140502(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "200011_867530174_20140502";

            [Test]
            public void Then_should_have_ReportedAsAbsentFromSchool_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsAbsentFromSchool_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportedAsPresentAtSchool_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportedAsPresentAtSchool_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

        }

        public class Given_chronic_absenteeism_attendance_fact_193968_867530015_20120520
            : When_querying_the_ChronicAbsenteeismAttendanceFact_view
        {
            public Given_chronic_absenteeism_attendance_fact_193968_867530015_20120520(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "193968_867530015_20120520";

            [Test]
            public void Then_should_not_return_records()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_not_return_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_chronic_absenteeism_attendance_fact_future_dates
            : When_querying_the_ChronicAbsenteeismAttendanceFact_view
        {
            public Given_chronic_absenteeism_attendance_fact_future_dates(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "future_dates";

            [Test]
            public void Then_should_not_return_records()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_not_return_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
