// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;
using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Common;
using CommonLib = EdFi.AnalyticsMiddleTier.Common;

namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_StudentAssessmentObjectiveFact_view : When_querying_a_view_ds3
    {
        protected const string TestCasesFolder = "TestCases.StudentAssessmentObjectiveFact";

        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
            {
                Assert.Ignore($"The StudentAssessmentObjectiveFact view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
            }
            else { 
                DataStandard.PrepareDatabase();
            }
        }

        [OneTimeSetUp]
        public void Act()
        {
            if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
            {
                Assert.Ignore(
                    $"The StudentAssessmentObjectiveFact view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
            }
            else
            {
                Result = DataStandard.LoadTestCaseData<StudentAssessmentObjectiveFact>(
                    $"{TestCasesFolder}.0000_StudentAssessmentObjectiveFact_Data_Load.xml");
                Result.success.ShouldBeTrue($"Error while loading data: '{Result.errorMessage}'");

                Result = DataStandard.Install(10, Component.Asmt);
                Result.success.ShouldBeTrue($"Error while installing Base and Asmt: '{Result.errorMessage}'");
            }
        }

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.0001_StudentAssessmentObjectiveFact_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        public class Given_assessment_MP_2013_Mathematics_Seventh_Grade_605213_255901044
        : When_querying_the_StudentAssessmentObjectiveFact_view
        {
            public Given_assessment_MP_2013_Mathematics_Seventh_Grade_605213_255901044(TestHarness dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "MP_2013_Mathematics_Seventh_Grade_605213_255901044";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentAssessmentObjectiveFact view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_AssessmentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentObjectiveFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AssessmentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentObjectiveAssessmentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentObjectiveFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentObjectiveAssessmentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentObjectiveFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentObjectiveFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentScore()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentObjectiveFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentScore.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ResultDataType()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentObjectiveFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ResultDataType.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportingMethod()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentObjectiveFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportingMethod.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            
            [Test]
            public void Then_should_have_PerformanceResult_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentObjectiveFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_PerformanceResult_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
        public class Given_assessment_MP_2013_Mathematics_Seventh_Grade_605215_255901044
        : When_querying_the_StudentAssessmentObjectiveFact_view
        {
            public Given_assessment_MP_2013_Mathematics_Seventh_Grade_605215_255901044(TestHarness dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "MP_2013_Mathematics_Seventh_Grade_605215_255901044";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentAssessmentObjectiveFact view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_PerformanceResult_Basic()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentObjectiveFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_PerformanceResult_Basic.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_assessment_MP_2013_Mathematics_Seventh_Grade_605213_255901001
            : When_querying_the_StudentAssessmentObjectiveFact_view
        {
            public Given_assessment_MP_2013_Mathematics_Seventh_Grade_605213_255901001(TestHarness dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "MP_2013_Mathematics_Seventh_Grade_605213_255901001";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentAssessmentObjectiveFact view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_not_return_any_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
