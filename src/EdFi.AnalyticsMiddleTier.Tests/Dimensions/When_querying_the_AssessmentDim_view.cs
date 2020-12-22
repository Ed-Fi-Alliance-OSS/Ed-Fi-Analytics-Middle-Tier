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
    public abstract class When_querying_the_AssessmentDim_view : When_querying_a_view_ds3
    {
        protected const string TestCasesFolder = "TestCases.AssessmentDim";

        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
            {
                Assert.Ignore($"The AssessmentDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
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
                    $"The AssessmentDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
            }
            else
            {
                Result = DataStandard.LoadTestCaseData<AssessmentDim>(
                    $"{TestCasesFolder}.0000_AssessmentDim_Data_Load.xml");
                Result.success.ShouldBeTrue($"Error while loading data: '{Result.errorMessage}'");

                // rls_AssessmentDim depends on Email.Work constant; for testing we can rely on DefaultMap to populate a value.
                Result = DataStandard.Install(10, Component.Asmt);
                Result.success.ShouldBeTrue($"Error while installing Base and Asmt: '{Result.errorMessage}'");
            }
        }

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.0001_AssessmentDim_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        public class Given_assessment_2s3ch0knpb4val7uqve6mn269bavkdx2
        : When_querying_the_AssessmentDim_view
        {
            public Given_assessment_2s3ch0knpb4val7uqve6mn269bavkdx2(TestHarness dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "2s3ch0knpb4val7uqve6mn269bavkdx2";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The AssessmentDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
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
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AssessmentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_AssessedGradeLevel()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AssessedGradeLevel.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_Category()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_Category.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_MaxScore()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_MaxScore.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_MinScore()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_MinScore.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_Title()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_Title.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_Version()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_Version.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_assessment_3s4ch0knpb4va28uqve6mn269bavkdx2
        : When_querying_the_AssessmentDim_view
        {
            public Given_assessment_3s4ch0knpb4va28uqve6mn269bavkdx2(TestHarness dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "3s4ch0knpb4va28uqve6mn269bavkdx2";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The AssessmentDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
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
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AssessmentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            
            [Test]
            public void Then_should_have_MaxScore_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_MaxScore_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_MinScore_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_MinScore_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_Version_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AssessmentDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_Version_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
