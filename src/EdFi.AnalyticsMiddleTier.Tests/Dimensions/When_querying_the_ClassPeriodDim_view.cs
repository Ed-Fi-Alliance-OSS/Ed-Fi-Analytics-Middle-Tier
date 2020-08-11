// SPDX-License-Identifier: Apache-2.0
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
    public abstract class When_querying_the_ClassPeriodDim_view_base : When_querying_a_view
    {
        protected const string TestCasesFolder = "TestCases.ClassPeriodDim";

        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            DataStandard.PrepareDatabase();
        }

        [OneTimeSetUp]
        public void Act()
        {
            Result = DataStandard.LoadTestCaseData<ClassPeriodDim>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.0000_ClassPeriodDim_Data_Load.xml");
            Result.success.ShouldBeTrue($"Error while loading data: '{Result.errorMessage}'");

            // Install the default map so that we can test for school address
            Result = DataStandard.Install(10);
            Result.success.ShouldBeTrue($"Error while installing Base: '{Result.errorMessage}'");
        }

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.0001_ClassPeriodDim_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class When_querying_the_ClassPeriodDim_view
            : When_querying_the_ClassPeriodDim_view_base
        {
            public When_querying_the_ClassPeriodDim_view(TestHarness dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "ClassPeriod";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_not_return_any_record()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_not_return_any_record.xml");
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
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserDim>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_ClassPeriodKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ClassPeriodName()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserDim>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_ClassPeriodName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LocalCourseCode()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserDim>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_LocalCourseCode.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolId()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserDim>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_SchoolId.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolYear()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserDim>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_SchoolYear.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SectionIdentifier()
            {
                if (!DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    (bool success, string errorMessage) testResult =
                        DataStandard.RunTestCase<UserDim>(
                            $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_SectionIdentifier.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
                else
                {
                    Assert.Ignore("Data Standard 2 does not have SectionIdentifier on the ClassPeriodDim view.");
                }
            }

            [Test]
            public void Then_should_have_SessionName()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserDim>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_SessionName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_TermDescriptorId()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    (bool success, string errorMessage) testResult =
                        DataStandard.RunTestCase<UserDim>(
                            $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_TermDescriptorId.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
                else
                {
                    Assert.Ignore("Only Data Standard 2 have TermDescriptorId on the ClassPeriodDim view.");
                }
            }

            [Test]
            public void Then_should_have_UniqueSectionCode()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    (bool success, string errorMessage) testResult =
                        DataStandard.RunTestCase<UserDim>(
                            $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_UniqueSectionCode.xml");
                    testResult.success.ShouldBe(true, testResult.errorMessage);
                }
                else
                {
                    Assert.Ignore("Only Data Standard 2 have UniqueSectionCode on the ClassPeriodDim view.");
                }
            }
        }
    }
}