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
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.StudentSectionGradeFactTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_StudentSectionGradeFact_view : When_querying_a_view_postgres
    {
        protected const string TestCasesFolder = "TestCases.StudentSectionGradeFact";
        protected const string TestCasesDataFileName = "0000_StudentSectionGradeFact_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_StudentSectionGradeFact_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [SetUpFixture]
        public class SetupStudentSectionGradeFactTestCase
                : When_querying_the_StudentSectionGradeFact_view
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<StudentSectionGradeFact>(TestCasesFolder, TestCasesDataFileName, Component.Ews);
        }

        public class Given_sudent_section_grade_fact_189889
        : When_querying_the_StudentSectionGradeFact_view
        {
            public Given_sudent_section_grade_fact_189889(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "189889";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_GradingPeriodKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_GradingPeriodKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSectionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_StudentSectionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_SectionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_SectionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_NumericGradeEarned()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_NumericGradeEarned.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LetterGradeEarned()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_LetterGradeEarned.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_GradeType()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_GradeType.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_sudent_section_grade_fact_189919
        : When_querying_the_StudentSectionGradeFact_view
        {
            public Given_sudent_section_grade_fact_189919(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "189919";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_GradingPeriodKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_GradingPeriodKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSectionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_StudentSectionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_SectionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_SectionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_NumericGradeEarned()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_NumericGradeEarned.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LetterGradeEarned_null()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_LetterGradeEarned_null.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_GradeType()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_GradeType.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_sudent_section_grade_fact_190966
        : When_querying_the_StudentSectionGradeFact_view
        {
            public Given_sudent_section_grade_fact_190966(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "190966";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_GradingPeriodKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_GradingPeriodKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSectionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_StudentSectionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_SectionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_SectionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_NumericGradeEarned_null()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_NumericGradeEarned_null.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LetterGradeEarned()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_LetterGradeEarned.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_GradeType()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_GradeType.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_sudent_section_grade_fact_189914
        : When_querying_the_StudentSectionGradeFact_view
        {
            public Given_sudent_section_grade_fact_189914(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "189914";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_GradingPeriodKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_GradingPeriodKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSectionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_StudentSectionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_SectionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_SectionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_NumericGradeEarned()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_NumericGradeEarned.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LetterGradeEarned()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_LetterGradeEarned.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_GradeType()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_GradeType.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
        public class Given_sudent_section_grade_fact_203451
        : When_querying_the_StudentSectionGradeFact_view
        {
            public Given_sudent_section_grade_fact_203451(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "203451";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_GradeType()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_GradeType.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
        public class Given_sudent_section_grade_fact_205689
       : When_querying_the_StudentSectionGradeFact_view
        {
            public Given_sudent_section_grade_fact_205689(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "205689";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_GradeType()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_GradeType.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
