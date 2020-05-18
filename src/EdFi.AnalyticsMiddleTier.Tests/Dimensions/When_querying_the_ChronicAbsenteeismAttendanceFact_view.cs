﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Common;
using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;

namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_ChronicAbsenteeismAttendanceFact_view : When_querying_a_view
    {
        protected const string TestCasesFolder = "TestCases.ChronicAbsenteeismAttendanceFact";

        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            DataStandard.PrepareDatabase();
        }

        [OneTimeSetUp]
        public void Act()
        {
            Result = DataStandard.LoadTestCaseData<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.0000_ChronicAbsenteeismAttendanceFact_Data_Load.xml");
            Result.success.ShouldBeTrue($"Error while loading data: '{Result.errorMessage}'");

            Result = DataStandard.Install(10, Component.Chrab);
            Result.success.ShouldBeTrue($"Error while installing Base and Chrab: '{Result.errorMessage}'");
        }

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.0001_ChronicAbsenteeismAttendanceFact_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        public class Given_chronic_absenteeism_attendance_fact_193964_867530011_20120502
        : When_querying_the_ChronicAbsenteeismAttendanceFact_view
        {
            public Given_chronic_absenteeism_attendance_fact_193964_867530011_20120502(TestHarness dataStandard) => SetDataStandard(dataStandard);
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
            public void Then_should_have_IsAbsentFromAnySection_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromAnySection_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsAbsentFromHomeRoom_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromHomeRoom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsAbsentFromSchool_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromSchool_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsPresentInAllSections_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPresentInAllSections_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsPresentAtHomeRoom_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPresentAtHomeRoom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsPresentAtSchool_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPresentAtSchool_0.xml");
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
            public Given_chronic_absenteeism_attendance_fact_193964_867530011_20120520(TestHarness dataStandard) => SetDataStandard(dataStandard);
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
            public void Then_should_have_IsAbsentFromAnySection_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromAnySection_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsAbsentFromHomeRoom_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromHomeRoom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsAbsentFromSchool_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromSchool_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsPresentInAllSections_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPresentInAllSections_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsPresentAtHomeRoom_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPresentAtHomeRoom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsPresentAtSchool_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPresentAtSchool_0.xml");
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
            public Given_chronic_absenteeism_attendance_fact_193965_867530013_20120520(TestHarness dataStandard) => SetDataStandard(dataStandard);
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
            public void Then_should_have_IsAbsentFromHomeRoom_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromHomeRoom_0.xml");
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

        public class Given_chronic_absenteeism_attendance_fact_193969_867530016_20120520
         : When_querying_the_ChronicAbsenteeismAttendanceFact_view
        {
            public Given_chronic_absenteeism_attendance_fact_193969_867530016_20120520(TestHarness dataStandard) => SetDataStandard(dataStandard);
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
            public void Then_should_have_IsAbsentFromHomeRoom_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromHomeRoom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsAbsentFromAnySection_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromAnySection_0.xml");
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

        public class Given_chronic_absenteeism_attendance_fact_193975_867530033_20120520
         : When_querying_the_ChronicAbsenteeismAttendanceFact_view
        {
            public Given_chronic_absenteeism_attendance_fact_193975_867530033_20120520(TestHarness dataStandard) => SetDataStandard(dataStandard);
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
            public void Then_should_have_IsAbsentFromHomeRoom_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromAnySection_1.xml");
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
            public Given_chronic_absenteeism_attendance_fact_193985_867530043_20120520(TestHarness dataStandard) => SetDataStandard(dataStandard);
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
            public void Then_should_have_IsAbsentFromHomeRoom_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromHomeRoom_1.xml");
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
            public Given_chronic_absenteeism_attendance_fact_200099_867530174_20111103(TestHarness dataStandard) => SetDataStandard(dataStandard);
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
            public void Then_should_have_IsAbsentFromAnySection_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromAnySection_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsAbsentFromHomeRoom_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromHomeRoom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsAbsentFromSchool_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromSchool_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsPresentInAllSections_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPresentInAllSections_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsPresentAtHomeRoom_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPresentAtHomeRoom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsPresentAtSchool_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPresentAtSchool_1.xml");
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

        public class Given_chronic_absenteeism_attendance_fact_189889_867530022_20111205
        : When_querying_the_ChronicAbsenteeismAttendanceFact_view
        {
            public Given_chronic_absenteeism_attendance_fact_189889_867530022_20111205(TestHarness dataStandard) => SetDataStandard(dataStandard);
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
            public void Then_should_have_IsAbsentFromAnySection_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromAnySection_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsAbsentFromHomeRoom_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromHomeRoom_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsAbsentFromSchool_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromSchool_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsPresentInAllSections_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPresentInAllSections_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsPresentAtHomeRoom_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPresentAtHomeRoom_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsPresentAtSchool_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPresentAtSchool_0.xml");
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
            public Given_chronic_absenteeism_attendance_fact_189855_867530012_20120502(TestHarness dataStandard) => SetDataStandard(dataStandard);
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
            public void Then_should_have_IsPresentInAllSections_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ChronicAbsenteeismAttendanceFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPresentInAllSections_1.xml");
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
        
        public class Given_chronic_absenteeism_attendance_fact_189936_867530023_20120520
            : When_querying_the_ChronicAbsenteeismAttendanceFact_view
        {
            public Given_chronic_absenteeism_attendance_fact_189936_867530023_20120520(TestHarness dataStandard) => SetDataStandard(dataStandard);
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
            public Given_chronic_absenteeism_attendance_fact_189936_867530023_20120820(TestHarness dataStandard) => SetDataStandard(dataStandard);
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
            public Given_chronic_absenteeism_attendance_fact_600090441_628530001_20110820(TestHarness dataStandard) => SetDataStandard(dataStandard);
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

        public class Given_chronic_absenteeism_attendance_fact_193968_867530015_20120520
            : When_querying_the_ChronicAbsenteeismAttendanceFact_view
        {
            public Given_chronic_absenteeism_attendance_fact_193968_867530015_20120520(TestHarness dataStandard) => SetDataStandard(dataStandard);
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
            public Given_chronic_absenteeism_attendance_fact_future_dates(TestHarness dataStandard) => SetDataStandard(dataStandard);
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
