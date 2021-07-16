// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;

namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_LocalEducationAgencyDim_view : When_querying_a_view
    {
        protected const string TestCasesFolder = "TestCases.LocalEducationAgencyDim";

        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            DataStandard.PrepareDatabase();
        }

        [OneTimeSetUp]
        public void Act()
        {
            Result = DataStandard.LoadTestCaseData<LocalEducationAgencyDim>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.0000_LocalEducationAgencyDim_Data_Load.xml");
            Result.success.ShouldBeTrue($"Error while loading data: '{Result.errorMessage}'");

            Result = DataStandard.Install();
            Result.success.ShouldBeTrue($"Error while installing Base: '{Result.errorMessage}'");
        }

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.0001_LocalEducationAgencyDim_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        public class Given_grading_period_528530
            : When_querying_the_LocalEducationAgencyDim_view
        {
            public Given_grading_period_528530(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "528530";
            [Test]
            public void Then_should_return_one_record()
            {
               (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LocalEducationAgencyKey()
            {
               (bool success, string errorMessage) testResult = DataStandard.RunTestCase<LocalEducationAgencyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LocalEducationAgencyKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LocalEducationAgencyName()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<LocalEducationAgencyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LocalEducationAgencyName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LocalEducationAgencyType()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<LocalEducationAgencyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LocalEducationAgencyType.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LocalEducationAgencyServiceCenterName_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<LocalEducationAgencyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LocalEducationAgencyServiceCenterName_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LocalEducationAgencyServiceCenterKey_null()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<LocalEducationAgencyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LocalEducationAgencyServiceCenterKey_null.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<LocalEducationAgencyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LocalEducationAgencyParentLocalEducationAgencyKey_null()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<LocalEducationAgencyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LocalEducationAgencyParentLocalEducationAgencyKey_null.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LocalEducationAgencyStateEducationAgencyName_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<LocalEducationAgencyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LocalEducationAgencyStateEducationAgencyName_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LocalEducationAgencyStateEducationAgencyKey_null()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<LocalEducationAgencyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LocalEducationAgencyStateEducationAgencyKey_null.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LocalEducationAgencyCharterStatus_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<LocalEducationAgencyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LocalEducationAgencyCharterStatus_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_grading_period_628530
            : When_querying_the_LocalEducationAgencyDim_view
        {
            public Given_grading_period_628530(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "628530";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LocalEducationAgencyKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<LocalEducationAgencyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LocalEducationAgencyKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LocalEducationAgencyName()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<LocalEducationAgencyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LocalEducationAgencyName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LocalEducationAgencyType()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<LocalEducationAgencyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LocalEducationAgencyType.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LocalEducationAgencyServiceCenterName()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<LocalEducationAgencyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LocalEducationAgencyServiceCenterName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LocalEducationAgencyServiceCenterKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<LocalEducationAgencyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LocalEducationAgencyServiceCenterKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<LocalEducationAgencyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LocalEducationAgencyParentLocalEducationAgencyKey_null()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<LocalEducationAgencyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LocalEducationAgencyParentLocalEducationAgencyKey_null.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LocalEducationAgencyStateEducationAgencyName()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<LocalEducationAgencyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LocalEducationAgencyStateEducationAgencyName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LocalEducationAgencyStateEducationAgencyKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<LocalEducationAgencyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LocalEducationAgencyStateEducationAgencyKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LocalEducationAgencyCharterStatus()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<LocalEducationAgencyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LocalEducationAgencyCharterStatus.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_grading_period_628531
            : When_querying_the_LocalEducationAgencyDim_view
        {
            public Given_grading_period_628531(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "628531";

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<LocalEducationAgencyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
