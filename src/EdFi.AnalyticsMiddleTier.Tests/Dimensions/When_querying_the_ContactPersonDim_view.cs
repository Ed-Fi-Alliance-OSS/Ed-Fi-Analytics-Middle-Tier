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
    public abstract class When_querying_the_ContactPersonDim_view : When_querying_a_view
    {
        protected const string TestCasesFolder = "TestCases.ContactPersonDim";

        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            DataStandard.PrepareDatabase();
        }

        [OneTimeSetUp]
        public void Act()
        {
            Result = DataStandard.LoadTestCaseData<ContactPersonDim>($"{TestCasesFolder}.{DataStandard}.0000_ContactPersonDim_Data_Load.xml");
            Result.success.ShouldBeTrue($"Error while loading data: '{Result.errorMessage}'");

            Result = DataStandard.Install();
            Result.success.ShouldBeTrue($"Error while installing Base: '{Result.errorMessage}'");
        }

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.0001_ContactPersonDim_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        public class Given_contact_person_132500_189856
            : When_querying_the_ContactPersonDim_view
        {
            public Given_contact_person_132500_189856(TestHarness dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "132500_189856";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_UniqueKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<ContactPersonDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_UniqueKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ContactFirstName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<ContactPersonDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactFirstName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ContactHomeAddress()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<ContactPersonDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactHomeAddress.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ContactLastName()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactLastName.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }

            [Test]
            public void Then_should_have_ContactMailingAddress_empty()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactMailingAddress_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_ContactPersonKey()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactPersonKey.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_ContactPhysicalAddress_empty()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactPhysicalAddress_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_ContactPriority_0()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactPriority_0.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_ContactRestrictions_empty()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactRestrictions_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_ContactTemporaryAddress_empty()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactTemporaryAddress_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_ContactWorkAddress_empty()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactWorkAddress_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }

            [Test]
            public void Then_should_have_HomePhoneNumber()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_HomePhoneNumber.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_IsEmergencyContact_0()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsEmergencyContact_0.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_IsPrimaryContact_0()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPrimaryContact_0.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_MobilePhoneNumber_empty()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_MobilePhoneNumber_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_PersonalEmailAddress()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_PersonalEmailAddress.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_RelationshipToStudent()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_RelationshipToStudent.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentKey()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentLivesWith_0()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentLivesWith_0.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_WorkEmailAddress_empty()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_WorkEmailAddress_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_WorkPhoneNumber()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_WorkPhoneNumber.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_not_have_PrimaryEmailAddress()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_not_have_PrimaryEmailAddress.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
        }

        public class Given_contact_person_133012_190142
            : When_querying_the_ContactPersonDim_view
        {
            public Given_contact_person_133012_190142(TestHarness dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "133012_190142";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_UniqueKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<ContactPersonDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_UniqueKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ContactFirstName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<ContactPersonDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactFirstName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ContactHomeAddress()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<ContactPersonDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactHomeAddress.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ContactLastName()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactLastName.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }

            [Test]
            public void Then_should_have_ContactMailingAddress()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactMailingAddress.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_ContactPersonKey()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactPersonKey.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_ContactPhysicalAddress()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactPhysicalAddress.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_ContactPriority_0()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactPriority_0.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_ContactRestrictions()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactRestrictions.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_ContactTemporaryAddress()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactTemporaryAddress.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_ContactWorkAddress()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactWorkAddress.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }

            [Test]
            public void Then_should_have_HomePhoneNumber_empty()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_HomePhoneNumber_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_IsEmergencyContact_0()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsEmergencyContact_0.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_IsPrimaryContact_1()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPrimaryContact_1.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_MobilePhoneNumber_empty()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_MobilePhoneNumber_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_PersonalEmailAddress()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_PersonalEmailAddress.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_RelationshipToStudent()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_RelationshipToStudent.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentKey()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentLivesWith_1()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentLivesWith_1.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_WorkEmailAddress_empty()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_WorkEmailAddress_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_WorkPhoneNumber()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_WorkPhoneNumber.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_PrimaryEmailAddress()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_PrimaryEmailAddress.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
        }

        public class Given_contact_person_154283_189864
            : When_querying_the_ContactPersonDim_view
        {
            public Given_contact_person_154283_189864(TestHarness dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "154283_189864";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_UniqueKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<ContactPersonDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_UniqueKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ContactFirstName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<ContactPersonDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactFirstName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ContactHomeAddress_empty()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<ContactPersonDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactHomeAddress_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ContactLastName()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactLastName.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }

            [Test]
            public void Then_should_have_ContactMailingAddress_empty()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactMailingAddress_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_ContactPersonKey()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactPersonKey.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_ContactPhysicalAddress_empty()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactPhysicalAddress_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_ContactPriority_0()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactPriority_0.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_ContactRestrictions_empty()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactRestrictions_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_ContactTemporaryAddress_empty()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactTemporaryAddress_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_ContactWorkAddress_empty()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactWorkAddress_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }

            [Test]
            public void Then_should_have_HomePhoneNumber_empty()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_HomePhoneNumber_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_IsEmergencyContact_0()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsEmergencyContact_0.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_IsPrimaryContact_0()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPrimaryContact_0.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_MobilePhoneNumber()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_MobilePhoneNumber.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_PersonalEmailAddress_empty()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_PersonalEmailAddress_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_RelationshipToStudent()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_RelationshipToStudent.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentKey()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentLivesWith_0()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentLivesWith_0.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_WorkEmailAddress_empty()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_WorkEmailAddress_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_WorkPhoneNumber_empty()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_WorkPhoneNumber_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_not_have_PrimaryEmailAddress()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_not_have_PrimaryEmailAddress.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
        }

        public class Given_contact_person_156809_231203
            : When_querying_the_ContactPersonDim_view
        {
            public Given_contact_person_156809_231203(TestHarness dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "156809_231203";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_UniqueKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<ContactPersonDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_UniqueKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ContactFirstName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<ContactPersonDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactFirstName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ContactHomeAddress()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<ContactPersonDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactHomeAddress.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ContactLastName()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactLastName.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }

            [Test]
            public void Then_should_have_ContactMailingAddress_empty()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactMailingAddress_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_ContactPersonKey()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactPersonKey.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_ContactPhysicalAddress_empty()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactPhysicalAddress_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_ContactPriority_0()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactPriority_0.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_ContactRestrictions_empty()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactRestrictions_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_ContactTemporaryAddress_empty()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactTemporaryAddress_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_ContactWorkAddress_empty()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ContactWorkAddress_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }

            [Test]
            public void Then_should_have_HomePhoneNumber()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_HomePhoneNumber.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_IsEmergencyContact_0()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsEmergencyContact_0.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_IsPrimaryContact_1()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_IsPrimaryContact_1.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_MobilePhoneNumber_empty()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_MobilePhoneNumber_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_PersonalEmailAddress()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_PersonalEmailAddress.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_RelationshipToStudent()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_RelationshipToStudent.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentKey()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentLivesWith_1()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentLivesWith_1.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_WorkEmailAddress_empty()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_WorkEmailAddress_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_WorkPhoneNumber_empty()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_WorkPhoneNumber_empty.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
            [Test]
            public void Then_should_have_PrimaryEmailAddress()
            {
                Result = DataStandard.RunTestCase<ContactPersonDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_PrimaryEmailAddress.xml");
                Result.success.ShouldBe(true, Result.errorMessage);
            }
        }

    }
}
