// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.AnalyticsMiddleTier.Common;
using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;
using System.Diagnostics.CodeAnalysis;
using CommonLib = EdFi.AnalyticsMiddleTier.Common;

// ReSharper disable once CheckNamespace
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.StudentDisciplineActionDimTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_StudentDisciplineActionDim_view : When_querying_a_view_postgres_ds3
    {
        protected const string TestCasesFolder = "TestCases.StudentDisciplineActionDim";
        protected const string TestCasesDataFileName = "0000_StudentDisciplineActionDim_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_StudentDisciplineActionDim_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }
        [SetUpFixture]
        public class SetupStudentDisciplineActionTestCase
            : When_querying_the_StudentDisciplineActionDim_view
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<StudentDisciplineActionDim>(TestCasesFolder, TestCasesDataFileName, Component.Equity);
        }
        public class Given_studentDisciplineAction_193964_628530001
        : When_querying_the_StudentDisciplineActionDim_view
        {
            public Given_studentDisciplineAction_193964_628530001(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "193964_628530001";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentDisciplineActionDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DisciplineDateKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentDisciplineActionDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_DisciplineDateKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DisciplineActionDescription()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentDisciplineActionDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_DisciplineActionDescription.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentDisciplineActionKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentDisciplineActionDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentDisciplineActionKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_SchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentDisciplineActionDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_SchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_UserKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentDisciplineActionDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_UserKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentDisciplineActionDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentDisciplineActionDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentDisciplineActionDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_studentDisciplineAction_205270_628530001
       : When_querying_the_StudentDisciplineActionDim_view
        {
            public Given_studentDisciplineAction_205270_628530001(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "205270_628530001";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentDisciplineActionDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_UserKey_Empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentDisciplineActionDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_UserKey_Empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentDisciplineActionDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_studentDisciplineAction_11051_20111005_100082817
       : When_querying_the_StudentDisciplineActionDim_view
        {
            public Given_studentDisciplineAction_11051_20111005_100082817(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "11051_20111005_100082817";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentDisciplineActionDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_not_return_any_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

        }

        public class Given_studentDisciplineAction_11061_20111105_100082817
       : When_querying_the_StudentDisciplineActionDim_view
        {
            public Given_studentDisciplineAction_11061_20111105_100082817(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "11061_20111105_100082817";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentDisciplineActionDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_not_return_any_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

        }

        public class Given_studentDisciplineAction_11061_20111005_100098415
       : When_querying_the_StudentDisciplineActionDim_view
        {
            public Given_studentDisciplineAction_11061_20111005_100098415(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "11061_20111005_100098415";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentDisciplineActionDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_not_return_any_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_studentDisciplineAction_11431_20111007_213503_867530193
       : When_querying_the_StudentDisciplineActionDim_view
        {
            public Given_studentDisciplineAction_11431_20111007_213503_867530193(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "11431_20111007_213503_867530193";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentDisciplineActionDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<StudentDisciplineActionDim>($"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        public class Given_studentDisciplineAction_10463_20111004_202109_867530022
       : When_querying_the_StudentDisciplineActionDim_view
        {
            public Given_studentDisciplineAction_10463_20111004_202109_867530022(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            private const string _caseIdentifier = "10463_20111004_202109_867530022";

            [SetUp]
            public void IgnoreTestCase()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore(
                        $"The StudentDisciplineActionDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
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
