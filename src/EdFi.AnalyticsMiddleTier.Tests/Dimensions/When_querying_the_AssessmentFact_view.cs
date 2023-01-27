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
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.AssessmentFactTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_AssessmentFact_view : When_querying_a_view_postgres_ds3
    {
        protected const string TestCasesFolder = "TestCases.AssessmentFact";
        protected const string TestCasesDataFileName = "0000_AssessmentFact_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_AssessmentFact_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }
        [SetUpFixture]
        public class SetupAssessmentFactTestCase
            : When_querying_the_AssessmentFact_view
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<AssessmentFact>(TestCasesFolder, TestCasesDataFileName, Component.Asmt);
        }
        public class Given_assessment_2s3ch0knpb4val7uqve6mn269bavkdx2
        : When_querying_the_AssessmentFact_view
        {
            public Given_assessment_2s3ch0knpb4val7uqve6mn269bavkdx2(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "2s3ch0knpb4val7uqve6mn269bavkdx2";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_AssessmentFactKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AssessmentFactKey.xml");
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

            [Test]
            public void Then_should_have_LearningStandard_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LearningStandard_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_assessment_3s4ch0knpb4va28uqve6mn269bavkdx2
        : When_querying_the_AssessmentFact_view
        {
            public Given_assessment_3s4ch0knpb4va28uqve6mn269bavkdx2(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "3s4ch0knpb4va28uqve6mn269bavkdx2";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_AssessmentFactKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AssessmentFactKey.xml");
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
            [Test]
            public void Then_should_have_LearningStandard_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LearningStandard_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ObjectiveAssessmentKey_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ObjectiveAssessmentKey_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IdentificationCode_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IdentificationCode_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_assessment_3s4ch0knpb4va28uqve6mn269bavkdx3
        : When_querying_the_AssessmentFact_view
        {
            public Given_assessment_3s4ch0knpb4va28uqve6mn269bavkdx3(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "3s4ch0knpb4va28uqve6mn269bavkdx3";

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
            public Given_assessment_14707154_4B38_473B_8C74_14804BA75595(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "14707154_4B38_473B_8C74_14804BA75595";

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
            [Test]
            public void Then_should_have_LearningStandard()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LearningStandard.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_assessment_405F31A9_7F57_45C5_A3FC_941041D2C1D9
        : When_querying_the_AssessmentFact_view
        {
            public Given_assessment_405F31A9_7F57_45C5_A3FC_941041D2C1D9(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "405F31A9_7F57_45C5_A3FC_941041D2C1D9";

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
            [Test]
            public void Then_should_have_LearningStandard()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LearningStandard.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_assessment_C793689F_593D_4B92_85C9_B563A53B87CD
        : When_querying_the_AssessmentFact_view
        {
            public Given_assessment_C793689F_593D_4B92_85C9_B563A53B87CD(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "C793689F_593D_4B92_85C9_B563A53B87CD";

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
            public Given_assessment_C793689F_593D_4B92_85C9_B563A53B87CB(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "C793689F_593D_4B92_85C9_B563A53B87CB";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_assessment_MP_2013_Mathematics_Seventh_grade
        : When_querying_the_AssessmentFact_view
        {
            public Given_assessment_MP_2013_Mathematics_Seventh_grade(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "MP_2013_Mathematics_Seventh_grade";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_AssessedGradeLevel_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AssessedGradeLevel_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportingMethod_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportingMethod_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
