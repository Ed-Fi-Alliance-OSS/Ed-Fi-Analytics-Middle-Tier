// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.StudentProgramDimTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_StudentProgramDim_view : When_querying_a_view_postgres
    {

        protected const string TestCasesFolder = "TestCases.StudentProgramDim";
        protected const string TestCasesDataFileName = "0000_StudentProgramDim_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult =
                DataStandard.RunTestCase<TableColumns>(
                    $"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_StudentProgramDim_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [SetUpFixture]
        public class SetupStudentProgramDimTestCase
                : When_querying_the_StudentProgramDim_view
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<StudentProgramDim>(TestCasesFolder, TestCasesDataFileName);
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_190009_867530020_Special_Education
            : When_querying_the_StudentProgramDim_view
        {
            private const string _caseIdentifier = "190009_867530020_Special_Education";
            public Given_student_190009_867530020_Special_Education(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_BeginDateKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_BeginDateKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSchoolProgramKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolProgramKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_EducationOrganizationId()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_EducationOrganizationId.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ProgramName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_ProgramName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_190257_867530023_Section_504_Placement
            : When_querying_the_StudentProgramDim_view
        {
            private const string _caseIdentifier = "190257_867530023_Section_504_Placement";
            public Given_student_190257_867530023_Section_504_Placement(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_BeginDateKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_BeginDateKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_EducationOrganizationId()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_EducationOrganizationId.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ProgramName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_ProgramName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSchoolProgramKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolProgramKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_190020_867530023_Bilingual
            : When_querying_the_StudentProgramDim_view
        {
            private const string _caseIdentifier = "190020_867530023_Bilingual";
            public Given_student_190020_867530023_Bilingual(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_not_return_any_records()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_190009_867530020_Special_Education_1684_778530
            : When_querying_the_StudentProgramDim_view
        {
            private const string _caseIdentifier = "190009_867530020_Special_Education_1684_778530";
            public Given_student_190009_867530020_Special_Education_1684_778530(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_not_return_any_records()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_190257_867530023_Section_504_Placement_1637_867530
            : When_querying_the_StudentProgramDim_view
        {
            private const string _caseIdentifier = "190257_867530023_Section_504_Placement_1637_867530";
            public Given_student_190257_867530023_Section_504_Placement_1637_867530(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_not_return_any_records()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_190257_867530023_Bilingual_1682_867530
           : When_querying_the_StudentProgramDim_view
        {
            private const string _caseIdentifier = "190257_867530023_Bilingual_1682_867530";
            public Given_student_190257_867530023_Bilingual_1682_867530(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_not_return_any_records()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_190009_867530020
           : When_querying_the_StudentProgramDim_view
        {
            private const string _caseIdentifier = "190009_867530020";
            public Given_student_190009_867530020(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_return_two_records()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_return_two_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
