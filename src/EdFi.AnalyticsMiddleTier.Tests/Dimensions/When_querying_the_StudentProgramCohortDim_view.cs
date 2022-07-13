// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;
using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Common;
using CommonLib = EdFi.AnalyticsMiddleTier.Common;

// ReSharper disable once CheckNamespace
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.StudentProgramCohortDimTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_StudentProgramCohortDim_view : When_querying_a_view_postgres_ds3
    {
        protected const string TestCasesFolder = "TestCases.StudentProgramCohortDim";
        protected const string TestCasesDataFileName = "0000_StudentProgramCohortDim_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult =
                DataStandard.RunTestCase<TableColumns>(
                    $"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_StudentProgramCohortDim_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [SetUpFixture]
        public class SetupStudentProgramCohortDimTestCase
            : When_querying_the_StudentProgramCohortDim_view
        {
            [OneTimeSetUp]
            public void PrepareDatabase() =>
                PrepareTestData<StudentProgramCohortDim>(TestCasesFolder, TestCasesDataFileName, Component.Equity);
        }

        public class Given_StudentProgramCohortDim_189889_867530022_Cohort_Program_1_1666_867530_867530_20060814_CI_1000
            : When_querying_the_StudentProgramCohortDim_view
        {
            public Given_StudentProgramCohortDim_189889_867530022_Cohort_Program_1_1666_867530_867530_20060814_CI_1000(
                TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier =
                "189889_867530022_Cohort_Program_1_1666_867530_867530_20060814_CI_1000";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentProgramCohortDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentProgramCohortKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramCohortDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentProgramCohortKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolProgramKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramCohortDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolProgramKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramCohortDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_CohortDescription()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramCohortDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_CohortDescription.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_CohortTypeDescriptor()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramCohortDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_CohortTypeDescriptor.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_EntryGradeLevelDescriptor()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramCohortDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_EntryGradeLevelDescriptor.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ProgramName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramCohortDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_ProgramName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramCohortDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_StudentProgramCohortDim_189890_867530023_Cohort_Program_2_1666_867531_867531_20060815_CI_1001
            : When_querying_the_StudentProgramCohortDim_view
        {
            public Given_StudentProgramCohortDim_189890_867530023_Cohort_Program_2_1666_867531_867531_20060815_CI_1001(
                TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier =
                "189890_867530023_Cohort_Program_2_1666_867531_867531_20060815_CI_1001";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentProgramCohortDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_StudentProgramCohortDim_189891_867530024_Cohort_Program_3_1666_867533_867533_20060815_CI_1004
            : When_querying_the_StudentProgramCohortDim_view
        {
            public Given_StudentProgramCohortDim_189891_867530024_Cohort_Program_3_1666_867533_867533_20060815_CI_1004(
                TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier =
                "189891_867530024_Cohort_Program_3_1666_867533_867533_20060815_CI_1004";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentProgramCohortDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_StudentProgramCohortDim_189894_867530027_Cohort_Program_6_1666_867536_867536_20060815_CI_1007
            : When_querying_the_StudentProgramCohortDim_view
        {
            public Given_StudentProgramCohortDim_189894_867530027_Cohort_Program_6_1666_867536_867536_20060815_CI_1007(
                TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier =
                "189894_867530027_Cohort_Program_6_1666_867536_867536_20060815_CI_1007";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentProgramCohortDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_StudentProgramCohortDim_189895_867530027_Cohort_Program_6_1666_867536_867536_20060815_CI_1007
            : When_querying_the_StudentProgramCohortDim_view
        {
            public Given_StudentProgramCohortDim_189895_867530027_Cohort_Program_6_1666_867536_867536_20060815_CI_1007(
                TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier =
                "189895_867530027_Cohort_Program_6_1666_867536_867536_20060815_CI_1007";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentProgramCohortDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_no_records()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_return_no_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }


        public class Given_StudentProgramCohortDim_189896_867530028_Cohort_Program_8_1666_867538_867538_20060815_CI_1009
            : When_querying_the_StudentProgramCohortDim_view
        {
            public Given_StudentProgramCohortDim_189896_867530028_Cohort_Program_8_1666_867538_867538_20060815_CI_1009(
                TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier =
                "189896_867530028_Cohort_Program_8_1666_867538_867538_20060815_CI_1009";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentProgramCohortDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramCohortDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_StudentProgramCohortDim_189899_867530029_Cohort_Program_9_1666_867539_867539_20060815_CI_1010
            : When_querying_the_StudentProgramCohortDim_view
        {
            public Given_StudentProgramCohortDim_189899_867530029_Cohort_Program_9_1666_867539_867539_20060815_CI_1010(
                TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier =
                "189899_867530029_Cohort_Program_9_1666_867539_867539_20060815_CI_1010";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentProgramCohortDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
