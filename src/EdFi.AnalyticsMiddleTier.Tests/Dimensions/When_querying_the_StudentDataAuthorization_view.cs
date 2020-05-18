﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Common;
using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;

namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_StudentDataAuthorization_view : When_querying_a_view
    {
        protected const string TestCasesFolder = "TestCases.StudentDataAuthorization";

        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            DataStandard.PrepareDatabase();
        }

        [OneTimeSetUp]
        public void Act()
        {
            Result = DataStandard.LoadTestCaseData<StudentDataAuthorization>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.0000_StudentDataAuthorization_Data_Load.xml");
            Result.success.ShouldBeTrue($"Error while loading data: '{Result.errorMessage}'");

            Result = DataStandard.Install(10, Component.RLS);
            Result.success.ShouldBeTrue($"Error while installing Base and RLS: '{Result.errorMessage}'");
        }

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.0001_view_should_match_column_dictionary.json");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class When_querying_the_StudentDataAuthorization_view_custom
            : When_querying_the_StudentDataAuthorization_view
        {
            public When_querying_the_StudentDataAuthorization_view_custom(TestHarness dataStandard) => SetDataStandard(dataStandard);
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.When_querying_should_return_one_record.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_StudentKey_is_not_null()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentDataAuthorization>($"{TestCasesFolder}.When_querying_studentKey.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_SchoolKey_is_not_null()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentDataAuthorization>($"{TestCasesFolder}.When_querying_schoolKey.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_SectionId_is_not_null()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentDataAuthorization>($"{TestCasesFolder}.When_querying_sectionId.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}