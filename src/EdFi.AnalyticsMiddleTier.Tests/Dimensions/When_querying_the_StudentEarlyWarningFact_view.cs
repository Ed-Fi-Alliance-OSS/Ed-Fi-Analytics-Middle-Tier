// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using CommonLib = EdFi.AnalyticsMiddleTier.Common;
using EdFi.AnalyticsMiddleTier.Common;
using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.StudentEarlyWarningFactTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_StudentEarlyWarningFact_view : When_querying_a_view_postgres
    {
        protected const string TestCasesFolder = "TestCases.StudentEarlyWarningFact";
        protected const string TestCasesDataFileName = "0000_StudentEarlyWarningFact_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_StudentEarlyWarningFact_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }
        [SetUpFixture]
        public class SetupStudentEarlyWarningFactTestCase
            : When_querying_the_StudentEarlyWarningFact_view
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<StudentEarlyWarningFact>(TestCasesFolder, TestCasesDataFileName, Component.Ews);
        }
        public class Given_student_early_warning_fact_193964_867530011_20120502
        : When_querying_the_StudentEarlyWarningFact_view
        {
            public Given_student_early_warning_fact_193964_867530011_20120502(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "193964_867530011_20120502";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_CountByDayOfConductOffenses_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_CountByDayOfConductOffenses_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_CountByDayOfStateOffenses_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_CountByDayOfStateOffenses_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DateKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_DateKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsAbsentFromAnyClassExcused_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromAnyClassExcused_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsAbsentFromAnyClassUnexcused_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromAnyClassUnexcused_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsAbsentFromHomeroomExcused_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromHomeroomExcused_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsAbsentFromHomeroomUnexcused_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromHomeroomUnexcused_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsAbsentFromSchoolExcused_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromSchoolExcused_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsAbsentFromSchoolUnexcused_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromSchoolUnexcused_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsEnrolled_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsEnrolled_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsInstructionalDay_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsInstructionalDay_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsPresentAnyClass_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPresentAnyClass_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsPresentHomeroom_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPresentHomeroom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsPresentSchool_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPresentSchool_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsTardyToAnyClass_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsTardyToAnyClass_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsTardyToHomeroom_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsTardyToHomeroom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsTardyToSchool_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsTardyToSchool_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_early_warning_fact_193964_867530011_20120520
         : When_querying_the_StudentEarlyWarningFact_view
        {
            public Given_student_early_warning_fact_193964_867530011_20120520(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "193964_867530011_20120520";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_CountByDayOfConductOffenses_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_CountByDayOfConductOffenses_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_CountByDayOfStateOffenses_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_CountByDayOfStateOffenses_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DateKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_DateKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsAbsentFromAnyClassExcused_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromAnyClassExcused_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsAbsentFromAnyClassUnexcused_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromAnyClassUnexcused_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsAbsentFromHomeroomExcused_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromHomeroomExcused_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsAbsentFromHomeroomUnexcused_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromHomeroomUnexcused_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsAbsentFromSchoolExcused_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromSchoolExcused_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsAbsentFromSchoolUnexcused_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromSchoolUnexcused_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsEnrolled_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsEnrolled_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsInstructionalDay_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsInstructionalDay_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsPresentAnyClass_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPresentAnyClass_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsPresentHomeroom_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPresentHomeroom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsPresentSchool_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPresentSchool_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsTardyToAnyClass_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsTardyToAnyClass_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsTardyToHomeroom_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsTardyToHomeroom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsTardyToSchool_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsTardyToSchool_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_early_warning_fact_200099_867530174_20111103
        : When_querying_the_StudentEarlyWarningFact_view
        {
            public Given_student_early_warning_fact_200099_867530174_20111103(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "200099_867530174_20111103";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_CountByDayOfConductOffenses_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_CountByDayOfConductOffenses_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_CountByDayOfStateOffenses_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_CountByDayOfStateOffenses_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DateKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_DateKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsAbsentFromAnyClassExcused_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromAnyClassExcused_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsAbsentFromAnyClassUnexcused_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromAnyClassUnexcused_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsAbsentFromHomeroomExcused_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromHomeroomExcused_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsAbsentFromHomeroomUnexcused_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromHomeroomUnexcused_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsAbsentFromSchoolExcused_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromSchoolExcused_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsAbsentFromSchoolUnexcused_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromSchoolUnexcused_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsEnrolled_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsEnrolled_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsInstructionalDay_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsInstructionalDay_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsPresentAnyClass_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPresentAnyClass_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsPresentHomeroom_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPresentHomeroom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsPresentSchool_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPresentSchool_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsTardyToAnyClass_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsTardyToAnyClass_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsTardyToHomeroom_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsTardyToHomeroom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsTardyToSchool_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsTardyToSchool_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_early_warning_fact_189889_867530022_20111205
        : When_querying_the_StudentEarlyWarningFact_view
        {
            public Given_student_early_warning_fact_189889_867530022_20111205(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "189889_867530022_20111205";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_CountByDayOfConductOffenses_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_CountByDayOfConductOffenses_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_CountByDayOfStateOffenses_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_CountByDayOfStateOffenses_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DateKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_DateKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsAbsentFromAnyClassExcused_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromAnyClassExcused_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsAbsentFromAnyClassUnexcused_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromAnyClassUnexcused_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsAbsentFromHomeroomExcused_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromHomeroomExcused_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsAbsentFromHomeroomUnexcused_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromHomeroomUnexcused_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsAbsentFromSchoolExcused_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromSchoolExcused_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsAbsentFromSchoolUnexcused_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromSchoolUnexcused_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsEnrolled_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsEnrolled_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsInstructionalDay_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsInstructionalDay_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsPresentAnyClass_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPresentAnyClass_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsPresentHomeroom_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPresentHomeroom_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsPresentSchool_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPresentSchool_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsTardyToAnyClass_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsTardyToAnyClass_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsTardyToHomeroom_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsTardyToHomeroom_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsTardyToSchool_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsTardyToSchool_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentEarlyWarningFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_early_warning_fact_189936_867530023_20120520
            : When_querying_the_StudentEarlyWarningFact_view
        {
            public Given_student_early_warning_fact_189936_867530023_20120520(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
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

        public class Given_student_early_warning_fact_189936_867530023_20120820
            : When_querying_the_StudentEarlyWarningFact_view
        {
            public Given_student_early_warning_fact_189936_867530023_20120820(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
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

        public class Given_student_early_warning_fact_600090441_628530001_20110820
            : When_querying_the_StudentEarlyWarningFact_view
        {
            public Given_student_early_warning_fact_600090441_628530001_20110820(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
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

        public class Given_student_early_warning_fact_future_dates
            : When_querying_the_StudentEarlyWarningFact_view
        {
            public Given_student_early_warning_fact_future_dates(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
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

        public class Given_student_early_warning_ispresent_any_class_1
            : When_querying_the_StudentEarlyWarningFact_view
        {
            public Given_student_early_warning_ispresent_any_class_1(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "190237_867530022_20120502";

            [Test]
            public void Then_should_have_IsAnyPresent_Homeroom_0()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentEarlyWarningFact>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAnyPresent_Homeroom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_early_warning_204030_867530011_20120520
          : When_querying_the_StudentEarlyWarningFact_view
        {
            public Given_student_early_warning_204030_867530011_20120520(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "204030_867530011_20120520";

            [Test]
            public void Then_should_have_IsAbsentFromSchoolExcused_0()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentEarlyWarningFact>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromSchoolExcused_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsPresentHomeroom_0()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentEarlyWarningFact>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPresentHomeroom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsTardyToHomeroom_0()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentEarlyWarningFact>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_IsTardyToHomeroom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_early_warning_190237_867530022_20120502
          : When_querying_the_StudentEarlyWarningFact_view
        {
            public Given_student_early_warning_190237_867530022_20120502(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "190237_867530022_20120502";

            [Test]
            public void Then_should_have_IsPresentHomeroom_0()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentEarlyWarningFact>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPresentHomeroom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_early_warning_190421_867530022_20111205
          : When_querying_the_StudentEarlyWarningFact_view
        {
            public Given_student_early_warning_190421_867530022_20111205(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "190421_867530022_20111205";

            [Test]
            public void Then_should_have_IsTardyToHomeroom_0()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentEarlyWarningFact>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_IsTardyToHomeroom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_early_warning_204030_867530011_20110822
          : When_querying_the_StudentEarlyWarningFact_view
        {
            public Given_student_early_warning_204030_867530011_20110822(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "204030_867530011_20110822";

            [Test]
            public void Then_should_not_return_records()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentEarlyWarningFact>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_not_return_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_early_warning_189854_867530011_20120520
          : When_querying_the_StudentEarlyWarningFact_view
        {
            public Given_student_early_warning_189854_867530011_20120520(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "189854_867530011_20120520";

            [Test]
            public void Then_should_have_IsAbsentFromSchoolUnexcused_0()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentEarlyWarningFact>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromSchoolUnexcused_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsAbsentFromHomeroomUnexcused_0()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"This testcase validates a filter from Data Standard 3x.");
                }
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentEarlyWarningFact>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromHomeroomUnexcused_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            //
        }

        public class Given_student_early_warning_fact_189936_867530023_20110820
          : When_querying_the_StudentEarlyWarningFact_view
        {
            public Given_student_early_warning_fact_189936_867530023_20110820(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "189936_867530023_20110820";

            [Test]
            public void Then_should_not_return_records()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_not_return_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_early_warning_189889_867530022_20120502
          : When_querying_the_StudentEarlyWarningFact_view
        {
            public Given_student_early_warning_189889_867530022_20120502(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "189889_867530022_20120502";

            [Test]
            public void Then_should_have_CountByDayOfConductOffenses_0()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentEarlyWarningFact>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_CountByDayOfConductOffenses_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_CountByDayOfStateOffenses_0()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentEarlyWarningFact>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_CountByDayOfStateOffenses_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_early_warning_fact_236165_867530063_20120525
         : When_querying_the_StudentEarlyWarningFact_view
        {
            public Given_student_early_warning_fact_236165_867530063_20120525(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "236165_867530063_20120525";

            [Test]
            public void Then_should_have_IsAbsentFromHomeroomExcused_0()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentEarlyWarningFact>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromHomeroomExcused_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsAbsentFromHomeroomUnexcused_0()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentEarlyWarningFact>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_IsAbsentFromHomeroomUnexcused_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsPresentHomeroom_0()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentEarlyWarningFact>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPresentHomeroom_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_CountByDayOfConductOffenses_0()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentEarlyWarningFact>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_CountByDayOfConductOffenses_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_early_warning_fact_189871_867530011_20120502
          : When_querying_the_StudentEarlyWarningFact_view
        {
            public Given_student_early_warning_fact_189871_867530011_20120502(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "189871_867530011_20120502";

            [Test]
            public void Then_should_have_CountByDayOfConductOffenses_0()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentEarlyWarningFact>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_CountByDayOfConductOffenses_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
