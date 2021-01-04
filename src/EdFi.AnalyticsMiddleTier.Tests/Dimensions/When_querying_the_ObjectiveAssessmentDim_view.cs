// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;
using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Common;
using CommonLib = EdFi.AnalyticsMiddleTier.Common;

namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_ObjectiveAssessmentDim_view : When_querying_a_view_ds3
    {
        protected const string TestCasesFolder = "TestCases.ObjectiveAssessmentDim";

        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
            {
                Assert.Ignore($"The ObjectiveAssessmentDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
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
                    $"The ObjectiveAssessmentDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
            }
            else
            {
                Result = DataStandard.LoadTestCaseData<ObjectiveAssessmentDim>(
                    $"{TestCasesFolder}.{DataStandard.CurrentDataStandardFolderName}.0000_ObjectiveAssessmentDim_Data_Load.xml");
                Result.success.ShouldBeTrue($"Error while loading data: '{Result.errorMessage}'");

                Result = DataStandard.Install(10, Component.Asmt);
                Result.success.ShouldBeTrue($"Error while installing Base and Asmt: '{Result.errorMessage}'");
            }
        }

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.CurrentDataStandardFolderName}.0001_ObjectiveAssessmentDim_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        public class Given_assessment_14707154_4B38_473B_8C74_14804BA75595
        : When_querying_the_ObjectiveAssessmentDim_view
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
            public void Then_should_have_AssessmentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ObjectiveAssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AssessmentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_AcademicSubject()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds31))
                {
                    (bool success, string errorMessage) testResult = (true,String.Empty);
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
                else
                {
                    (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ObjectiveAssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AcademicSubject.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
            }

            [Test]
            public void Then_should_have_Description()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ObjectiveAssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_Description.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IdentificationCode()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ObjectiveAssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IdentificationCode.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_Namespace()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ObjectiveAssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_Namespace.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ObjectiveAssessmentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ObjectiveAssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ObjectiveAssessmentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ParentObjectiveAssessmentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ObjectiveAssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ParentObjectiveAssessmentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_PercentOfAssessment()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ObjectiveAssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_PercentOfAssessment.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_MaxScore()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ObjectiveAssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_MaxScore.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_MinScore()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ObjectiveAssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_MinScore.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_assessment_405F31A9_7F57_45C5_A3FC_941041D2C1D9
        : When_querying_the_ObjectiveAssessmentDim_view
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
            public void Then_should_have_AssessmentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ObjectiveAssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AssessmentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_AcademicSubject_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ObjectiveAssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AcademicSubject_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_Description_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ObjectiveAssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_Description_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IdentificationCode()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ObjectiveAssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IdentificationCode.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_Namespace()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ObjectiveAssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_Namespace.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ObjectiveAssessmentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ObjectiveAssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ObjectiveAssessmentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ParentObjectiveAssessmentKey_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ObjectiveAssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ParentObjectiveAssessmentKey_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_PercentOfAssessment_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ObjectiveAssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_PercentOfAssessment_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_MaxScore_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ObjectiveAssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_MaxScore_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_MinScore_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ObjectiveAssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_MinScore_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
