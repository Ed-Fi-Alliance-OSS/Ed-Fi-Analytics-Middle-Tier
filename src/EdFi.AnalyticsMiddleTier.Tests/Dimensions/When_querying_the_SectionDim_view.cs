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
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.SectionDimTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_SectionDim_view_base : When_querying_a_view_postgres
    {
        protected const string TestCasesFolder = "TestCases.SectionDim";
        protected const string TestCasesDataFileName = "0000_SectionDim_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_SectionDim_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [Test]
        public void Then_should_have_SectionKey()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.YTAR11_should_have_SectionKey.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [Test]
        public void Then_should_have_SectionName()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.YTAR11_should_have_SectionName.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [Test]
        public void Then_should_have_SessionName()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.YTAR11_should_have_SessionName.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [Test]
        public void Then_should_have_EducationalEnvironmentDescriptor()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.YTAR11_should_have_EducationalEnvironmentDescriptor.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [SetUpFixture]
        public class SetupAcademicTimePeriodDimTestCase
            : When_querying_the_SectionDim_view_base
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<SectionDim>(TestCasesFolder, TestCasesDataFileName);
        }

        public class When_querying_the_SectionDim_view
            : When_querying_the_SectionDim_view_base
        {
            public When_querying_the_SectionDim_view(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "YTAR11";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LocalCourseCode()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LocalCourseCode.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolYear()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolYear.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LocalEducationAgencyKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SectionDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LocalEducationAgencyKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SectionDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_CourseTitle()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SectionDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_CourseTitle.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SessionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<SectionDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.{_caseIdentifier}_should_have_SessionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class When_querying_the_SectionDim_V2_view
            : When_querying_the_SectionDim_view_base
        {
            public When_querying_the_SectionDim_V2_view(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [SetUp]
            public void SetUp()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds31) || DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds32))
                {
                    Assert.Ignore($"No validation needed because the query is different. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.0002_Should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_return_one_record_2()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.0003_Should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class When_querying_the_SectionDim_V3_view
            : When_querying_the_SectionDim_view_base
        {
            public When_querying_the_SectionDim_V3_view(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [SetUp]
            public void SetUp()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore($"No validation needed because the query is different. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.0002_Should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_return_one_record_2()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.0003_Should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_return_no_records()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.0004_Should_return_no_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_return_one_record_3()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.0005_Should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_return_one_record_4()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.0006_Should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_return_one_record_5()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.0007_Should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_return_one_record_6()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.0008_Should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_return_one_record_7()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.0009_Should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_return_one_record_8()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.0010_Should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
