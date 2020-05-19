// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;
using CommonLib = EdFi.AnalyticsMiddleTier.Common;

namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [Ignore("Ignore a fixture")]
    public abstract class When_querying_the_StudentLocalEducationAgencyDim_view : When_querying_a_view
    {
        protected const string TestCasesFolder = "TestCases.StudentLocalEducationAgencyDim";


        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            DataStandard.PrepareDatabase();
        }

        [OneTimeSetUp]
        public void Act()
        {
            Result = DataStandard.LoadTestCaseData<StudentLocalEducationAgencyDim>(
                $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.0000_StudentLocalEducationAgencyDim_Data_Load.xml");
            Result.success.ShouldBeTrue($"Error while loading data: '{Result.errorMessage}'");

            Result = DataStandard.Install();
            Result.success.ShouldBeTrue($"Error while installing Base: '{Result.errorMessage}'");
        }

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.0001_StudentLocalEducationAgencyDim_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        public class Given_student_local_education_agency_189871_867530
        : When_querying_the_StudentLocalEducationAgencyDim_view
        {
            public Given_student_local_education_agency_189871_867530(TestHarness dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "189871_867530";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_FirstName()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_FirstName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            
            [Test]
            public void Then_should_have_IsHispanic()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_IsHispanic.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LastName()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LastName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LimitedEnglishProficiency_Not_Applicable()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LimitedEnglishProficiency_Not_Applicable.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LocalEducationAgencyKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LocalEducationAgencyKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_MiddleName_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_MiddleName_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            
            [Test]
            public void Then_should_have_sex_male()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_sex_male.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentLocalEducationAgencyKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentLocalEducationAgencyKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_local_education_agency_189919_867530
        : When_querying_the_StudentLocalEducationAgencyDim_view
        {
            public Given_student_local_education_agency_189919_867530(TestHarness dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "189919_867530";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_FirstName()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_FirstName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            
            [Test]
            public void Then_should_have_IsHispanic()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_IsHispanic.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LastName()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LastName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LimitedEnglishProficiency_Limited()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LimitedEnglishProficiency_Limited.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LocalEducationAgencyKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LocalEducationAgencyKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_MiddleName()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_MiddleName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            
            [Test]
            public void Then_should_have_sex_female()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_sex_female.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentLocalEducationAgencyKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentLocalEducationAgencyKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_local_education_agency_193964_867530
        : When_querying_the_StudentLocalEducationAgencyDim_view
        {
            public Given_student_local_education_agency_193964_867530(TestHarness dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "193964_867530";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_FirstName()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_FirstName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
           
            [Test]
            public void Then_should_have_IsHispanic()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_IsHispanic.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LastName()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LastName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LimitedEnglishProficiency_Not_Applicable()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LimitedEnglishProficiency_Not_Applicable.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LocalEducationAgencyKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LocalEducationAgencyKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_MiddleName()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_MiddleName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            
            [Test]
            public void Then_should_have_sex_male()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_sex_male.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentLocalEducationAgencyKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentLocalEducationAgencyKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentLocalEducationAgencyDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_local_education_agency_189919_628530
        : When_querying_the_StudentLocalEducationAgencyDim_view
        {
            public Given_student_local_education_agency_189919_628530(TestHarness dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "189919_628530";
            [Test]
            public void Then_should_not_return_any_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

       
    }
}
