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
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.UserAuthorizationTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_UserAuthorization_view : When_querying_a_view_postgres
    {
        protected const string TestCasesFolder = "TestCases.UserAuthorization";
        protected const string TestCasesDataFileName = "0000_UserAuthorization_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_view_should_match_column_dictionary.json");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [SetUpFixture]
        public class SetupUserAuthorizationTestCase
                : When_querying_the_UserAuthorization_view
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<UserAuthorization>(TestCasesFolder, TestCasesDataFileName, Component.RLS);
        }

        public class Given_an_StaffEducationOrganizationAssignmentAssociation_that_has_already_ended
            : When_querying_the_UserAuthorization_view
        {
            public Given_an_StaffEducationOrganizationAssignmentAssociation_that_has_already_ended(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_the_resulting_record_count_is_zero()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.querying_for_specific_record_with_association_that_has_already_ended.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }


        public class Given_an_AuthorizationScope_equal_to_Section_with_no_section_associated
            : When_querying_the_UserAuthorization_view
        {
            public Given_an_AuthorizationScope_equal_to_Section_with_no_section_associated(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_no_records_are_returned()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.querying_for_specific_record_with_UserScope_equal_to_Section_not_associated_to_a_Section.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }


        public class Given_an_StaffEducationOrganizationAssignmentAssociation_with_AuthorizationScope_equal_to_District
            : When_querying_the_UserAuthorization_view
        {
            public Given_an_StaffEducationOrganizationAssignmentAssociation_with_AuthorizationScope_equal_to_District(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_DistrictId_with_UserScope_equal_to_District_is_returned_properly()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserAuthorization>($"{TestCasesFolder}.querying_DistrictId_with_UserScope_equal_to_District.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_SchoolPermission_with_UserScope_equal_to_District_is_returned_properly()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserAuthorization>($"{TestCasesFolder}.querying_SchoolPermission_with_UserScope_equal_to_District.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_SectionPermission_with_UserScope_equal_to_District_is_returned_properly()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserAuthorization>($"{TestCasesFolder}.querying_SectionPermission_with_UserScope_equal_to_District.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_SectionKeyPermission_with_UserScope_equal_to_District_is_returned_properly()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserAuthorization>($"{TestCasesFolder}.querying_SectionKeyPermission_with_UserScope_equal_to_District.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

        }


        public class Given_an_StaffEducationOrganizationAssignmentAssociation_with_AuthorizationScope_equal_to_School
            : When_querying_the_UserAuthorization_view
        {
            public Given_an_StaffEducationOrganizationAssignmentAssociation_with_AuthorizationScope_equal_to_School(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_DistrictId_with_UserScope_equal_to_School_is_returned_properly()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserAuthorization>($"{TestCasesFolder}.querying_DistrictId_with_UserScope_equal_to_School.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_SchoolPermission_with_UserScope_equal_to_School_is_returned_properly()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserAuthorization>($"{TestCasesFolder}.querying_SchoolPermission_with_UserScope_equal_to_School.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_SectionPermission_with_UserScope_equal_to_School_is_returned_properly()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserAuthorization>($"{TestCasesFolder}.querying_SectionPermission_with_UserScope_equal_to_School.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_SectionKeyPermission_with_UserScope_equal_to_School_is_returned_properly()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserAuthorization>($"{TestCasesFolder}.querying_SectionKeyPermission_with_UserScope_equal_to_School.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }


        public class Given_an_StaffEducationOrganizationAssignmentAssociation_with_AuthorizationScope_equal_to_Section
            : When_querying_the_UserAuthorization_view
        {
            public Given_an_StaffEducationOrganizationAssignmentAssociation_with_AuthorizationScope_equal_to_Section(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_DistrictId_with_UserScope_equal_to_Section_is_returned_properly()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserAuthorization>($"{TestCasesFolder}.querying_DistrictId_with_UserScope_equal_to_Section.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_SchoolPermission_with_UserScope_equal_to_Section_is_returned_properly()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserAuthorization>($"{TestCasesFolder}.querying_SchoolPermission_with_UserScope_equal_to_Section.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_SectionPermission_with_UserScope_equal_to_Section_is_returned_properly()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserAuthorization>($"{TestCasesFolder}.querying_SectionPermission_with_UserScope_equal_to_Section.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_SectionPermission_with_UserScope_equal_to_SectionKey_is_returned_properly()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserAuthorization>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.querying_SectionPermission_should_have_SectionKeyPermission.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }


        public class Given_a_request_to_retrieve_a_specific_record
            : When_querying_the_UserAuthorization_view
        {
            public Given_a_request_to_retrieve_a_specific_record(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_SectionPermission_is_correct_with_UserKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserAuthorization>($"{TestCasesFolder}.querying_for_specific_record_with_UserKey_equal_to_11606.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_SectionPermission_is_correct_with_SchoolPermission()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserAuthorization>($"{TestCasesFolder}.querying_for_specific_record_with_School_equal_to_867530067.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }


        public class Given_all_existing_records_returned_by_the_view
            : When_querying_the_UserAuthorization_view
        {
            public Given_all_existing_records_returned_by_the_view(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_StudentPermission_is_always_ALL()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserAuthorization>($"{TestCasesFolder}.querying_StudentPermission.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
