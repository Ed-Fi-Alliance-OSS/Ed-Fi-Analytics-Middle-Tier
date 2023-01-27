// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;
using CommonLib = EdFi.AnalyticsMiddleTier.Common;

// ReSharper disable once CheckNamespace
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.AllStudentSchoolDimTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_AllStudentSchoolDim_view : When_querying_a_view_postgres
    {
        protected const string TestCasesFolder = "TestCases.AllStudentSchoolDim";
        protected const string TestCasesDataFileName = "0000_AllStudentSchoolDim_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_AllStudentSchoolDim_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [SetUpFixture]
        public class SetupAllStudentSchoolDimTestCase
                : When_querying_the_AllStudentSchoolDim_view
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<AllStudentSchoolDim>(TestCasesFolder, TestCasesDataFileName);
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_189914
            : When_querying_the_AllStudentSchoolDim_view
        {

            private const string _caseIdentifier = "189914";
            public Given_student_189914(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_AllStudentSchoolKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_AllStudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult =
                        DataStandard.RunTestCase<AllStudentSchoolDim>(
                            $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolYear()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolYear.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentFirstName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentFirstName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentMiddleName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentMiddleName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentLastName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentLastName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_EnrollmentDateKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_EnrollmentDateKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_GradeLevel()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_GradeLevel.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsHispanic()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_IsHispanic.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_Sex_Male()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_Sex_Male.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LimitedEnglishProficiency_not_applicable()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LimitedEnglishProficiency_not_applicable.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_189854
           : When_querying_the_AllStudentSchoolDim_view
        {

            private const string _caseIdentifier = "189854";
            public Given_student_189854(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_return_all_records()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_all_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_AllStudentSchoolKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_AllStudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolYear_Unknown()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolYear_Unknown.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentFirstName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentFirstName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentMiddleName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentMiddleName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentLastName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentLastName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_BirthDate()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_BirthDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_EnrollmentDateKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_EnrollmentDateKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_GradeLevel()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_GradeLevel.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsHispanic()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_IsHispanic.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_Sex_Male()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_Sex_Male.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LimitedEnglishProficiency_not_applicable()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LimitedEnglishProficiency_not_applicable.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ExitWithdrawDate_Empty()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_ExitWithdrawDate_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsEnrolled()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_IsEnrolled.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]

        public class Given_student_189854_digital_access
           : When_querying_the_AllStudentSchoolDim_view
        {

            private const string _caseIdentifier = "189854";
            public Given_student_189854_digital_access(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The AllStudentSchoolDim view does not include digital access information in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }
            [Test]
            public void Then_should_have_AllStudentSchoolKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_AllStudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_DeviceAccess()
            {

                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_have_DeviceAccess.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_DigitalDevice()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_have_DigitalDevice.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_InternetAccessInResidence()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_InternetAccessInResidence.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_InternetAccessTypeInResidence()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_InternetAccessTypeInResidence.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_InternetPerformance()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_InternetPerformance.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_189863
           : When_querying_the_AllStudentSchoolDim_view
        {
            private const string _caseIdentifier = "189863";
            public Given_student_189863(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_AllStudentSchoolKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_AllStudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolYear()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolYear.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentFirstName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentFirstName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentMiddleName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentMiddleName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentLastName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentLastName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_EnrollmentDateKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_EnrollmentDateKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_GradeLevel()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_GradeLevel.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsHispanic_0()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_IsHispanic_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_Sex_Female()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_Sex_Female.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LimitedEnglishProficiency_not_applicable()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LimitedEnglishProficiency_not_applicable.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_192452
            : When_querying_the_AllStudentSchoolDim_view
        {
            private const string _caseIdentifier = "192452";
            public Given_student_192452(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_AllStudentSchoolKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_AllStudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolYear()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolYear.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentFirstName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentFirstName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentMiddleName_empty()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentMiddleName_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentLastName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentLastName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_EnrollmentDateKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_EnrollmentDateKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_GradeLevel()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_GradeLevel.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsHispanic()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_IsHispanic.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_Sex_Female()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_Sex_Female.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LimitedEnglishProficiency()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LimitedEnglishProficiency.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DeviceAccess()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentSchoolDim view does not include digital access information in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
                else
                {
                    (bool success, string errorMessage) testResult =
                        DataStandard.RunTestCase<StudentSchoolDim>(
                            $"{TestCasesFolder}.{_caseIdentifier}_should_have_DeviceAccess.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
            }

            [Test]
            public void Then_should_have_DigitalDevice()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentSchoolDim view does not include digital access information in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
                else
                {
                    (bool success, string errorMessage) testResult =
                        DataStandard.RunTestCase<StudentSchoolDim>(
                            $"{TestCasesFolder}.{_caseIdentifier}_should_have_DigitalDevice.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
            }

            [Test]
            public void Then_should_have_InternetAccessInResidence()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentSchoolDim view does not include digital access information in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
                else
                {
                    (bool success, string errorMessage) testResult =
                        DataStandard.RunTestCase<StudentSchoolDim>(
                            $"{TestCasesFolder}.{_caseIdentifier}_should_have_InternetAccessInResidence.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
            }

            [Test]
            public void Then_should_have_InternetAccessTypeInResidence()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentSchoolDim view does not include digital access information in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
                else
                {
                    (bool success, string errorMessage) testResult =
                        DataStandard.RunTestCase<StudentSchoolDim>(
                            $"{TestCasesFolder}.{_caseIdentifier}_should_have_InternetAccessTypeInResidence.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
            }
            [Test]
            public void Then_should_have_InternetPerformance()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentSchoolDim view does not include digital access information in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
                else
                {
                    (bool success, string errorMessage) testResult =
                        DataStandard.RunTestCase<StudentSchoolDim>(
                            $"{TestCasesFolder}.{_caseIdentifier}_should_have_InternetPerformance.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_189936
            : When_querying_the_AllStudentSchoolDim_view
        {

            private const string _caseIdentifier = "189936";
            public Given_student_189936(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_AllStudentSchoolKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_AllStudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_IsEnrolled_false()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_IsEnrolled_false.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_ExitWithdrawDate()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_ExitWithdrawDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_190032
            : When_querying_the_AllStudentSchoolDim_view
        {

            private const string _caseIdentifier = "190032";
            public Given_student_190032(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_AllStudentSchoolKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_AllStudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_190034
            : When_querying_the_AllStudentSchoolDim_view
        {

            private const string _caseIdentifier = "190034";
            public Given_student_190034(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_AllStudentSchoolKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_AllStudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsHispanic_0()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_IsHispanic_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsEnrolled()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_IsEnrolled.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_DeviceAccess_NA()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentSchoolDim view does not include digital access information in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
                else
                {
                    (bool success, string errorMessage) testResult =
                        DataStandard.RunTestCase<StudentSchoolDim>(
                            $"{TestCasesFolder}.{_caseIdentifier}_should_have_DeviceAccess_NA.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
            }

            [Test]
            public void Then_should_have_DigitalDevice_NA()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentSchoolDim view does not include digital access information in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
                else
                {
                    (bool success, string errorMessage) testResult =
                        DataStandard.RunTestCase<StudentSchoolDim>(
                            $"{TestCasesFolder}.{_caseIdentifier}_should_have_DigitalDevice_NA.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
            }

            [Test]
            public void Then_should_have_InternetAccessInResidence_NA()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentSchoolDim view does not include digital access information in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
                else
                {
                    (bool success, string errorMessage) testResult =
                        DataStandard.RunTestCase<StudentSchoolDim>(
                            $"{TestCasesFolder}.{_caseIdentifier}_should_have_InternetAccessInResidence_NA.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
            }

            [Test]
            public void Then_should_have_InternetAccessTypeInResidence_NA()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentSchoolDim view does not include digital access information in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
                else
                {
                    (bool success, string errorMessage) testResult =
                        DataStandard.RunTestCase<StudentSchoolDim>(
                            $"{TestCasesFolder}.{_caseIdentifier}_should_have_InternetAccessTypeInResidence_NA.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
            }
            [Test]
            public void Then_should_have_InternetPerformance_NA()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentSchoolDim view does not include digital access information in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
                else
                {
                    (bool success, string errorMessage) testResult =
                        DataStandard.RunTestCase<StudentSchoolDim>(
                            $"{TestCasesFolder}.{_caseIdentifier}_should_have_InternetPerformance_NA.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
            }
            [Test]
            public void Then_should_have_Sex_empty()
            {
                if (!DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<AllStudentSchoolDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_sex_empty.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
                else
                {
                    Assert.Ignore("Data Standard 2 has a required SetType field.");
                }
            }
        }
    }
}
