﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Common;
using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;

namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_SchoolDim_view_base : When_querying_a_view
    {
        protected const string TestCasesFolder = "TestCases.SchoolDim";

        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            DataStandard.PrepareDatabase();
        }

        [OneTimeSetUp]
        public void Act()
        {
            Result = DataStandard.LoadTestCaseData<SchoolDim>($"{TestCasesFolder}.{DataStandard}.0000_SchoolDim_Data_Load.xml");
            Result.success.ShouldBeTrue($"Error while loading data: '{Result.errorMessage}'");

            // Install the default map so that we can test for school address
            Result = DataStandard.Install(10);
            Result.success.ShouldBeTrue($"Error while installing Base: '{Result.errorMessage}'");
        }

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.0001_view_should_match_column_dictionary.json");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class When_querying_the_SchoolDim_view
            : When_querying_the_SchoolDim_view_base
        {
            public When_querying_the_SchoolDim_view(TestHarness dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.When_querying_specific_school.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_SchoolType_is_replaced_with_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SchoolDim>($"{TestCasesFolder}.When_SchoolType.CodeValue_is_null.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_SchoolAddress_is_replaced_with_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SchoolDim>($"{TestCasesFolder}.When_SchoolAddress.SchoolAddress_is_null.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_SchoolCity_is_replaced_with_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SchoolDim>($"{TestCasesFolder}.When_SchoolAddress.SchoolCity_is_null.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_SchoolCounty_is_replaced_with_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SchoolDim>($"{TestCasesFolder}.When_SchoolAddress.SchoolCounty_is_null.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_SchoolState_is_replaced_with_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SchoolDim>($"{TestCasesFolder}.When_SchoolAddress.SchoolState_is_null.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_LocalEducationAgencyName_is_replaced_with_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SchoolDim>($"{TestCasesFolder}.When_EdOrgLocal.NameOfInstitution_is_null.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_StateEducationAgencyName_is_replaced_with_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SchoolDim>($"{TestCasesFolder}.When_EdOrgState.NameOfInstitution_is_null.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_EducationServiceCenterName_is_replaced_with_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SchoolDim>($"{TestCasesFolder}.When_EdOrgServiceCenter.NameOfInstitution_is_null.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_the_SchoolAddress_returned_is_the_physical_address_and_not_mailing_address()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SchoolDim>($"{TestCasesFolder}.When_querying_SchoolAddress.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_LastModifiedDate_is_selected_from_EdOrgState_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SchoolDim>($"{TestCasesFolder}.When_EdOrgState_LastModifiedDate_is_max_date.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_LastModifiedDate_is_selected_from_EducationOrganization_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SchoolDim>($"{TestCasesFolder}.When_EducationOrganization_LastModifiedDate_is_max_date.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_LastModifiedDate_is_selected_from_ESchoolType_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SchoolDim>($"{TestCasesFolder}.When_SchoolType_LastModifiedDate_is_max_date.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_LastModifiedDate_is_selected_from_EdOrgLocal_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SchoolDim>($"{TestCasesFolder}.When_EdOrgLocal_LastModifiedDate_is_max_date.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_LastModifiedDate_is_selected_from_EdOrgServiceCenter_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SchoolDim>($"{TestCasesFolder}.When_EdOrgServiceCenter_LastModifiedDate_is_max_date.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_LastModifiedDate_is_selected_from_SchoolAddress_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SchoolDim>($"{TestCasesFolder}.When_SchoolAddress_LastModifiedDate_is_max_date.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_SchoolName_is_returned_properly()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SchoolDim>($"{TestCasesFolder}.When_querying_SchoolName.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_Schooltype_is_returned_properly()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SchoolDim>($"{TestCasesFolder}.When_querying_SchoolType.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_LocalEducationAgencyName_is_returned_properly()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SchoolDim>($"{TestCasesFolder}.When_querying_LocalEducationAgencyName.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_LocalEducationAgencyKey_is_returned_properly()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SchoolDim>($"{TestCasesFolder}.When_querying_LocalEducationAgencyKey.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_StateEducationAgencyName_is_returned_properly()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SchoolDim>($"{TestCasesFolder}.When_querying_StateEducationAgencyName.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_StateEducationAgencyKey_is_returned_properly()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SchoolDim>($"{TestCasesFolder}.When_querying_StateEducationAgencyKey.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_EducationServiceCenterName_is_returned_properly()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SchoolDim>($"{TestCasesFolder}.When_querying_EducationServiceCenterName.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_EducationServiceCenterKey_is_returned_properly()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SchoolDim>($"{TestCasesFolder}.When_querying_EducationServiceCenterKey.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_SchoolCity_is_returned_properly()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SchoolDim>($"{TestCasesFolder}.When_querying_SchoolCity.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_SchoolState_is_returned_properly()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SchoolDim>($"{TestCasesFolder}.When_querying_SchoolState.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_SchoolCounty_is_returned_properly()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SchoolDim>($"{TestCasesFolder}.When_querying_SchoolCounty.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_the_SchoolAddress_returned_is_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SchoolDim>($"{TestCasesFolder}.When_querying_SchoolAddress_with_Period_that_has_not_ended.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}