// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Tests.Classes;
using EdFi.AnalyticsMiddleTier.Common;
using NUnit.Framework;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.TermDescriptorDimTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_TermDescriptorDim_view : When_querying_a_view_ds3_3
    {
        protected const string TestCasesFolder = "TestCases.TermDescriptorDim";
        protected const string TestCasesDataFileName = "0000_TermDescriptorDim_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_view_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [SetUpFixture]
        public class SetupTermDescriptorDimTestCase
            : When_querying_the_TermDescriptorDim_view
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<TermDescriptorDim>(TestCasesFolder, TestCasesDataFileName, Component.EPP);
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_TermDescriptor_3570
        : When_querying_the_TermDescriptorDim_view
        {
            public Given_TermDescriptor_3570(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "3570";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_TermDescriptorKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TermDescriptorDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_TermDescriptorKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_CodeValue()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TermDescriptorDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_CodeValue.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TermDescriptorDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
