// SPDX-License-Identifier: Apache-2.0
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
    public abstract class When_querying_the_StudentSectionGradeFact_view : When_querying_a_view
    {
        protected const string TestCasesFolder = "TestCases.StudentSectionGradeFact";

        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            DataStandard.PrepareDatabase();
        }

        [OneTimeSetUp]
        public void Act()
        {
            Result = DataStandard.LoadTestCaseData<StudentSectionGradeFact>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.0000_StudentSectionGradeFact_Data_Load.xml");
            Result.success.ShouldBeTrue($"Error while loading data: '{Result.errorMessage}'");

            Result = DataStandard.Install(10, Component.Ews);
            Result.success.ShouldBeTrue($"Error while installing Base and EWS: '{Result.errorMessage}'");
        }

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.0001_StudentSectionGradeFact_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        public class Given_sudent_section_grade_fact_189889
        : When_querying_the_StudentSectionGradeFact_view
        {
            public Given_sudent_section_grade_fact_189889(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "189889";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_GradingPeriodKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_GradingPeriodKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSectionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_StudentSectionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_SectionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_SectionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_NumericGradeEarned()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_NumericGradeEarned.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LetterGradeEarned()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_LetterGradeEarned.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_GradeType()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_GradeType.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_sudent_section_grade_fact_189919
        : When_querying_the_StudentSectionGradeFact_view
        {
            public Given_sudent_section_grade_fact_189919(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "189919";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_GradingPeriodKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_GradingPeriodKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSectionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_StudentSectionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_SectionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_SectionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_NumericGradeEarned()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_NumericGradeEarned.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LetterGradeEarned_null()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_LetterGradeEarned_null.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_GradeType()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_GradeType.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_sudent_section_grade_fact_190966
        : When_querying_the_StudentSectionGradeFact_view
        {
            public Given_sudent_section_grade_fact_190966(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "190966";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_GradingPeriodKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_GradingPeriodKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSectionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_StudentSectionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_SectionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_SectionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_NumericGradeEarned_null()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_NumericGradeEarned_null.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LetterGradeEarned()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_LetterGradeEarned.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_GradeType()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_GradeType.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_sudent_section_grade_fact_189914
        : When_querying_the_StudentSectionGradeFact_view
        {
            public Given_sudent_section_grade_fact_189914(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "189914";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_GradingPeriodKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_GradingPeriodKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSectionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_StudentSectionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_SectionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_SectionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_NumericGradeEarned()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_NumericGradeEarned.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LetterGradeEarned()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_LetterGradeEarned.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_GradeType()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_GradeType.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
        public class Given_sudent_section_grade_fact_203451
        : When_querying_the_StudentSectionGradeFact_view
        {
            public Given_sudent_section_grade_fact_203451(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "203451";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_GradeType()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_GradeType.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
        public class Given_sudent_section_grade_fact_205689
       : When_querying_the_StudentSectionGradeFact_view
        {
            public Given_sudent_section_grade_fact_205689(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "205689";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_GradeType()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSectionGradeFact>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_GradeType.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
