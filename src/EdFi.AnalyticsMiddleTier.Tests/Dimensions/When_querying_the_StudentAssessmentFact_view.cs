// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Common;
using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;
using CommonLib = EdFi.AnalyticsMiddleTier.Common;

// ReSharper disable once CheckNamespace
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.StudentAssessmentFactTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_StudentAssessmentFact_view : When_querying_a_view_postgres_ds3
    {
        protected const string TestCasesFolder = "TestCases.StudentAssessmentFact";
        protected const string TestCasesDataFileName = "0000_StudentAssessmentFact_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_StudentAssessmentFact_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [SetUpFixture]
        public class SetupStudentAssessmentFactTestCase
            : When_querying_the_StudentAssessmentFact_view
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<StudentAssessmentFact>(TestCasesFolder, TestCasesDataFileName, Component.Asmt);
        }

        public class Given_student_assessment_fact_04556570_B715_6D8E_5E86_008A72ECE446_2009_04_01
        : When_querying_the_StudentAssessmentFact_view
        {
            public Given_student_assessment_fact_04556570_B715_6D8E_5E86_008A72ECE446_2009_04_01(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "04556570_B715_6D8E_5E86_008A72ECE446_2009_04_01";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentAssessmentFactKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentAssessmentFactKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentAssessmentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentAssessmentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_AssessmentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AssessmentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            //

            [Test]
            public void Then_should_have_AssessmentIdentifier()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AssessmentIdentifier.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_Namespace()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_Namespace.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentAssessmentIdentifier()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentAssessmentIdentifier.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentUSI()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentUSI.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            //

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_AdministrationDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AdministrationDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentScore()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentScore.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_ResultDataType()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ResultDataType.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportingMethod()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportingMethod.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_PerformanceResult()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_PerformanceResult.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_assessment_fact_D0FEA09D_5781_D6EF_7232_59E9BE3212A0_2010_04_01
        : When_querying_the_StudentAssessmentFact_view
        {
            public Given_student_assessment_fact_D0FEA09D_5781_D6EF_7232_59E9BE3212A0_2010_04_01(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "D0FEA09D_5781_D6EF_7232_59E9BE3212A0_2010_04_01";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_assessment_fact_EC3D3C28_3C31_4C94_4C50_FB0F25EE5E71_2012_04_01
        : When_querying_the_StudentAssessmentFact_view
        {
            public Given_student_assessment_fact_EC3D3C28_3C31_4C94_4C50_FB0F25EE5E71_2012_04_01(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "EC3D3C28_3C31_4C94_4C50_FB0F25EE5E71_2012_04_01";
            [Test]
            public void Then_should_return_no_records()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_no_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_assessment_fact_C2036C8D_1333_F75D_0B6B_380756666AF8_2008_03_01
        : When_querying_the_StudentAssessmentFact_view
        {
            public Given_student_assessment_fact_C2036C8D_1333_F75D_0B6B_380756666AF8_2008_03_01(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "C2036C8D_1333_F75D_0B6B_380756666AF8_2008_03_01";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_assessment_fact_0E886CBB_AB8F_ABD3_747F_C455C5141145_2009_04_01
        : When_querying_the_StudentAssessmentFact_view
        {
            public Given_student_assessment_fact_0E886CBB_AB8F_ABD3_747F_C455C5141145_2009_04_01(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "0E886CBB_AB8F_ABD3_747F_C455C5141145_2009_04_01";
            [Test]
            public void Then_should_return_no_records()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_no_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_assessment_fact_A71C02C3_CBC5_9C2F_2D04_012CA2B007A2_2009_03_01
        : When_querying_the_StudentAssessmentFact_view
        {
            public Given_student_assessment_fact_A71C02C3_CBC5_9C2F_2D04_012CA2B007A2_2009_03_01(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "A71C02C3_CBC5_9C2F_2D04_012CA2B007A2_2009_03_01";
            [Test]
            public void Then_should_return_no_records()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_assessment_fact_2CB96919_1D86_B089_89DD_42AAF9E46852_2009_04_01
        : When_querying_the_StudentAssessmentFact_view
        {
            public Given_student_assessment_fact_2CB96919_1D86_B089_89DD_42AAF9E46852_2009_04_01(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "2CB96919_1D86_B089_89DD_42AAF9E46852_2009_04_01";
            [Test]
            public void Then_should_return_no_records()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_assessment_fact_C2036C8D_1333_F75D_0B6B_380756666AF8_2008_03_02_100039988
            : When_querying_the_StudentAssessmentFact_view
        {
            public Given_student_assessment_fact_C2036C8D_1333_F75D_0B6B_380756666AF8_2008_03_02_100039988(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "C2036C8D_1333_F75D_0B6B_380756666AF8_2008_03_02_100039988";
            [Test]
            public void Then_should_have_ReportingMethod_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportingMethod_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_ResultDataType_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ResultDataType_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentScore_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentScore_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_PerformanceResult_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_PerformanceResult_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentAssessmentReportingMethod_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentAssessmentReportingMethod_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentAssessmentResultDataType_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentAssessmentResultDataType_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentAssessmentScore_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentAssessmentScore_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentAssessmentPerformanceResult_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentAssessmentPerformanceResult_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_assessment_fact_D0FEA09D_5781_D6EF_7232_59E9BE3212A0_2010_04_01_100035251
            : When_querying_the_StudentAssessmentFact_view
        {
            public Given_student_assessment_fact_D0FEA09D_5781_D6EF_7232_59E9BE3212A0_2010_04_01_100035251(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "D0FEA09D_5781_D6EF_7232_59E9BE3212A0_2010_04_01_100035251";
            [Test]
            public void Then_should_have_ReportingMethod_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportingMethod_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_ResultDataType_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ResultDataType_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentScore_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentScore_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_PerformanceResult_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_PerformanceResult_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
        public class Given_student_assessment_fact_EC3D3C28_3C31_4C94_4C50_FB0F25EE5E71_2012_04_01_100074717
            : When_querying_the_StudentAssessmentFact_view
        {
            public Given_student_assessment_fact_EC3D3C28_3C31_4C94_4C50_FB0F25EE5E71_2012_04_01_100074717(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "EC3D3C28_3C31_4C94_4C50_FB0F25EE5E71_2012_04_01_100074717";
            [Test]
            public void Then_should_have_ReportingMethod_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportingMethod_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_ResultDataType_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ResultDataType_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentScore_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentScore_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_PerformanceResult_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_PerformanceResult_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_assessment_fact_EC3D3C28_3C31_4C94_4C50_FB0F25EE5E71_2012_04_01_100074717_ns
            : When_querying_the_StudentAssessmentFact_view
        {
            public Given_student_assessment_fact_EC3D3C28_3C31_4C94_4C50_FB0F25EE5E71_2012_04_01_100074717_ns(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "EC3D3C28_3C31_4C94_4C50_FB0F25EE5E71_2012_04_01_100074717_ns";
            [Test]
            public void Then_should_have_PerformanceResult_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_PerformanceResult_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
        public class Given_student_assessment_fact_0E886CBB_AB8F_ABD3_747F_C455C5141146_2009_04_01_100041249
            : When_querying_the_StudentAssessmentFact_view
        {
            public Given_student_assessment_fact_0E886CBB_AB8F_ABD3_747F_C455C5141146_2009_04_01_100041249(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "0E886CBB_AB8F_ABD3_747F_C455C5141146_2009_04_01_100041249";
            [Test]
            public void Then_should_have_PerformanceResult_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_PerformanceResult_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_assessment_MP_2013_Mathematics_Seventh_Grade_605213_255901044
        : When_querying_the_StudentAssessmentFact_view
        {
            public Given_assessment_MP_2013_Mathematics_Seventh_Grade_605213_255901044(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "MP_2013_Mathematics_Seventh_Grade_605213_255901044";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentAssessmentFact view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentAssessmentFactKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentAssessmentFactKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_AssessmentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AssessmentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ObjectiveAssessmentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ObjectiveAssessmentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_Namespace()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_Namespace.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentObjectiveAssessmentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentObjectiveAssessmentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentScore()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentScore.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ResultDataType()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ResultDataType.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportingMethod()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportingMethod.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_PerformanceResult()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_PerformanceResult.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentAssessmentScore()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentAssessmentScore.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentAssessmentResultDataType()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentAssessmentResultDataType.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentAssessmentReportingMethod()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentAssessmentReportingMethod.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentAssessmentPerformanceResult()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentAssessmentPerformanceResult.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_assessment_MP_2013_Mathematics_Seventh_Grade_605215_255901044
        : When_querying_the_StudentAssessmentFact_view
        {
            public Given_assessment_MP_2013_Mathematics_Seventh_Grade_605215_255901044(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "MP_2013_Mathematics_Seventh_Grade_605215_255901044";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentAssessmentFact view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_PerformanceResult_Basic()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_PerformanceResult_Basic.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_assessment_MP_2013_Mathematics_Seventh_Grade_605213_255901001
            : When_querying_the_StudentAssessmentFact_view
        {
            public Given_assessment_MP_2013_Mathematics_Seventh_Grade_605213_255901001(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "MP_2013_Mathematics_Seventh_Grade_605213_255901001";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentAssessmentFact view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_not_return_any_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_assessment_fact_XE4G2T67_5781_D6EF_7232_82D1FG1987Z1_2021_02_25_should_return_one_record
            : When_querying_the_StudentAssessmentFact_view
        {
            public Given_student_assessment_fact_XE4G2T67_5781_D6EF_7232_82D1FG1987Z1_2021_02_25_should_return_one_record(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "XE4G2T67_5781_D6EF_7232_82D1FG1987Z1_2021_02_25";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentAssessmentFact view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_not_return_any_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ObjectiveAssessmentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ObjectiveAssessmentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentObjectiveAssessmentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentObjectiveAssessmentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ObjectiveAssessmentKey_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ObjectiveAssessmentKey_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentObjectiveAssessmentKey_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentObjectiveAssessmentKey_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_assessment_fact_100035251_D0FEA09D_5781_D6EF_7232_59E9BE3212A0_ns_should_return_one_record
            : When_querying_the_StudentAssessmentFact_view
        {
            public Given_student_assessment_fact_100035251_D0FEA09D_5781_D6EF_7232_59E9BE3212A0_ns_should_return_one_record(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "100035251_D0FEA09D_5781_D6EF_7232_59E9BE3212A0_ns";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentAssessmentFact view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_AssessedGradeLevel_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AssessedGradeLevel_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_PerformanceResult_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_PerformanceResult_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_assessment_fact_100035252_D0FEA09D_5781_D6EF_7232_59E9BE3212A0_ns_should_return_one_record
            : When_querying_the_StudentAssessmentFact_view
        {
            public Given_student_assessment_fact_100035252_D0FEA09D_5781_D6EF_7232_59E9BE3212A0_ns_should_return_one_record(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "100035252_D0FEA09D_5781_D6EF_7232_59E9BE3212A0_ns";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentAssessmentFact view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ReportingMethod_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ReportingMethod_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_assessment_fact_04556570_B715_6D8E_5E86_008A72ECE100_2009_04_01_should_return_one_record
            : When_querying_the_StudentAssessmentFact_view
        {
            public Given_student_assessment_fact_04556570_B715_6D8E_5E86_008A72ECE100_2009_04_01_should_return_one_record(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "04556570_B715_6D8E_5E86_008A72ECE100_2009_04_01";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentAssessmentFact view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_assessment_fact_04556570_B715_6D8E_5E86_008A72ECE110_2009_04_01_should_return_one_record
            : When_querying_the_StudentAssessmentFact_view
        {
            public Given_student_assessment_fact_04556570_B715_6D8E_5E86_008A72ECE110_2009_04_01_should_return_one_record(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "04556570_B715_6D8E_5E86_008A72ECE110_2009_04_01";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentAssessmentFact view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_assessment_fact_04556570_B715_6D8E_5E86_008A72ECE120_2009_04_01_should_return_one_record
            : When_querying_the_StudentAssessmentFact_view
        {
            public Given_student_assessment_fact_04556570_B715_6D8E_5E86_008A72ECE120_2009_04_01_should_return_one_record(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "04556570_B715_6D8E_5E86_008A72ECE120_2009_04_01";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentAssessmentFact view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_PerformanceResult_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_PerformanceResult_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentAssessmentPerformanceResult_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentAssessmentPerformanceResult_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_assessment_fact_04556570_B715_6D8E_5E86_008A72ECE140_2009_04_01_should_return_one_record
            : When_querying_the_StudentAssessmentFact_view
        {
            public Given_student_assessment_fact_04556570_B715_6D8E_5E86_008A72ECE140_2009_04_01_should_return_one_record(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "04556570_B715_6D8E_5E86_008A72ECE140_2009_04_01";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentAssessmentFact view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentScore()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentScore.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ResultDataType()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ResultDataType.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_student_assessment_fact_01774fa3_06f1_47fe_8801_c8b1e65057f2
            : When_querying_the_StudentAssessmentFact_view
        {
            public Given_student_assessment_fact_01774fa3_06f1_47fe_8801_c8b1e65057f2(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "01774fa3_06f1_47fe_8801_c8b1e65057f2";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentAssessmentFact view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_have_PerformanceResult_Advanced()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentAssessmentFact>($"{TestCasesFolder}.{_caseIdentifier}_should_have_PerformanceResult_Advanced.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
