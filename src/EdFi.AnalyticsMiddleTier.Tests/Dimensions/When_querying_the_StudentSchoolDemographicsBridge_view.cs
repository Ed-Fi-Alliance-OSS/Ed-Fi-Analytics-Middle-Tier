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
    [Ignore("Ignore a fixture")]
    public abstract class When_querying_the_StudentSchoolDemographicsBridge_view : When_querying_a_view
    {
        protected const string TestCasesFolder = "TestCases.StudentSchoolDemographicsBridge";


        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            DataStandard.PrepareDatabase();
        }

        [OneTimeSetUp]
        public void Act()
        {
            Result = DataStandard.LoadTestCaseData<StudentSchoolDemographicsBridge>(
                $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.0000_StudentSchoolDemographicsBridge_Data_Load.xml");
            Result.success.ShouldBeTrue($"Error while loading data: '{Result.errorMessage}'");

            Result = DataStandard.Install();
            Result.success.ShouldBeTrue($"Error while installing Base: '{Result.errorMessage}'");
        }

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.0001_StudentSchoolDemographicsBridge_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        public class Given_student_school_demographics_bridge_cohortyear
        : When_querying_the_StudentSchoolDemographicsBridge_view
        {
            public Given_student_school_demographics_bridge_cohortyear(TestHarness dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "cohortyear";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolDemographicBridgeKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSchoolDemographicsBridge>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolDemographicBridgeKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSchoolDemographicsBridge>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_DemographicKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSchoolDemographicsBridge>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_DemographicKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_school_demographics_bridge_disability
        : When_querying_the_StudentSchoolDemographicsBridge_view
        {
            public Given_student_school_demographics_bridge_disability(TestHarness dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "disability";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolDemographicBridgeKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSchoolDemographicsBridge>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolDemographicBridgeKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSchoolDemographicsBridge>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_DemographicKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSchoolDemographicsBridge>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_DemographicKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_school_demographics_bridge_disabilitydesignation
        : When_querying_the_StudentSchoolDemographicsBridge_view
        {
            public Given_student_school_demographics_bridge_disabilitydesignation(TestHarness dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "disabilitydesignation";
            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore($"The StudentSchoolDemographicsBridge view with DisabilityDesignation descriptor does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolDemographicBridgeKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSchoolDemographicsBridge>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolDemographicBridgeKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSchoolDemographicsBridge>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_DemographicKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSchoolDemographicsBridge>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_DemographicKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
      
        public class Given_student_school_demographics_bridge_language
        : When_querying_the_StudentSchoolDemographicsBridge_view
        {
            public Given_student_school_demographics_bridge_language(TestHarness dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "language";
            
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolDemographicBridgeKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSchoolDemographicsBridge>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolDemographicBridgeKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSchoolDemographicsBridge>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_DemographicKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSchoolDemographicsBridge>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_DemographicKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
       
        public class Given_student_school_demographics_bridge_languageuse
        : When_querying_the_StudentSchoolDemographicsBridge_view
        {
            public Given_student_school_demographics_bridge_languageuse(TestHarness dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "languageuse";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolDemographicBridgeKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSchoolDemographicsBridge>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolDemographicBridgeKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSchoolDemographicsBridge>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_DemographicKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSchoolDemographicsBridge>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_DemographicKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
        public class Given_student_school_demographics_bridge_race
        : When_querying_the_StudentSchoolDemographicsBridge_view
        {
            public Given_student_school_demographics_bridge_race(TestHarness dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "race";
            
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolDemographicBridgeKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSchoolDemographicsBridge>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolDemographicBridgeKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSchoolDemographicsBridge>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_DemographicKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSchoolDemographicsBridge>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_DemographicKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_school_demographics_bridge_tribalaffiliation
       : When_querying_the_StudentSchoolDemographicsBridge_view
        {
            public Given_student_school_demographics_bridge_tribalaffiliation(TestHarness dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "tribalaffiliation";
            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore($"The StudentSchoolDemographicsBridge view with TribalAffiliation descriptor does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolDemographicBridgeKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSchoolDemographicsBridge>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolDemographicBridgeKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSchoolDemographicsBridge>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_DemographicKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSchoolDemographicsBridge>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_DemographicKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_school_demographics_bridge_studentcharacteristic
       : When_querying_the_StudentSchoolDemographicsBridge_view
        {
            public Given_student_school_demographics_bridge_studentcharacteristic(TestHarness dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "studentcharacteristic";

           

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolDemographicBridgeKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSchoolDemographicsBridge>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolDemographicBridgeKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSchoolDemographicsBridge>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_DemographicKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSchoolDemographicsBridge>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_DemographicKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_school_demographics_bridge_StudentCharacteristic_EconomicDisadvantaged
       : When_querying_the_StudentSchoolDemographicsBridge_view
        {
            public Given_student_school_demographics_bridge_StudentCharacteristic_EconomicDisadvantaged(TestHarness dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "studentcharacteristic_EconomicDisadvantaged";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (!DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore($"The StudentSchoolDemographicsBridge view with StudentCharacteristic descriptor does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_not_return_records()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_not_return_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSchoolDemographicBridgeKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSchoolDemographicsBridge>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolDemographicBridgeKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSchoolDemographicsBridge>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_DemographicKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentSchoolDemographicsBridge>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_DemographicKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
        public class Given_StudentSchoolDemographicsBridge_189871_867530011
            : When_querying_the_StudentSchoolDemographicsBridge_view
        {
            public Given_StudentSchoolDemographicsBridge_189871_867530011(
                TestHarness dataStandard) => SetDataStandard(dataStandard);

            private string _caseIdentifier = "189871_867530011";

            [Test]
            public void Then_should_return_one_cohortyear_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_cohortyear_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_return_one_disability_designation_record()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore($"The StudentSchoolDemographicsBridge view with DisabilityDesignation descriptor does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
                else
                {
                    (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_disability_designation_should_return_one_record.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
            }
            [Test]
            public void Then_should_return_one_disability_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_disability_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_return_one_language_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_language_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_return_one_languageuse_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_languageuse_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_return_one_race_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_race_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_return_one_studentcharacteristic_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_studentcharacteristic_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_return_one_tribalaffiliation_record()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore($"The StudentSchoolDemographicsBridge view with TribalAffiliation descriptor does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
                else
                {
                    (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_tribalaffiliation_should_return_one_record.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
                
            }
        }
    }
}
