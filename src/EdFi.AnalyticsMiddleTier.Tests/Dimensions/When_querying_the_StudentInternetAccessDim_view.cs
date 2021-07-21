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
    public abstract class When_querying_the_StudentInternetAccessDim_view : When_querying_a_view_ds3
    {
        protected const string TestCasesFolder = "TestCases.StudentInternetAccessDim";

        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            DataStandard.PrepareDatabase();
        }

        [OneTimeSetUp]
        public void Act()
        {
            Result = DataStandard.LoadTestCaseData<GradingPeriodDim>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.0000_StudentInternetAccessDim_Data_Load.xml");
            Result.success.ShouldBeTrue($"Error while loading data: '{Result.errorMessage}'");

            Result = DataStandard.Install();
            Result.success.ShouldBeTrue($"Error while installing Base: '{Result.errorMessage}'");
        }

        public class Given_default_records_When_querying_the_StudentInternetAccessDim_view
        : When_querying_the_StudentInternetAccessDim_view
        {
            public Given_default_records_When_querying_the_StudentInternetAccessDim_view(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_view_should_match_column_dictionary()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.should_match_column_dictionary.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_return_two_records()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.should_return_two_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DeviceAccess()
            {
                
               (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.should_have_DeviceAccess.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DigitalDevice()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.should_have_DigitalDevice.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_InternetAccessInResidence()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.should_have_InternetAccessInResidence.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_InternetPerformance()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.should_have_InternetPerformance.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentInternetAccessDim>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentInternetAccessDim>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SecondStudent()
            {
                (bool success, string errorMessage) testResult = DataStandard
                    .RunTestCase<StudentInternetAccessDim>(
                        $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.should_have_SecondStudent.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }


    }
}
