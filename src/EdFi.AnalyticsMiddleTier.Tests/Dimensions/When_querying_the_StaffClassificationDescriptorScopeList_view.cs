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
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.StaffClassificationDescriptorScopeListTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_StaffClassificationDescriptorScopeList : When_querying_a_view_postgres
    {
        protected const string TestCasesFolder = "TestCases.StaffClassificationDescriptorScopeList";
        protected const string TestCasesDataFileName = "0000_StaffClassificationDescriptorScopeList_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [SetUpFixture]
        public class SetupStaffClassificationDescriptorScopeListTestCase
            : When_querying_the_StaffClassificationDescriptorScopeList
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<StaffClassificationDescriptorScopeList>(TestCasesFolder, TestCasesDataFileName, Component.Qews);
        }

        public class Given_an_StaffClassificationDescriptorScopeList_District
            : When_querying_the_StaffClassificationDescriptorScopeList
        {
            public Given_an_StaffClassificationDescriptorScopeList_District(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "district";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_AuthorizationScopeName()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffClassificationDescriptorScopeList>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AuthorizationScopeName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_CodeValue()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffClassificationDescriptorScopeList>($"{TestCasesFolder}.{_caseIdentifier}_should_have_CodeValue.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
        public class Given_an_StaffClassificationDescriptorScopeList_School
            : When_querying_the_StaffClassificationDescriptorScopeList
        {
            public Given_an_StaffClassificationDescriptorScopeList_School(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "school";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_AuthorizationScopeName()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffClassificationDescriptorScopeList>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AuthorizationScopeName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_CodeValue()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffClassificationDescriptorScopeList>($"{TestCasesFolder}.{_caseIdentifier}_should_have_CodeValue.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
        public class Given_an_StaffClassificationDescriptorScopeList_Section
            : When_querying_the_StaffClassificationDescriptorScopeList
        {
            public Given_an_StaffClassificationDescriptorScopeList_Section(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "section";
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_AuthorizationScopeName()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffClassificationDescriptorScopeList>($"{TestCasesFolder}.{_caseIdentifier}_should_have_AuthorizationScopeName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_CodeValue()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StaffClassificationDescriptorScopeList>($"{TestCasesFolder}.{_caseIdentifier}_should_have_CodeValue.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
        public class Given_an_StaffClassificationDescriptorScopeList_UnexcusedAbsence
            : When_querying_the_StaffClassificationDescriptorScopeList
        {
            public Given_an_StaffClassificationDescriptorScopeList_UnexcusedAbsence(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private const string _caseIdentifier = "unexcusedabsence";
            [Test]
            public void Then_should_not_return_any_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
