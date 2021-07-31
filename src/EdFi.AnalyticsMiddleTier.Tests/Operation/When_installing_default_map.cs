// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Common;
using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;

namespace EdFi.AnalyticsMiddleTier.Tests.Operation.CollectionViews
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [NonParallelizable]
    public abstract class When_installing_default_map : TestCaseBase
    {
        protected const string TestCasesFolder = "TestCases.DefaultMap";

        protected (bool success, string errorMessage) Result;
        protected When_installing_default_map(TestHarnessBase dataStandard) : base(dataStandard) { }

        [OneTimeSetUp]
        public void Act()
        {
            Result = DataStandard.LoadTestCaseData<LocalEducationAgencyDim>(
                $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.0000_descriptormap_case_Data_Load.xml");
            Result.success.ShouldBeTrue($"Error while loading descriptor data: '{Result.errorMessage}'");
            
            Result = DataStandard.Install(10);
            Result.success.ShouldBeTrue($"Error while installing Base and DefaultMap: '{Result.errorMessage}'");
        }

        public class Given_descriptor_map
            : When_installing_default_map
        {
            public Given_descriptor_map(TestHarnessBase dataStandard) : base(dataStandard) { }
            [Test]
            public void Then_view_should_match_column_dictionary()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.descriptormap_should_match_column_dictionary.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_rows()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.descriptormap_should_match_column_dictionary.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
        public class Given_type_map
            : When_installing_default_map
        {
            public Given_type_map(TestHarnessBase dataStandard) : base(dataStandard) { }
            [Test]
            public void Then_view_should_match_column_dictionary()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.typemap_should_match_column_dictionary.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_rows()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.typemap_should_return_have_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
