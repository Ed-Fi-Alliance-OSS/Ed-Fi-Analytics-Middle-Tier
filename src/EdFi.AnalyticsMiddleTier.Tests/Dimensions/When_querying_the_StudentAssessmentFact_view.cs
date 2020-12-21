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
    public abstract class When_querying_the_StudentAssessmentFact_view : When_querying_a_view_ds3
    {
        protected const string TestCasesFolder = "TestCases.StudentAssessmentFact";

        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            DataStandard.PrepareDatabase();
        }

        [OneTimeSetUp]
        public void Act()
        {
            Result = DataStandard.LoadTestCaseData<StudentAssessmentFact>($"{TestCasesFolder}.0000_StudentAssessmentFact_Data_Load.xml");
            Result.success.ShouldBeTrue($"Error while loading data: '{Result.errorMessage}'");

            Result = DataStandard.Install(10, Component.Asmt);
            Result.success.ShouldBeTrue($"Error while installing Base and Asmt: '{Result.errorMessage}'");
        }

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.0001_StudentAssessmentFact_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        public class Given_student_assessment_fact_04556570_B715_6D8E_5E86_008A72ECE446_2009_04_01
        : When_querying_the_StudentAssessmentFact_view
        {
            public Given_student_assessment_fact_04556570_B715_6D8E_5E86_008A72ECE446_2009_04_01(TestHarness dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "04556570_B715_6D8E_5E86_008A72ECE446_2009_04_01";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentAssessmentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentAssessmentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_AssessmentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AssessmentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_AdministrationDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AdministrationDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentScore()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentScore.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_ResultDataType()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ResultDataType.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportingMethod()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportingMethod.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_PerformanceResult()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_PerformanceResult.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
