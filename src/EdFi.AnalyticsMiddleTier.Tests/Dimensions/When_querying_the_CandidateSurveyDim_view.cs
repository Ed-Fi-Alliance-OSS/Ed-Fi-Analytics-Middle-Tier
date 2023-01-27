// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Tests.Classes;
using EdFi.AnalyticsMiddleTier.Common;
using NUnit.Framework;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.CandidateSurveyDimTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_CandidateSurveyDim_view : When_querying_a_view_ds3_3
    {
        protected const string TestCasesFolder = "TestCases.CandidateSurveyDim";
        protected const string TestCasesDataFileName = "0000_CandidateSurveyDim_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_view_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [SetUpFixture]
        public class SetupCandidateSurveyDimTestCase
            : When_querying_the_CandidateSurveyDim_view
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<CandidateSurveyDim>(TestCasesFolder, TestCasesDataFileName, Component.EPP);
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_SurveyCandidateIdentifier_1000006906_TBMS4_1
        : When_querying_the_CandidateSurveyDim_view
        {
            public Given_SurveyCandidateIdentifier_1000006906_TBMS4_1(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "1000006906_TBMS4_1";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_CandidateSurveyKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateSurveyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_CandidateSurveyKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_CandidateKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateSurveyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_CandidateKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_NumericResponse_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateSurveyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_NumericResponse_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_QuestionCode()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateSurveyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_QuestionCode.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_QuestionText()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateSurveyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_QuestionText.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ResponseDateKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateSurveyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ResponseDateKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SurveySectionTitle()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateSurveyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_SurveySectionTitle.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SurveyTitle()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateSurveyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_SurveyTitle.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_TextResponse()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateSurveyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_TextResponse.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateSurveyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_SurveyCandidateIdentifier_1000006906_TBMS4_2
            : When_querying_the_CandidateSurveyDim_view
        {
            public Given_SurveyCandidateIdentifier_1000006906_TBMS4_2(TestHarnessBase dataStandard) =>
                SetDataStandard(dataStandard);

            private readonly string _caseIdentifier = "1000006906_TBMS4_2";

            [Test]
            public void Then_should_have_TextResponse_Empty()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CandidateSurveyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_TextResponse_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateSurveyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_SurveyCandidateIdentifier_1000001359_TBMS4_1
            : When_querying_the_CandidateSurveyDim_view
        {
            public Given_SurveyCandidateIdentifier_1000001359_TBMS4_1(TestHarnessBase dataStandard) =>
                SetDataStandard(dataStandard);

            private readonly string _caseIdentifier = "1000001359_TBMS4_1";

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateSurveyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_SurveyCandidateIdentifier_1000006906_4083
            : When_querying_the_CandidateSurveyDim_view
        {
            public Given_SurveyCandidateIdentifier_1000006906_4083(TestHarnessBase dataStandard) =>
                SetDataStandard(dataStandard);

            private readonly string _caseIdentifier = "1000006906_4083";

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateSurveyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_SurveyCandidateIdentifier_1000001308_TBMS4_1
            : When_querying_the_CandidateSurveyDim_view
        {
            public Given_SurveyCandidateIdentifier_1000001308_TBMS4_1(TestHarnessBase dataStandard) =>
                SetDataStandard(dataStandard);

            private readonly string _caseIdentifier = "1000001308_TBMS4_1";

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateSurveyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
