// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.LocalEducationAgencyDimTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_LocalEducationAgencyDim_view : When_querying_a_view_postgres
    {
        protected const string TestCasesFolder = "TestCases.LocalEducationAgencyDim";
        protected const string TestCasesDataFileName = "0000_LocalEducationAgencyDim_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_LocalEducationAgencyDim_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }
        [SetUpFixture]
        public class SetupAcademicTimePeriodDimTestCase
            : When_querying_the_LocalEducationAgencyDim_view
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<LocalEducationAgencyDim>(TestCasesFolder, TestCasesDataFileName);
        }
        public class Given_grading_period_528530
            : When_querying_the_LocalEducationAgencyDim_view
        {
            public Given_grading_period_528530(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "528530";
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
            private readonly string _caseIdentifier = "628530";
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
            private readonly string _caseIdentifier = "628531";

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<LocalEducationAgencyDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
