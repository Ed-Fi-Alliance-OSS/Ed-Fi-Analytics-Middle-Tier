﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;
using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Common;
using CommonLib = EdFi.AnalyticsMiddleTier.Common;

namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_StudentProgramCohortDim_view : When_querying_a_view
    {
        protected const string TestCasesFolder = "TestCases.StudentProgramCohortDim";

        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
            {
                Assert.Ignore($"The StudentProgramCohortDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
            }
            else
            {
                DataStandard.PrepareDatabase();
            }
        }

        [OneTimeSetUp]
        public void Act()
        {
            if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
            {
                Assert.Ignore(
                    $"The StudentProgramCohortDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
            }
            else
            {
                Result = DataStandard.LoadTestCaseData<UserDim>($"{TestCasesFolder}.0000_StudentProgramCohortDim_Data_Load.xml");
                Result.success.ShouldBeTrue($"Error while loading data: '{Result.errorMessage}'");

                Result = DataStandard.Install(10, Component.Equity);
                Result.success.ShouldBeTrue($"Error while installing Base and Equity: '{Result.errorMessage}'");
            }
        }

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.0001_StudentProgramCohortDim_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        public class Given_StudentProgramCohortDim_189889_867530022_Cohort_Program_1_1666_867530_867530_20060814_CI_1000
        : When_querying_the_StudentProgramCohortDim_view
        {
            public Given_StudentProgramCohortDim_189889_867530022_Cohort_Program_1_1666_867530_867530_20060814_CI_1000(TestHarness dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "189889_867530022_Cohort_Program_1_1666_867530_867530_20060814_CI_1000";

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
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentProgramCohortKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentProgramCohortDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentProgramCohortKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolProgramKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentProgramCohortDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolProgramKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentProgramCohortDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_CohortDescription()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentProgramCohortDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_CohortDescription.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ProgramName()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentProgramCohortDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ProgramName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentProgramCohortDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_StudentProgramCohortDim_189890_867530023_Cohort_Program_2_1666_867531_867531_20060815_CI_1001
        : When_querying_the_StudentProgramCohortDim_view
        {
            public Given_StudentProgramCohortDim_189890_867530023_Cohort_Program_2_1666_867531_867531_20060815_CI_1001(TestHarness dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "189890_867530023_Cohort_Program_2_1666_867531_867531_20060815_CI_1001";

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
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }


            public class Given_StudentProgramCohortDim_189891_867530024_Cohort_Program_3_1666_867533_867533_20060815_CI_1004
            : When_querying_the_StudentProgramCohortDim_view
            {
                public Given_StudentProgramCohortDim_189891_867530024_Cohort_Program_3_1666_867533_867533_20060815_CI_1004(TestHarness dataStandard) => SetDataStandard(dataStandard);

                private const string _caseIdentifier = "189891_867530024_Cohort_Program_3_1666_867533_867533_20060815_CI_1004";

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
                    (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
            }

            public class Given_StudentProgramCohortDim_189894_867530027_Cohort_Program_6_1666_867536_867536_20060815_CI_1007
            : When_querying_the_StudentProgramCohortDim_view
            {
                public Given_StudentProgramCohortDim_189894_867530027_Cohort_Program_6_1666_867536_867536_20060815_CI_1007(TestHarness dataStandard) => SetDataStandard(dataStandard);

                private const string _caseIdentifier = "189894_867530027_Cohort_Program_6_1666_867536_867536_20060815_CI_1007";

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
                    (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
            }

            public class Given_StudentProgramCohortDim_189895_867530027_Cohort_Program_6_1666_867536_867536_20060815_CI_1007
            : When_querying_the_StudentProgramCohortDim_view
            {
                public Given_StudentProgramCohortDim_189895_867530027_Cohort_Program_6_1666_867536_867536_20060815_CI_1007(TestHarness dataStandard) => SetDataStandard(dataStandard);

                private const string _caseIdentifier = "189895_867530027_Cohort_Program_6_1666_867536_867536_20060815_CI_1007";

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
                    (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_no_records.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
            }


            public class Given_StudentProgramCohortDim_189896_867530028_Cohort_Program_8_1666_867538_867538_20060815_CI_1009
            : When_querying_the_StudentProgramCohortDim_view
            {
                public Given_StudentProgramCohortDim_189896_867530028_Cohort_Program_8_1666_867538_867538_20060815_CI_1009(TestHarness dataStandard) => SetDataStandard(dataStandard);

                private const string _caseIdentifier = "189896_867530028_Cohort_Program_8_1666_867538_867538_20060815_CI_1009";

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
                    (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }

                [Test]
                public void Then_should_have_LastModifiedDate()
                {
                    (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentProgramCohortDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
            }

            public class Given_StudentProgramCohortDim_189899_867530029_Cohort_Program_9_1666_867539_867539_20060815_CI_1010
            : When_querying_the_StudentProgramCohortDim_view
            {
                public Given_StudentProgramCohortDim_189899_867530029_Cohort_Program_9_1666_867539_867539_20060815_CI_1010(TestHarness dataStandard) => SetDataStandard(dataStandard);

                private const string _caseIdentifier = "189899_867530029_Cohort_Program_9_1666_867539_867539_20060815_CI_1010";

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
                    (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
            }
        }
    }
}
