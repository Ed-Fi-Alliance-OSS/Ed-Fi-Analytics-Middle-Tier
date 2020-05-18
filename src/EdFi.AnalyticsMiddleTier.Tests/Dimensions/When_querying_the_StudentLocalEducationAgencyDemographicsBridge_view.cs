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
    public abstract class When_querying_the_StudentLocalEducationAgencyDemographicsBridge_view : When_querying_a_view
    {
        protected const string TestCasesFolder = "TestCases.StudentLocalEducationAgencyDemographicsBridge";

        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            DataStandard.PrepareDatabase();
        }

        [OneTimeSetUp]
        public void Act()
        {
            Result = DataStandard.LoadTestCaseData<StudentLocalEducationAgencyDemographicsBridge>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.0000_StudentLocalEducationAgencyDemographicsBridge_Data_Load.xml");
            Result.success.ShouldBeTrue($"Error while loading data: '{Result.errorMessage}'");

            Result = DataStandard.Install();
            Result.success.ShouldBeTrue($"Error while installing Base: '{Result.errorMessage}'");
        }

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.0001_StudentLocalEducationAgencyDemographicsBridge_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        public class Given_StudentLocalEducationAgencyDemographicsBridge_2011_Eighth_grade_193964_867530
            : When_querying_the_StudentLocalEducationAgencyDemographicsBridge_view
        {
            public Given_StudentLocalEducationAgencyDemographicsBridge_2011_Eighth_grade_193964_867530(TestHarness dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "2011_Eighth_grade_193964_867530";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentLocalEducationAgencyKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentLocalEducationAgencyDemographicsBridge>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentLocalEducationAgencyKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSchoolDemographicBridgeKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentLocalEducationAgencyDemographicsBridge>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolDemographicBridgeKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_DemographicKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentLocalEducationAgencyDemographicsBridge>($"{TestCasesFolder}.{_caseIdentifier}_should_have_DemographicKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

        }

        public class Given_StudentLocalEducationAgencyDemographicsBridge_disability_designation
            : When_querying_the_StudentLocalEducationAgencyDemographicsBridge_view
        {
            public Given_StudentLocalEducationAgencyDemographicsBridge_disability_designation(TestHarness dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "disability_designation";
            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore($"The StudentLocalEducationAgencyDemographicsBridge view with DisabilityDesignation descriptor does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
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
            public void Then_should_have_StudentLocalEducationAgencyKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentLocalEducationAgencyDemographicsBridge>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentLocalEducationAgencyKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSchoolDemographicBridgeKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentLocalEducationAgencyDemographicsBridge>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolDemographicBridgeKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_DemographicKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentLocalEducationAgencyDemographicsBridge>($"{TestCasesFolder}.{_caseIdentifier}_should_have_DemographicKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

        }

        public class Given_StudentLocalEducationAgencyDemographicsBridge_disability
            : When_querying_the_StudentLocalEducationAgencyDemographicsBridge_view
        {
            public Given_StudentLocalEducationAgencyDemographicsBridge_disability(TestHarness dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "disability";

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
            public void Then_should_have_StudentLocalEducationAgencyKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentLocalEducationAgencyDemographicsBridge>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentLocalEducationAgencyKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSchoolDemographicBridgeKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentLocalEducationAgencyDemographicsBridge>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolDemographicBridgeKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_DemographicKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentLocalEducationAgencyDemographicsBridge>($"{TestCasesFolder}.{_caseIdentifier}_should_have_DemographicKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

        }

        public class Given_StudentLocalEducationAgencyDemographicsBridge_languageuse
            : When_querying_the_StudentLocalEducationAgencyDemographicsBridge_view
        {
            public Given_StudentLocalEducationAgencyDemographicsBridge_languageuse(TestHarness dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "languageuse";

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
            public void Then_should_have_StudentLocalEducationAgencyKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentLocalEducationAgencyDemographicsBridge>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentLocalEducationAgencyKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSchoolDemographicBridgeKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentLocalEducationAgencyDemographicsBridge>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolDemographicBridgeKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_DemographicKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentLocalEducationAgencyDemographicsBridge>($"{TestCasesFolder}.{_caseIdentifier}_should_have_DemographicKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

        }

        public class Given_StudentLocalEducationAgencyDemographicsBridge_language
            : When_querying_the_StudentLocalEducationAgencyDemographicsBridge_view
        {
            public Given_StudentLocalEducationAgencyDemographicsBridge_language(TestHarness dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "language";

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
            public void Then_should_have_StudentLocalEducationAgencyKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentLocalEducationAgencyDemographicsBridge>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentLocalEducationAgencyKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSchoolDemographicBridgeKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentLocalEducationAgencyDemographicsBridge>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolDemographicBridgeKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_DemographicKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentLocalEducationAgencyDemographicsBridge>($"{TestCasesFolder}.{_caseIdentifier}_should_have_DemographicKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

        }

        public class Given_StudentLocalEducationAgencyDemographicsBridge_race
            : When_querying_the_StudentLocalEducationAgencyDemographicsBridge_view
        {
            public Given_StudentLocalEducationAgencyDemographicsBridge_race(TestHarness dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "race";

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
            public void Then_should_have_StudentLocalEducationAgencyKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentLocalEducationAgencyDemographicsBridge>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentLocalEducationAgencyKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSchoolDemographicBridgeKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentLocalEducationAgencyDemographicsBridge>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolDemographicBridgeKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_DemographicKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentLocalEducationAgencyDemographicsBridge>($"{TestCasesFolder}.{_caseIdentifier}_should_have_DemographicKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

        }

        public class Given_StudentLocalEducationAgencyDemographicsBridge_tribalaffiliation
            : When_querying_the_StudentLocalEducationAgencyDemographicsBridge_view
        {
            public Given_StudentLocalEducationAgencyDemographicsBridge_tribalaffiliation(TestHarness dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "tribalaffiliation";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore($"The StudentLocalEducationAgencyDemographicsBridge view with TribalAffiliation descriptor does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
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
            public void Then_should_have_StudentLocalEducationAgencyKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentLocalEducationAgencyDemographicsBridge>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentLocalEducationAgencyKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSchoolDemographicBridgeKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentLocalEducationAgencyDemographicsBridge>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolDemographicBridgeKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_DemographicKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentLocalEducationAgencyDemographicsBridge>($"{TestCasesFolder}.{_caseIdentifier}_should_have_DemographicKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

        }

        public class Given_StudentLocalEducationAgencyDemographicsBridge_studentcharacteristic
            : When_querying_the_StudentLocalEducationAgencyDemographicsBridge_view
        {
            public Given_StudentLocalEducationAgencyDemographicsBridge_studentcharacteristic(TestHarness dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "studentcharacteristic";

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
            public void Then_should_have_StudentLocalEducationAgencyKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentLocalEducationAgencyDemographicsBridge>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentLocalEducationAgencyKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSchoolDemographicBridgeKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentLocalEducationAgencyDemographicsBridge>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolDemographicBridgeKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_DemographicKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentLocalEducationAgencyDemographicsBridge>($"{TestCasesFolder}.{_caseIdentifier}_should_have_DemographicKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

        }

        public class Given_StudentLocalEducationAgencyDemographicsBridge_student_characteristic_economic_disadvantaged
            : When_querying_the_StudentLocalEducationAgencyDemographicsBridge_view
        {
            public Given_StudentLocalEducationAgencyDemographicsBridge_student_characteristic_economic_disadvantaged(TestHarness dataStandard) => SetDataStandard(dataStandard);
            private string _caseIdentifier = "studentcharacteristic_economic_disadvantaged";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (!DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore($"The StudentLocalEducationAgencyDemographicsBridge view with TribalAffiliation descriptor does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentLocalEducationAgencyKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentLocalEducationAgencyDemographicsBridge>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentLocalEducationAgencyKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSchoolDemographicBridgeKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentLocalEducationAgencyDemographicsBridge>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolDemographicBridgeKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_DemographicKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentLocalEducationAgencyDemographicsBridge>($"{TestCasesFolder}.{_caseIdentifier}_should_have_DemographicKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_StudentLocalEducationAgencyDemographicsBridge_cohortyear
            : When_querying_the_StudentLocalEducationAgencyDemographicsBridge_view
        {
            public Given_StudentLocalEducationAgencyDemographicsBridge_cohortyear(
                TestHarness dataStandard) => SetDataStandard(dataStandard);

            private string _caseIdentifier = "cohortyear";

            [Test]
            public void Then_should_not_return_records()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_not_return_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            
        }
        public class Given_StudentLocalEducationAgencyDemographicsBridge_189919_628530
            : When_querying_the_StudentLocalEducationAgencyDemographicsBridge_view
        {
            public Given_StudentLocalEducationAgencyDemographicsBridge_189919_628530(
                TestHarness dataStandard) => SetDataStandard(dataStandard);

            private string _caseIdentifier = "189919_628530";

            [Test]
            public void Then_should_not_return_cohortyear_records()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_cohortyear_should_not_return_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_not_return_disability_designation_records()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_disability_designation_should_not_return_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_not_return_disability_records()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_disability_should_not_return_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_not_return_language_records()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_language_should_not_return_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_not_return_languageuse_records()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_languageuse_should_not_return_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_not_return_race_records()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_race_should_not_return_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_not_return_studentcharacteristic_records()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_studentcharacteristic_should_not_return_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_not_return_tribalaffiliation_records()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_tribalaffiliation_should_not_return_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_StudentLocalEducationAgencyDemographicsBridge_189871_828530
           : When_querying_the_StudentLocalEducationAgencyDemographicsBridge_view
        {
            public Given_StudentLocalEducationAgencyDemographicsBridge_189871_828530(
                TestHarness dataStandard) => SetDataStandard(dataStandard);

            private string _caseIdentifier = "189871_828530";

            [Test]
            public void Then_should_not_return_cohortyear_records()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_cohortyear_should_not_return_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_not_return_disability_designation_records()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_disability_designation_should_not_return_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_not_return_disability_records()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_disability_should_not_return_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_not_return_language_records()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_language_should_not_return_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_not_return_languageuse_records()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_languageuse_should_not_return_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_not_return_race_records()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_race_should_not_return_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_not_return_studentcharacteristic_records()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_studentcharacteristic_should_not_return_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_not_return_tribalaffiliation_records()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_tribalaffiliation_should_not_return_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_StudentLocalEducationAgencyDemographicsBridge_189919_828530
            : When_querying_the_StudentLocalEducationAgencyDemographicsBridge_view
        {
            public Given_StudentLocalEducationAgencyDemographicsBridge_189919_828530(
                TestHarness dataStandard) => SetDataStandard(dataStandard);

            private string _caseIdentifier = "189919_828530";

            [Test]
            public void Then_should_return_one_cohortyear_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_cohortyear_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_return_one_disability_designation_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_disability_designation_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
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
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_tribalaffiliation_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
