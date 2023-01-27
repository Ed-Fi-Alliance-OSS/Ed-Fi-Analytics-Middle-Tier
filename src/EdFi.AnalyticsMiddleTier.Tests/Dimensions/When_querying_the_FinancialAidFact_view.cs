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
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.FinancialAidFactTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_FinancialAidFact_view : When_querying_a_view_ds3_3
    {
        protected const string TestCasesFolder = "TestCases.FinancialAidFact";
        protected const string TestCasesDataFileName = "0000_FinancialAidFact_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_view_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [SetUpFixture]
        public class SetupFinancialAidFactTestCase
            : When_querying_the_FinancialAidFact_view
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<FinancialAidFact>(TestCasesFolder, TestCasesDataFileName, Component.EPP);
        }
        public class Given_FinancialAid_1000045
        : When_querying_the_FinancialAidFact_view
        {
            public Given_FinancialAid_1000045(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "1000045";

            [Test]
            public void Then_should_have_CandidateAidKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<FinancialAidFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_CandidateAidKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_AidAmount()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<FinancialAidFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AidAmount.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_AidConditionDescription()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<FinancialAidFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AidConditionDescription.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_AidType()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<FinancialAidFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AidType.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_BeginDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<FinancialAidFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_BeginDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_CandidateKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<FinancialAidFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_CandidateKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_PellGrantRecipient()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<FinancialAidFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_PellGrantRecipient.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_LastModifiedDate_FinancialAid()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<FinancialAidFact>($"{TestCasesFolder}.{_caseIdentifier}_LastModifiedDate_FinancialAid.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

        }


        public class Given_FinancialAid_1000049
        : When_querying_the_FinancialAidFact_view
        {
            public Given_FinancialAid_1000049(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "1000049";

            [Test]
            public void Then_should_have_EndDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<FinancialAidFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_EndDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_AidAmount_should_be_zero()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<FinancialAidFact>($"{TestCasesFolder}.{_caseIdentifier}_AidAmount_should_be_zero.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_AidConditionDescription_should_be_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<FinancialAidFact>($"{TestCasesFolder}.{_caseIdentifier}_AidConditionDescription_should_be_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_PellGrantRecipient_should_be_zero()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<FinancialAidFact>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.{_caseIdentifier}_PellGrantRecipient_should_be_zero.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_LastModifiedDate_Candidate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<FinancialAidFact>($"{TestCasesFolder}.{_caseIdentifier}_LastModifiedDate_Candidate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

        }

    }
}
