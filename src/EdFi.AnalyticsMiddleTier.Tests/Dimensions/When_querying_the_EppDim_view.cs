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
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.EppDimTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_EppDim_View : When_querying_a_view_ds3_3
    {
        protected const string TestCasesFolder = "TestCases.EppDim";
        protected const string TestCasesDataFileName = "0000_EppDim_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_view_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [SetUpFixture]
        public class SetupEppDimTestCase
            : When_querying_the_EppDim_View
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<EppDim>(TestCasesFolder, TestCasesDataFileName, Component.EPP);
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_educationOrganizationKey_5
        : When_querying_the_EppDim_View
        {
            public Given_educationOrganizationKey_5(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "eo5";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_EducationOrganizationKey_should_be_5()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<EppDim>($"{TestCasesFolder}.{_caseIdentifier}_EducationOrganizationKey_should_be_5.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_NameOfInstitution_should_be_UT_Austin_College()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<EppDim>($"{TestCasesFolder}.{_caseIdentifier}_NameOfInstitution_should_be_UT_Austin_College.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_LastModifiedDate_should_be_2021_11_05()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<EppDim>($"{TestCasesFolder}.{_caseIdentifier}_LastModifiedDate_should_be_2021_11_05.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_educationOrganizationKey_6
        : When_querying_the_EppDim_View
        {
            public Given_educationOrganizationKey_6(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "eo6";

            [Test]
            public void Then_should_return_no_records()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_no_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
