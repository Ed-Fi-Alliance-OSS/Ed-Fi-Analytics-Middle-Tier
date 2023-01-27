// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;
using System.Diagnostics.CodeAnalysis;

// ReSharper disable once CheckNamespace
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.StaffSectionDimTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_StaffSectionDim_view : When_querying_a_view_postgres
    {
        protected const string TestCasesFolder = "TestCases.StaffSectionDim";
        protected const string TestCasesDataFileName = "0000_StaffSectionDim_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }
        [SetUpFixture]
        public class SetupStaffSectionDimTestCase
            : When_querying_the_StaffSectionDim_view
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<StaffSectionDim>(TestCasesFolder, TestCasesDataFileName);
        }
        public class Given_StaffSection_11324_XLTV31
        : When_querying_the_StaffSectionDim_view
        {
            public Given_StaffSection_11324_XLTV31(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "11324_XLTV31";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_BirthDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_BirthDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ElectronicMailAddress_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_ElectronicMailAddress_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StaffFirstName()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_StaffFirstName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_HighestCompletedLevelOfEducation()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_HighestCompletedLevelOfEducation.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_HighlyQualifiedTeacher()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_HighlyQualifiedTeacher.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_HispanicLatinoEthnicity()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_HispanicLatinoEthnicity.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StaffLastName()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_StaffLastName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LoginId()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_LoginId.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StaffMiddleName()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_StaffMiddleName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_PersonalTitlePrefix_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_PersonalTitlePrefix_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_Race()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_Race.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_SectionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_SectionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_Sex()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_Sex.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StaffSectionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_StaffSectionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_UserKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_UserKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_YearsOfPriorProfessionalExperience()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_YearsOfPriorProfessionalExperience.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_YearsOfPriorTeachingExperience()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_YearsOfPriorTeachingExperience.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_StaffSection_11331_NCMR11
        : When_querying_the_StaffSectionDim_view
        {
            public Given_StaffSection_11331_NCMR11(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "11331_NCMR11";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_BirthDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_BirthDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ElectronicMailAddress()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_ElectronicMailAddress.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StaffFirstName()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_StaffFirstName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_HighestCompletedLevelOfEducation()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_HighestCompletedLevelOfEducation.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_HighlyQualifiedTeacher()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_HighlyQualifiedTeacher.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_HispanicLatinoEthnicity()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_HispanicLatinoEthnicity.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StaffLastName()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_StaffLastName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LoginId()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_LoginId.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StaffMiddleName()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_StaffMiddleName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_PersonalTitlePrefix()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_PersonalTitlePrefix.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_Race()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_Race.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_SectionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_SectionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_Sex()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_Sex.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StaffSectionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_StaffSectionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_UserKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_UserKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_YearsOfPriorProfessionalExperience()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_YearsOfPriorProfessionalExperience.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_YearsOfPriorTeachingExperience()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_YearsOfPriorTeachingExperience.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_StaffSection_11331_2012
        : When_querying_the_StaffSectionDim_view
        {
            public Given_StaffSection_11331_2012(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "11331_2012";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_SectionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_SectionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StaffSectionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_StaffSectionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_StaffSection_13724_BPPR20
        : When_querying_the_StaffSectionDim_view
        {
            public Given_StaffSection_13724_BPPR20(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "13724_BPPR20";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_BirthDate_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_BirthDate_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ElectronicMailAddress_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_ElectronicMailAddress_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StaffFirstName()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_StaffFirstName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_HighestCompletedLevelOfEducation_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_HighestCompletedLevelOfEducation_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_HighlyQualifiedTeacher_Zero()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_HighlyQualifiedTeacher_Zero.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_HispanicLatinoEthnicity()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_HispanicLatinoEthnicity.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StaffLastName()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_StaffLastName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LoginId_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_LoginId_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StaffMiddleName_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_StaffMiddleName_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_PersonalTitlePrefix_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_PersonalTitlePrefix_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_Race()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_Race.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_SectionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_SectionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_Sex_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_Sex_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StaffSectionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_StaffSectionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_UserKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_UserKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_YearsOfPriorProfessionalExperience_Zero()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_YearsOfPriorProfessionalExperience_Zero.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_YearsOfPriorTeachingExperience_Zero()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_YearsOfPriorTeachingExperience_Zero.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_StaffSection_142990_NCMR11
       : When_querying_the_StaffSectionDim_view
        {
            public Given_StaffSection_142990_NCMR11(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "142990_NCMR11";

            [Test]
            public void Then_should_have_HispanicLatinoEthnicity_Zero()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffSectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_HispanicLatinoEthnicity_Zero.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

        }

    }
}
