// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.AnalyticsMiddleTier.Common;
using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;
using System;
using System.Diagnostics.CodeAnalysis;
using CommonLib = EdFi.AnalyticsMiddleTier.Common;

namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_AssessmentFact_view : When_querying_a_view_ds3
    {
        protected const string TestCasesFolder = "TestCases.AssessmentFact";

        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
            {
                Assert.Ignore($"The AssessmentFact view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
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
                    $"The AssessmentFact view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
            }
            else
            {
                Result = DataStandard.LoadTestCaseData<AssessmentFact>(
                    $"{TestCasesFolder}.{DataStandard.CurrentDataStandardFolderName}.0000_AssessmentFact_Data_Load.xml");
                Result.success.ShouldBeTrue($"Error while loading data: '{Result.errorMessage}'");

                // rls_AssessmentFact depends on Email.Work constant; for testing we can rely on DefaultMap to populate a value.
                Result = DataStandard.Install(10, Component.Asmt);
                Result.success.ShouldBeTrue($"Error while installing Base and Asmt: '{Result.errorMessage}'");
            }
        }

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.0001_AssessmentFact_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        public class Given_assessment_2s3ch0knpb4val7uqve6mn269bavkdx2
        : When_querying_the_AssessmentFact_view
        {
            public Given_assessment_2s3ch0knpb4val7uqve6mn269bavkdx2(TestHarness dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "2s3ch0knpb4val7uqve6mn269bavkdx2";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The AssessmentFact view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
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
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AssessmentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_AssessmentIdentifier()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AssessmentIdentifier.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_Namespace()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_Namespace.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_AssessedGradeLevel()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AssessedGradeLevel.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_Category()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_Category.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ResultDataType()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ResultDataType.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportingMethod()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportingMethod.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_MaxScore()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_MaxScore.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_MinScore()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_MinScore.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_Title()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_Title.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_Version()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_Version.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            
            [Test]
            public void Then_should_have_AcademicSubject()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AcademicSubject.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_assessment_3s4ch0knpb4va28uqve6mn269bavkdx2
        : When_querying_the_AssessmentFact_view
        {
            public Given_assessment_3s4ch0knpb4va28uqve6mn269bavkdx2(TestHarness dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "3s4ch0knpb4va28uqve6mn269bavkdx2";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The AssessmentFact view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
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
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AssessmentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_AssessmentIdentifier()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AssessmentIdentifier.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_MaxScore_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_MaxScore_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_MinScore_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_MinScore_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_Version_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_Version_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_Category_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_Category_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_AcademicSubject_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AcademicSubject_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ResultDataType_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ResultDataType_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportingMethod()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportingMethod.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_assessment_3s4ch0knpb4va28uqve6mn269bavkdx3
        : When_querying_the_AssessmentFact_view
        {
            public Given_assessment_3s4ch0knpb4va28uqve6mn269bavkdx3(TestHarness dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "3s4ch0knpb4va28uqve6mn269bavkdx3";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The AssessmentFact view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_assessment_14707154_4B38_473B_8C74_14804BA75595
        : When_querying_the_AssessmentFact_view
        {
            public Given_assessment_14707154_4B38_473B_8C74_14804BA75595(TestHarness dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "14707154_4B38_473B_8C74_14804BA75595";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The ObjectiveAssessmentDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ObjectiveAssessmentDescription()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ObjectiveAssessmentDescription.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IdentificationCode()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IdentificationCode.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ObjectiveAssessmentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ObjectiveAssessmentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ParentObjectiveAssessmentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ParentObjectiveAssessmentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_PercentOfAssessment()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_PercentOfAssessment.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_MaxScore()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_MaxScore.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_MinScore()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_MinScore.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ResultDataType()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ResultDataType.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportingMethod()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportingMethod.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_assessment_405F31A9_7F57_45C5_A3FC_941041D2C1D9
        : When_querying_the_AssessmentFact_view
        {
            public Given_assessment_405F31A9_7F57_45C5_A3FC_941041D2C1D9(TestHarness dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "405F31A9_7F57_45C5_A3FC_941041D2C1D9";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The ObjectiveAssessmentDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ObjectiveAssessmentDescription_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ObjectiveAssessmentDescription_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IdentificationCode()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IdentificationCode.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ObjectiveAssessmentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ObjectiveAssessmentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ParentObjectiveAssessmentKey_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ParentObjectiveAssessmentKey_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_PercentOfAssessment_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_PercentOfAssessment_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_MaxScore_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_MaxScore_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_MinScore_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_MinScore_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_assessment_C793689F_593D_4B92_85C9_B563A53B87CD
        : When_querying_the_AssessmentFact_view
        {
            public Given_assessment_C793689F_593D_4B92_85C9_B563A53B87CD(TestHarness dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "C793689F_593D_4B92_85C9_B563A53B87CD";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The ObjectiveAssessmentDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_have_MaxScore()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_MaxScore.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_MinScore()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_MinScore.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_assessment_C793689F_593D_4B92_85C9_B563A53B87CB
        : When_querying_the_AssessmentFact_view
        {
            public Given_assessment_C793689F_593D_4B92_85C9_B563A53B87CB(TestHarness dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "C793689F_593D_4B92_85C9_B563A53B87CB";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The ObjectiveAssessmentDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
