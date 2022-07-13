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
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.ClassPeriodDimTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_ClassPeriodDim_view_base : When_querying_a_view_postgres
    {
        protected const string TestCasesFolder = "TestCases.ClassPeriodDim";
        protected const string TestCasesDataFileName = "0000_ClassPeriodDim_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_ClassPeriodDim_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }
        [SetUpFixture]
        public class SetupAcademicTimePeriodDimTestCase
            : When_querying_the_ClassPeriodDim_view_base
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<ClassPeriodDim>(TestCasesFolder, TestCasesDataFileName);
        }
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class When_querying_the_ClassPeriodDim_view
            : When_querying_the_ClassPeriodDim_view_base
        {
            public When_querying_the_ClassPeriodDim_view(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "ClassPeriod";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_not_return_any_record()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_not_return_any_record.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
                else
                {
                    Assert.Ignore("Only for Data Standard 2.");
                }
            }

            [Test]
            public void Then_should_have_ClassPeriodKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ClassPeriodDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_ClassPeriodKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SectionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ClassPeriodDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_SectionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ClassPeriodName()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ClassPeriodDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_ClassPeriodName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LocalCourseCode()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ClassPeriodDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_LocalCourseCode.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolId()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ClassPeriodDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_SchoolId.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolYear()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ClassPeriodDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_SchoolYear.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SectionIdentifier()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<ClassPeriodDim>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_SectionIdentifier.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SessionName()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<ClassPeriodDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_SessionName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
