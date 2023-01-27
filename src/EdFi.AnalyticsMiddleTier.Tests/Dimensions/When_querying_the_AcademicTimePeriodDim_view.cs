// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.AcademicTimePeriodDimTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_AcademicTimePeriodDim_view : When_querying_a_view_postgres
    {
        protected const string TestCasesFolder = "TestCases.AcademicTimePeriodDim";
        protected const string TestCasesDataFileName = "0000_AcademicTimePeriodDim_Data_Load.xml";

        [SetUpFixture]
        public class SetupAcademicTimePeriodDimTestCase
            : When_querying_the_AcademicTimePeriodDim_view
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<AcademicTimePeriodDim>(TestCasesFolder, TestCasesDataFileName);
        }

        public class Given_default_record_When_querying_the_AcademicTimePeriodDim_view
        : When_querying_the_AcademicTimePeriodDim_view
        {
            public Given_default_record_When_querying_the_AcademicTimePeriodDim_view(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_view_should_match_column_dictionary()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.should_match_column_dictionary.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_AcademicTimePeriodKey()
            {

                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AcademicTimePeriodDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.should_have_AcademicTimePeriodKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_GradingPeriodKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<AcademicTimePeriodDim>($"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.should_have_GradingPeriodKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsCurrentSchoolYear()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<AcademicTimePeriodDim>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.should_have_IsCurrentSchoolYear.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate_based_on_GradingPeriod()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.should_have_LastModifiedDate_based_on_GradingPeriod.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate_based_on_Session()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.should_have_LastModifiedDate_based_on_Session.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate_based_on_SchoolYear()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.should_have_LastModifiedDate_based_on_SchoolYear.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<AcademicTimePeriodDim>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolYear()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.should_have_SchoolYear.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolYearName()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<AcademicTimePeriodDim>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.should_have_SchoolYearName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SessionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<AcademicTimePeriodDim>(
                        $"{TestCasesFolder}.{DataStandard.TestDataFolderName}.should_have_SessionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_TermName()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<AcademicTimePeriodDim>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.should_have_TermName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_additional_join_condition_test()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardBaseVersionFolderName}.additional_join_condition_test.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }


    }
}
