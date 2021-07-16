// SPDX-License-Identifier: Apache-2.0
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
    public abstract class When_querying_the_StaffClassificationDescriptorScopeList : When_querying_a_view
    {
        protected const string TestCasesFolder = "TestCases.StaffClassificationDescriptorScopeList";

        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            DataStandard.PrepareDatabase();
        }

        [OneTimeSetUp]
        public void Act()
        {
            Result = DataStandard.LoadTestCaseData<StudentDataAuthorization>($"{TestCasesFolder}.0000_StaffClassificationDescriptorScopeList_Data_Load.xml");
            Result.success.ShouldBeTrue($"Error while loading data: '{Result.errorMessage}'");

            Result = DataStandard.Install(10, Component.Qews);
            Result.success.ShouldBeTrue($"Error while installing Base and RLS: '{Result.errorMessage}'");
        }

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.0001_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
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