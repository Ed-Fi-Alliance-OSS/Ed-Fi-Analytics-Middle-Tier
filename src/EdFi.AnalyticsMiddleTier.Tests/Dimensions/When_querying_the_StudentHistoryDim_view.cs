// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;
using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Common;

namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_StudentHistoryDim_view : When_querying_a_view_ds3
    {
        protected const string TestCasesFolder = "TestCases.StudentHistoryDim";

        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            DataStandard.PrepareDatabase();
        }

        [OneTimeSetUp]
        public void Act()
        {
            Result = DataStandard.LoadTestCaseData<ClassPeriodDim>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.0000_StudentHistoryDim_Data_Load.xml");
            Result.success.ShouldBeTrue($"Error while loading data: '{Result.errorMessage}'");

            Result = DataStandard.Install(10, Component.Chrab);
            Result = DataStandard.Install(10, Component.Ews);
            Result = DataStandard.Install(10, Component.Equity);
            Result.success.ShouldBeTrue($"Error while installing Base: '{Result.errorMessage}'");
        }

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.0001_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        public class Given_StudentHistoryDim_197049_867530023
        : When_querying_the_StudentHistoryDim_view
        {
            public Given_StudentHistoryDim_197049_867530023(TestHarness dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "197049_867530023";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentHistoryDim>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentHistoryDim>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentHistoryDim>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_GradeSummary()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentHistoryDim>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_GradeSummary.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_CurrentSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentHistoryDim>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_CurrentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_AttendanceRate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentHistoryDim>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_AttendanceRate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_ReferralsAndSuspensions()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentHistoryDim>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_ReferralsAndSuspensions.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_EnrollmentHistory()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentHistoryDim>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.{_caseIdentifier}_should_have_EnrollmentHistory.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }           
        }

       
    }
}
