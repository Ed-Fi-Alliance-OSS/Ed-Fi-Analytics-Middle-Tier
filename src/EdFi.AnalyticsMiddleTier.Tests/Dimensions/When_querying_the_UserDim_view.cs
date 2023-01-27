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
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.UserDimTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_UserDim_view : When_querying_a_view_postgres
    {
        protected const string TestCasesFolder = "TestCases.UserDim";
        protected const string TestCasesDataFileName = "0000_UserDim_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_UserDim_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [SetUpFixture]
        public class SetupUserDimTestCase
                : When_querying_the_UserDim_view
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<UserDim>(TestCasesFolder, TestCasesDataFileName, Component.RLS);
        }

        public class Given_user_11324
        : When_querying_the_UserDim_view
        {
            public Given_user_11324(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "11324";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_UserKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_UserKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_UserEmail()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_UserEmail.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_user_11358
            : When_querying_the_UserDim_view
        {
            public Given_user_11358(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "11358";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_UserKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_UserKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_UserEmail()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_UserEmail.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_user_11472
            : When_querying_the_UserDim_view
        {
            public Given_user_11472(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "11472";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_UserKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_UserKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_UserEmail()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_UserEmail.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<UserDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
