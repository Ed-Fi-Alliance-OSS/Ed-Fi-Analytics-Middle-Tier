// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Common;
using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.StudentDataAuthorizationTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_StudentDataAuthorization_view : When_querying_a_view_postgres
    {
        protected const string TestCasesFolder = "TestCases.StudentDataAuthorization";
        protected const string TestCasesDataFileName = "0000_StudentDataAuthorization_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_view_should_match_column_dictionary.json");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }
        [SetUpFixture]
        public class SetupStudentDataAuthorizationTestCase
            : When_querying_the_StudentDataAuthorization_view
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<StudentDataAuthorization>(TestCasesFolder, TestCasesDataFileName, Component.RLS);
        }
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class When_querying_the_StudentDataAuthorization_view_custom
            : When_querying_the_StudentDataAuthorization_view
        {
            public When_querying_the_StudentDataAuthorization_view_custom(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
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
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentDataAuthorization>($"{TestCasesFolder}.{DataStandard.DataStandardEngine}.When_querying_sectionId.json");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
