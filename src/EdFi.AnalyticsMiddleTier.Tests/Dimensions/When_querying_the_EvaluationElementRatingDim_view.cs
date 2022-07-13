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
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.EvaluationElementRatingDimTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_EvaluationElementRatingDim_View : When_querying_a_view_ds3_3
    {
        protected const string TestCasesFolder = "TestCases.EvaluationElementRatingDim";
        protected const string TestCasesDataFileName = "0000_EvaluationElementRatingDim_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_view_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [SetUpFixture]
        public class SetupEvaluationElementRatingDimTestCase
            : When_querying_the_EvaluationElementRatingDim_View
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<EvaluationElementRatingDim>(TestCasesFolder, TestCasesDataFileName, Component.EPP);
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_candidatekey_1000048
        : When_querying_the_EvaluationElementRatingDim_View
        {
            public Given_candidatekey_1000048(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "c1000048";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_CandidateKey_should_be_1000048()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<EvaluationElementRatingDim>($"{TestCasesFolder}.{_caseIdentifier}_CandidateKey_should_be_1000048.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_EvaluationDate_should_be_2011_11_01()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<EvaluationElementRatingDim>($"{TestCasesFolder}.{_caseIdentifier}_EvaluationDate_should_be_2011_11_01.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_EvaluationElementTitle_should_be_adddress_misconceptions()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<EvaluationElementRatingDim>($"{TestCasesFolder}.{_caseIdentifier}_EvaluationElementTitle_should_be_adddress_misconceptions.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_EvaluationObjectiveTitle_should_be_adddress_misconceptions()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<EvaluationElementRatingDim>($"{TestCasesFolder}.{_caseIdentifier}_EvaluationObjectiveTitle_should_be_adddress_misconceptions.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_PerformanceEvaluationTitle_should_be_Formal_Evaluation()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<EvaluationElementRatingDim>($"{TestCasesFolder}.{_caseIdentifier}_PerformanceEvaluationTitle_should_be_Formal_Evaluation.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_Rating_should_be_61()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<EvaluationElementRatingDim>($"{TestCasesFolder}.{_caseIdentifier}_Rating_should_be_61.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_RatingResultTitle_should_be_Effective()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<EvaluationElementRatingDim>($"{TestCasesFolder}.{_caseIdentifier}_RatingResultTitle_should_be_Effective.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_LastModifiedDate_should_be_2021_11_10()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<EvaluationElementRatingDim>($"{TestCasesFolder}.{_caseIdentifier}_LastModifiedDate_should_be_2021_11_10.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_candidatekey_1000049
        : When_querying_the_EvaluationElementRatingDim_View
        {
            public Given_candidatekey_1000049(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "c1000049";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_CandidateKey_should_be_1000049()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<EvaluationElementRatingDim>($"{TestCasesFolder}.{_caseIdentifier}_CandidateKey_should_be_1000049.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_LastModifiedDate_should_be_2022_10_10()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<EvaluationElementRatingDim>($"{TestCasesFolder}.{_caseIdentifier}_LastModifiedDate_should_be_2022_10_10.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
