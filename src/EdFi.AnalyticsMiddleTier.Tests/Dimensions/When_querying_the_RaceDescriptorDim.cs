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
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.RaceDescriptorDimTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_RaceDescriptorDim_view : When_querying_a_view_ds3_3
    {
        protected const string TestCasesFolder = "TestCases.RaceDescriptorDim";
        protected const string TestCasesDataFileName = "0000_RaceDescriptorDim_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_view_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [SetUpFixture]
        public class SetupRaceDescriptorDimTestCase
            : When_querying_the_RaceDescriptorDim_view
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<RaceDescriptorDim>(TestCasesFolder, TestCasesDataFileName, Component.EPP);
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_Race_1941
        : When_querying_the_RaceDescriptorDim_view
        {
            public Given_Race_1941(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "1941";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_RaceDescriptorKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<RaceDescriptorDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_RaceDescriptorKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_CodeValue()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<RaceDescriptorDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_CodeValue.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<RaceDescriptorDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
