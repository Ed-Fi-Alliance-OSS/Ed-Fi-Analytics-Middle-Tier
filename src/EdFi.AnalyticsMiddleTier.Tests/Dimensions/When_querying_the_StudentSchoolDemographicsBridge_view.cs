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
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.StudentSchoolDemographicsBridgeTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [Ignore("Ignore a fixture")]
    public abstract class When_querying_the_StudentSchoolDemographicsBridge_view : When_querying_a_view_postgres
    {
        protected const string TestCasesFolder = "TestCases.StudentSchoolDemographicsBridge";
        protected const string TestCasesDataFileName = "0000_StudentSchoolDemographicsBridge_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_StudentSchoolDemographicsBridge_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [SetUpFixture]
        public class SetupStudentSchoolDemographicsBridgeTestCase
                : When_querying_the_StudentSchoolDemographicsBridge_view
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<StudentSchoolDemographicsBridge>(TestCasesFolder, TestCasesDataFileName);
        }

        public class Given_student_school_demographics_bridge_cohortyear
        : When_querying_the_StudentSchoolDemographicsBridge_view
        {
            public Given_student_school_demographics_bridge_cohortyear(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "cohortyear";
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
            public Given_student_school_demographics_bridge_disability(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "disability";

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
            public Given_student_school_demographics_bridge_disabilitydesignation(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "disabilitydesignation";
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
            public Given_student_school_demographics_bridge_language(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "language";

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
            public Given_student_school_demographics_bridge_languageuse(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "languageuse";

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
            public Given_student_school_demographics_bridge_race(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "race";

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
            public Given_student_school_demographics_bridge_tribalaffiliation(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "tribalaffiliation";
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
            public Given_student_school_demographics_bridge_studentcharacteristic(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "studentcharacteristic";



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
            public Given_student_school_demographics_bridge_StudentCharacteristic_EconomicDisadvantaged(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "studentcharacteristic_EconomicDisadvantaged";

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
                TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private readonly string _caseIdentifier = "189871_867530011";

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
