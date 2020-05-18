﻿// SPDX-License-Identifier: Apache-2.0
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
    public abstract class When_querying_the_StudentSchoolDim_view : When_querying_a_view
    {
        protected const string TestCasesFolder = "TestCases.StudentSchoolDim";

        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            DataStandard.PrepareDatabase();
        }

        [OneTimeSetUp]
        public void Act()
        {
            Result = DataStandard.LoadTestCaseData<StudentSchoolDim>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.0000_StudentSchoolDim_Data_Load.xml");
            Result.success.ShouldBeTrue($"Error while loading data: '{Result.errorMessage}'");

            // Install the default map so that we can test for school address
            Result = DataStandard.Install(10);
            Result.success.ShouldBeTrue($"Error while installing Base: '{Result.errorMessage}'");
        }


        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.0001_StudentSchoolDim_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_189914
            : When_querying_the_StudentSchoolDim_view
        {

            private const string _caseIdentifier = "189914";
            public Given_student_189914(TestHarness dataStandard) => SetDataStandard(dataStandard);
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                if (!DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    (bool success, string errorMessage) testResult =
                        DataStandard.RunTestCase<StudentSchoolDim>(
                            $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
                else
                {
                    Assert.Ignore("Data Standard 2 does not have StudentSchoolKey on the StudentSchoolDim view.");
                }
            }

            [Test]
            public void Then_should_have_SchoolYear()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolYear.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentFirstName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentFirstName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentMiddleName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentMiddleName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentLastName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentLastName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_EnrollmentDateKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_EnrollmentDateKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_GradeLevel()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_GradeLevel.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsHispanic()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_IsHispanic.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_Sex_Male()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_Sex_Male.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LimitedEnglishProficiency_not_applicable()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LimitedEnglishProficiency_not_applicable.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_189854
           : When_querying_the_StudentSchoolDim_view
        {

            private const string _caseIdentifier = "189854";
            public Given_student_189854(TestHarness dataStandard) => SetDataStandard(dataStandard);
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                if (!DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    (bool success, string errorMessage) testResult =
                        DataStandard.RunTestCase<StudentSchoolDim>(
                            $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
                else
                {
                    Assert.Ignore("Data Standard 2 does not have StudentSchoolKey on the StudentSchoolDim view.");
                }
            }

            [Test]
            public void Then_should_have_SchoolYear_Unknown()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolYear_Unknown.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentFirstName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentFirstName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentMiddleName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentMiddleName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentLastName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentLastName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_EnrollmentDateKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_EnrollmentDateKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_GradeLevel()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_GradeLevel.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsHispanic()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_IsHispanic.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_Sex_Male()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_Sex_Male.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LimitedEnglishProficiency_not_applicable()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LimitedEnglishProficiency_not_applicable.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_189863
           : When_querying_the_StudentSchoolDim_view
        {
            private const string _caseIdentifier = "189863";
            public Given_student_189863(TestHarness dataStandard) => SetDataStandard(dataStandard);
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                if (!DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    (bool success, string errorMessage) testResult =
                        DataStandard.RunTestCase<StudentSchoolDim>(
                            $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
                else
                {
                    Assert.Ignore("Data Standard 2 does not have StudentSchoolKey on the StudentSchoolDim view.");
                }
            }

            [Test]
            public void Then_should_have_SchoolYear()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolYear.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentFirstName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentFirstName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentMiddleName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentMiddleName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentLastName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentLastName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_EnrollmentDateKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_EnrollmentDateKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_GradeLevel()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_GradeLevel.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsHispanic_0()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_IsHispanic_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_Sex_Female()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_Sex_Female.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LimitedEnglishProficiency_not_applicable()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LimitedEnglishProficiency_not_applicable.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_192452
            : When_querying_the_StudentSchoolDim_view
        {
            private const string _caseIdentifier = "192452";
            public Given_student_192452(TestHarness dataStandard) => SetDataStandard(dataStandard);
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                if (!DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    (bool success, string errorMessage) testResult =
                        DataStandard.RunTestCase<StudentSchoolDim>(
                            $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
                else
                {
                    Assert.Ignore("Data Standard 2 does not have StudentSchoolKey on the StudentSchoolDim view.");
                }
            }

            [Test]
            public void Then_should_have_SchoolYear()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolYear.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentFirstName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentFirstName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentMiddleName_empty()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentMiddleName_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentLastName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentLastName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_EnrollmentDateKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_EnrollmentDateKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_GradeLevel()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_GradeLevel.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsHispanic()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_IsHispanic.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_Sex_Female()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_Sex_Female.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LimitedEnglishProficiency()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LimitedEnglishProficiency.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_189936
            : When_querying_the_StudentSchoolDim_view
        {

            private const string _caseIdentifier = "189936";
            public Given_student_189936(TestHarness dataStandard) => SetDataStandard(dataStandard);
            [Test]
            public void Then_should_not_return_any_record()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

    }
}