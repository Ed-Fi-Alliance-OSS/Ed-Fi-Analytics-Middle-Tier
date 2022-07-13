// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;
using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Common;

// ReSharper disable once CheckNamespace
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.UserStudentDataAuthorizationTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_UserStudentDataAuthorization_view : When_querying_a_view_postgres
    {
        protected const string TestCasesFolder = "TestCases.UserStudentDataAuthorization";
        protected const string TestCasesDataFileName = "0000_UserStudentDataAuthorization_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_UserStudentDataAuthorization_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [SetUpFixture]
        public class SetupUserStudentDataAuthorizationTestCase
                : When_querying_the_UserStudentDataAuthorization_view
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<UserStudentDataAuthorization>(TestCasesFolder, TestCasesDataFileName, Component.RLS);
        }

        public class Given_UserStudentDataAuthorization_11324_190019
        : When_querying_the_UserStudentDataAuthorization_view
        {
            public Given_UserStudentDataAuthorization_11324_190019(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "11324_190019";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_UserStudentDataAuthorization_11324_197085
            : When_querying_the_UserStudentDataAuthorization_view
        {
            public Given_UserStudentDataAuthorization_11324_197085(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "11324_197085";

            [Test]
            public void Then_should_not_return_any_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_UserStudentDataAuthorization_11324_218269
            : When_querying_the_UserStudentDataAuthorization_view
        {
            public Given_UserStudentDataAuthorization_11324_218269(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "11324_218269";

            [Test]
            public void Then_should_not_return_any_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_UserStudentDataAuthorization_11453_218269
            : When_querying_the_UserStudentDataAuthorization_view
        {
            public Given_UserStudentDataAuthorization_11453_218269(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "11453_218269";

            [Test]
            public void Then_should_not_return_any_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_UserStudentDataAuthorization_11492_190019
            : When_querying_the_UserStudentDataAuthorization_view
        {
            public Given_UserStudentDataAuthorization_11492_190019(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "11492_190019";

            [Test]
            public void Then_should_not_return_any_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_UserStudentDataAuthorization_11721_190019
            : When_querying_the_UserStudentDataAuthorization_view
        {
            public Given_UserStudentDataAuthorization_11721_190019(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "11721_190019";

            [Test]
            public void Then_should_not_return_any_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_UserStudentDataAuthorization_11721_218268
            : When_querying_the_UserStudentDataAuthorization_view
        {
            public Given_UserStudentDataAuthorization_11721_218268(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "11721_218268";

            [Test]
            public void Then_should_not_return_any_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_UserStudentDataAuthorization_11721_218269
            : When_querying_the_UserStudentDataAuthorization_view
        {
            public Given_UserStudentDataAuthorization_11721_218269(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "11721_218269";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_UserStudentDataAuthorization_12143_197085
            : When_querying_the_UserStudentDataAuthorization_view
        {
            public Given_UserStudentDataAuthorization_12143_197085(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "12143_197085";

            [Test]
            public void Then_should_not_return_any_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_UserStudentDataAuthorization_12143_197184
            : When_querying_the_UserStudentDataAuthorization_view
        {
            public Given_UserStudentDataAuthorization_12143_197184(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "12143_197184";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_UserStudentDataAuthorization_12497_197184
            : When_querying_the_UserStudentDataAuthorization_view
        {
            public Given_UserStudentDataAuthorization_12497_197184(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "12497_197184";

            [Test]
            public void Then_should_not_return_any_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_UserStudentDataAuthorization_14162_218269
            : When_querying_the_UserStudentDataAuthorization_view
        {
            public Given_UserStudentDataAuthorization_14162_218269(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "14162_218269";

            [Test]
            public void Then_should_not_return_any_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_UserStudentDataAuthorization_13493_218269
            : When_querying_the_UserStudentDataAuthorization_view
        {
            public Given_UserStudentDataAuthorization_13493_218269(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "13493_218269";

            [Test]
            public void Then_should_not_return_any_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_UserStudentDataAuthorization_11721_218271
            : When_querying_the_UserStudentDataAuthorization_view
        {
            public Given_UserStudentDataAuthorization_11721_218271(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "11721_218271";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
