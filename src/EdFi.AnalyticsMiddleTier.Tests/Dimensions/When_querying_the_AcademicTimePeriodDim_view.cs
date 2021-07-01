// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;

namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_AcademicTimePeriodDim_view : When_querying_a_view
    {
        protected const string TestCasesFolder = "TestCases.AcademicTimePeriodDim";

        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            DataStandard.PrepareDatabase();
        }

        [OneTimeSetUp]
        public void Act()
        {
            Result = DataStandard.LoadTestCaseData<GradingPeriodDim>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.0000_AcademicTimePeriodDim_Data_Load.xml");
            Result.success.ShouldBeTrue($"Error while loading data: '{Result.errorMessage}'");

            Result = DataStandard.Install();
            Result.success.ShouldBeTrue($"Error while installing Base: '{Result.errorMessage}'");
        }

        public class Given_default_record_When_querying_the_AcademicTimePeriodDim_view
        : When_querying_the_AcademicTimePeriodDim_view
        {
            public Given_default_record_When_querying_the_AcademicTimePeriodDim_view(TestHarness dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_view_should_match_column_dictionary()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.should_match_column_dictionary.xml");
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
                
               (bool success, string errorMessage) testResult = DataStandard.RunTestCase<AcademicTimePeriodDim>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.should_have_AcademicTimePeriodKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_GradingPeriodKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<AcademicTimePeriodDim>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.should_have_GradingPeriodKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_IsCurrentSchoolYear()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<AcademicTimePeriodDim>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.should_have_IsCurrentSchoolYear.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<AcademicTimePeriodDim>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<AcademicTimePeriodDim>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolYearKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<AcademicTimePeriodDim>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.should_have_SchoolYearKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolYearName()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<AcademicTimePeriodDim>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.should_have_SchoolYearName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SessionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<AcademicTimePeriodDim>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.should_have_SessionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_TermName()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<AcademicTimePeriodDim>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.should_have_TermName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
        

    }
}
