// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;
using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Common;
using CommonLib = EdFi.AnalyticsMiddleTier.Common;

// ReSharper disable once CheckNamespace
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.FeederSchoolDimTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_FeederSchoolDim_view : When_querying_a_view_postgres_ds3
    {
        protected const string TestCasesFolder = "TestCases.FeederSchoolDim";
        protected const string TestCasesDataFileName = "0000_FeederSchoolDim_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_FeederSchoolDim_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [SetUpFixture]
        public class SetupFeederSchoolDimTestCase
            : When_querying_the_FeederSchoolDim_view
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<FeederSchoolDim>(TestCasesFolder, TestCasesDataFileName, Component.Equity);
        }

        public class Given_feederSchoolDim_850786060_628530
        : When_querying_the_FeederSchoolDim_view
        {
            public Given_feederSchoolDim_850786060_628530(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "850786060_628530";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The FeederSchoolDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_FeederSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<FeederSchoolDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_FeederSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_FeederSchoolName()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<FeederSchoolDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_FeederSchoolName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_FeederSchoolUniqueKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<FeederSchoolDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_FeederSchoolUniqueKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<FeederSchoolDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentDisciplineActionDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
        public class Given_feederSchoolDim_867530_850786060
        : When_querying_the_FeederSchoolDim_view
        {
            public Given_feederSchoolDim_867530_850786060(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "867530_850786060";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The FeederSchoolDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_FeederSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<FeederSchoolDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_FeederSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_FeederSchoolName()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<FeederSchoolDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_FeederSchoolName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_FeederSchoolUniqueKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<FeederSchoolDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_FeederSchoolUniqueKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<FeederSchoolDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentDisciplineActionDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
        public class Given_feederSchoolDim_628530_867530
        : When_querying_the_FeederSchoolDim_view
        {
            public Given_feederSchoolDim_628530_867530(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "628530_867530";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The FeederSchoolDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_not_return_any_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
