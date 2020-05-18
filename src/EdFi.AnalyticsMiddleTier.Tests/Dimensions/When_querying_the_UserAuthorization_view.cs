// SPDX-License-Identifier: Apache-2.0
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
    public abstract class When_querying_the_UserAuthorization_view : When_querying_a_view
    {
        protected const string TestCasesFolder = "TestCases.UserAuthorization";

        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            DataStandard.PrepareDatabase();
        }

        [OneTimeSetUp]
        public void Act()
        {
            Result = DataStandard.LoadTestCaseData<StudentDataAuthorization>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.0000_UserAuthorization_Data_Load.xml");
            Result.success.ShouldBeTrue($"Error while loading data: '{Result.errorMessage}'");

            Result = DataStandard.Install(10, Component.RLS);
            Result.success.ShouldBeTrue($"Error while installing Base and RLS: '{Result.errorMessage}'");
        }


        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.0001_view_should_match_column_dictionary.json");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }


        public class Given_an_StaffEducationOrganizationAssignmentAssociation_that_has_already_ended
            : When_querying_the_UserAuthorization_view
        {
            public Given_an_StaffEducationOrganizationAssignmentAssociation_that_has_already_ended(TestHarness dataStandard) => SetDataStandard(dataStandard);

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
            public Given_an_AuthorizationScope_equal_to_Section_with_no_section_associated(TestHarness dataStandard) => SetDataStandard(dataStandard);

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
            public Given_an_StaffEducationOrganizationAssignmentAssociation_with_AuthorizationScope_equal_to_District(TestHarness dataStandard) => SetDataStandard(dataStandard);

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
        }


        public class Given_an_StaffEducationOrganizationAssignmentAssociation_with_AuthorizationScope_equal_to_School
            : When_querying_the_UserAuthorization_view
        {
            public Given_an_StaffEducationOrganizationAssignmentAssociation_with_AuthorizationScope_equal_to_School(TestHarness dataStandard) => SetDataStandard(dataStandard);

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
        }


        public class Given_an_StaffEducationOrganizationAssignmentAssociation_with_AuthorizationScope_equal_to_Section
            : When_querying_the_UserAuthorization_view
        {
            public Given_an_StaffEducationOrganizationAssignmentAssociation_with_AuthorizationScope_equal_to_Section(TestHarness dataStandard) => SetDataStandard(dataStandard);

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
        }


        public class Given_a_request_to_retrieve_a_specific_record
            : When_querying_the_UserAuthorization_view
        {
            public Given_a_request_to_retrieve_a_specific_record(TestHarness dataStandard) => SetDataStandard(dataStandard);

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
            public Given_all_existing_records_returned_by_the_view(TestHarness dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_StudentPermission_is_always_ALL()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserAuthorization>($"{TestCasesFolder}.querying_StudentPermission.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}