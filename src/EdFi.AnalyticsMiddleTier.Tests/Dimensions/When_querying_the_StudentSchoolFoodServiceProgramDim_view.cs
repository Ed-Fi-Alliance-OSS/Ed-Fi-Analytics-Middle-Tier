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
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.StudentSchoolFoodServiceProgramDimTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_StudentSchoolFoodServiceProgramDim_view : When_querying_a_view_postgres_ds3
    {
        protected const string TestCasesFolder = "TestCases.StudentSchoolFoodServiceProgramDim";
        protected const string TestCasesDataFileName = "0000_StudentSchoolFoodServiceProgramDim_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_StudentSchoolFoodServiceProgramDim_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [SetUpFixture]
        public class SetupStudentSchoolFoodServiceProgramDimTestCase
                : When_querying_the_StudentSchoolFoodServiceProgramDim_view
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<StudentSchoolFoodServiceProgramDim>(TestCasesFolder, TestCasesDataFileName, Component.Equity);
        }

        public class Given_StudentSchoolFoodServiceProgramDim_189889_867530022_Food_Service_1_1666_867530_867530_20060814_2892
        : When_querying_the_StudentSchoolFoodServiceProgramDim_view
        {
            public Given_StudentSchoolFoodServiceProgramDim_189889_867530022_Food_Service_1_1666_867530_867530_20060814_2892(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "189889_867530022";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentSchoolFoodServiceProgramDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolFoodServiceProgramKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentSchoolFoodServiceProgramDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolFoodServiceProgramKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolProgramKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentSchoolFoodServiceProgramDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolProgramKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentSchoolFoodServiceProgramDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ProgramName()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentSchoolFoodServiceProgramDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_ProgramName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolFoodServiceProgramServiceDescriptor()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentSchoolFoodServiceProgramDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolFoodServiceProgramServiceDescriptor.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentSchoolFoodServiceProgramDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_StudentSchoolFoodServiceProgramDim_189890_867530023_Food_Service_2_1666_867531_867531_20060815_2892
        : When_querying_the_StudentSchoolFoodServiceProgramDim_view
        {
            public Given_StudentSchoolFoodServiceProgramDim_189890_867530023_Food_Service_2_1666_867531_867531_20060815_2892(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "189890_867530023";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentSchoolFoodServiceProgramDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_StudentSchoolFoodServiceProgramDim_189899_867530032_Food_Service_1_1666_867535_867535_20060814_2892
        : When_querying_the_StudentSchoolFoodServiceProgramDim_view
        {
            public Given_StudentSchoolFoodServiceProgramDim_189899_867530032_Food_Service_1_1666_867535_867535_20060814_2892(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "189899_867530032";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentSchoolFoodServiceProgramDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
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
