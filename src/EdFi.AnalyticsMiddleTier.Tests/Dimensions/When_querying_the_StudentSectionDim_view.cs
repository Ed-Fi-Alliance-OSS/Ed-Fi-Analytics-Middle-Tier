// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;

namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_StudentSectionDim_view : When_querying_a_view
    {
        protected const string TestCasesFolder = "TestCases.StudentSectionDim";

        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            DataStandard.PrepareDatabase();
        }

        [OneTimeSetUp]
        public void Act()
        {
            Result = DataStandard.LoadTestCaseData<StudentSectionDim>(
                $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.0000_StudentSectionDim_Data_Load.xml");
            Result.success.ShouldBeTrue($"Error while loading data: '{Result.errorMessage}'");

            Result = DataStandard.Install();
            Result.success.ShouldBeTrue($"Error while installing Base: '{Result.errorMessage}'");
        }

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>(
                $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.0001_StudentSectionDim_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        public class Given_student_section_without_teacher
            : When_querying_the_StudentSectionDim_view
        {
            public Given_student_section_without_teacher(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "without_teacher";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_studentsectionkey_should_be_set_correctly()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSectionDim>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_studentsectionkey_should_be_set_correctly.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_course_title_not_null()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionDim>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_course_title_not_null.xml");
                testResult.success.ShouldBe(false, testResult.errorMessage);
            }

            [Test]
            public void Then_sectionkey_should_be_set_correctly()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSectionDim>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_sectionkey_should_be_set_correctly.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_lastmodifieddate()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionDim>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_lastmodifieddate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_local_course()
            {
                Result = DataStandard.RunTestCase<StudentSectionDim>(
                    $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_local_course.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }

            [Test]
            public void Then_should_have_schoolkey()
            {
                Result = DataStandard.RunTestCase<StudentSectionDim>(
                    $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_schoolkey.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }

            [Test]
            public void Then_should_have_studentkey()
            {
                Result = DataStandard.RunTestCase<StudentSectionDim>(
                    $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_studentkey.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }

            [Test]
            public void Then_should_have_studentsectionenddatekey()
            {
                Result = DataStandard.RunTestCase<StudentSectionDim>(
                    $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_studentsectionenddatekey.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }

            [Test]
            public void Then_should_have_studentsectionstartdatekey()
            {
                Result = DataStandard.RunTestCase<StudentSectionDim>(
                    $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_studentsectionstartdatekey.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }

            [Test]
            public void Then_should_have_subject()
            {
                Result = DataStandard.RunTestCase<StudentSectionDim>(
                    $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_subject.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }

            [Test]
            public void Then_should_have_teacher_empty()
            {
                Result = DataStandard.RunTestCase<StudentSectionDim>(
                    $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_teacher_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
        }

        public class Given_student_section_without_subject
            : When_querying_the_StudentSectionDim_view
        {
            public Given_student_section_without_subject(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "without_subject";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_studentsectionkey_should_be_set_correctly()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSectionDim>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_studentsectionkey_should_be_set_correctly.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_sectionkey_should_be_set_correctly()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSectionDim>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_sectionkey_should_be_set_correctly.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_course_title_not_null()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionDim>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_course_title_not_null.xml");
                testResult.success.ShouldBe(false, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_lastmodifieddate()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionDim>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_lastmodifieddate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_local_course()
            {
                Result = DataStandard.RunTestCase<StudentSectionDim>(
                    $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_local_course.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }

            [Test]
            public void Then_should_have_schoolkey()
            {
                Result = DataStandard.RunTestCase<StudentSectionDim>(
                    $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_schoolkey.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }

            [Test]
            public void Then_should_have_studentkey()
            {
                Result = DataStandard.RunTestCase<StudentSectionDim>(
                    $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_studentkey.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }

            [Test]
            public void Then_should_have_studentsectionenddatekey()
            {
                Result = DataStandard.RunTestCase<StudentSectionDim>(
                    $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_studentsectionenddatekey.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }

            [Test]
            public void Then_should_have_studentsectionstartdatekey()
            {
                Result = DataStandard.RunTestCase<StudentSectionDim>(
                    $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_studentsectionstartdatekey.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }

            [Test]
            public void Then_should_have_subject_empty()
            {
                Result = DataStandard.RunTestCase<StudentSectionDim>(
                    $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_subject_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }

            [Test]
            public void Then_should_have_teacher_empty()
            {
                Result = DataStandard.RunTestCase<StudentSectionDim>(
                    $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_teacher_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
        }

        public class Given_student_section_multiple_teacher
            : When_querying_the_StudentSectionDim_view
        {
            public Given_student_section_multiple_teacher(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "multiple_teachers";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_studentsectionkey_should_be_set_correctly()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSectionDim>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_studentsectionkey_should_be_set_correctly.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_sectionkey_should_be_set_correctly()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSectionDim>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_sectionkey_should_be_set_correctly.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_course_title_not_null()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionDim>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_course_title_not_null.xml");
                testResult.success.ShouldBe(false, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_lastmodifieddate()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionDim>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_lastmodifieddate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_local_course()
            {
                Result = DataStandard.RunTestCase<StudentSectionDim>(
                    $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_local_course.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }

            [Test]
            public void Then_should_have_schoolkey()
            {
                Result = DataStandard.RunTestCase<StudentSectionDim>(
                    $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_schoolkey.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }

            [Test]
            public void Then_should_have_studentkey()
            {
                Result = DataStandard.RunTestCase<StudentSectionDim>(
                    $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_studentkey.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }

            [Test]
            public void Then_should_have_studentsectionenddatekey()
            {
                Result = DataStandard.RunTestCase<StudentSectionDim>(
                    $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_studentsectionenddatekey.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }

            [Test]
            public void Then_should_have_studentsectionstartdatekey()
            {
                Result = DataStandard.RunTestCase<StudentSectionDim>(
                    $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_studentsectionstartdatekey.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }

            [Test]
            public void Then_should_have_subject()
            {
                Result = DataStandard.RunTestCase<StudentSectionDim>(
                    $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_subject.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }

            [Test]
            public void Then_should_have_multiple_teacher()
            {
                Result = DataStandard.RunTestCase<StudentSectionDim>(
                    $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_multiple_teacher.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_school_year()
            {
                Result = DataStandard.RunTestCase<StudentSectionDim>(
                    $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_school_year.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
        }

        public class Given_student_section_academic_subject
            : When_querying_the_StudentSectionDim_view
        {
            public Given_student_section_academic_subject(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "academic_subject";

            [Test]
            public void Then_should_have_lastmodifieddate()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionDim>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_lastmodifieddate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        //
    }
}
