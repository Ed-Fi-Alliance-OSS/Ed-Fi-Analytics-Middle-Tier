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
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.CandidateDimTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_CandidateDim_View : When_querying_a_view_ds3_3
    {
        protected const string TestCasesFolder = "TestCases.CandidateDim";
        protected const string TestCasesDataFileName = "0000_CandidateDim_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_view_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [SetUpFixture]
        public class SetupCandidateDimTestCase
            : When_querying_the_CandidateDim_View
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<CandidateDim>(TestCasesFolder, TestCasesDataFileName, Component.EPP);
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_candidateKey_1000042
        : When_querying_the_CandidateDim_View
        {
            public Given_candidateKey_1000042(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "c1000042";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_CandidateKey_should_be_1000042()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_CandidateKey_should_be_1000042.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_BeginDate_should_be_2011_04_03()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_BeginDate_should_be_2011_04_03.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_Cohort_should_be_2022()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_Cohort_should_be_2022.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_CohortYearTermDescription_should_be_Fall_Semester()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_CohortYearTermDescription_should_be_Fall_Semester.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_EconomicDisadvantaged_should_be_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_EconomicDisadvantaged_should_be_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_EducationOrganizationId_should_be_7()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_EducationOrganizationId_should_be_7.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_FirstName_should_be_Bryce()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_FirstName_should_be_Bryce.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_HispanicLatinoEthnicity_should_be_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_HispanicLatinoEthnicity_should_be_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_IssuanceDate_should_be_1997_03_17()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_IssuanceDate_should_be_1997_03_17.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_LastSurname_should_be_Beatty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_LastSurname_should_be_Beatty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_PersonId_should_be_0063560B5AC641DBBCCE4B121C5CA37B()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_PersonId_should_be_0063560B5AC641DBBCCE4B121C5CA37B.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_ProgramComplete_should_be_0()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_ProgramComplete_should_be_0.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_ProgramName_should_be_Science_Education_Secondary()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_ProgramName_should_be_Science_Education_Secondary.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_RaceDescriptorKey_should_be_1938()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_RaceDescriptorKey_should_be_1938.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_RaceDescriptor_should_be_1938()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_RaceDescriptor_should_be_1938.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_SexDescriptorKey_should_be_2144()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_SexDescriptorKey_should_be_2144.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_SexDescriptor_should_be_2144()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_SexDescriptor_should_be_2144.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_LastModifiedDate_should_be_2021_11_11()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_LastModifiedDate_should_be_2021_11_11.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_candidateKey_1000043
        : When_querying_the_CandidateDim_View
        {
            public Given_candidateKey_1000043(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "c1000043";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_ProgramComplete_should_be_1()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_ProgramComplete_should_be_1.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_RaceDescriptorKey_should_be_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_RaceDescriptorKey_should_be_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_RaceDescriptor_should_be_zero()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_RaceDescriptor_should_be_zero.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_EconomicDisadvantaged_should_be_zero()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_EconomicDisadvantaged_should_be_zero.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_HispanicLatinoEthnicity_should_be_zero()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_HispanicLatinoEthnicity_should_be_zero.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_StudentUSI_should_be_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_StudentUSI_should_be_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_PersonId_should_be_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_PersonId_should_be_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_IssuanceDate_should_be_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_IssuanceDate_should_be_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_CohortYearTermDescription_should_be_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_CohortYearTermDescription_should_be_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_LastModifiedDate_should_be_2021_11_11()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_LastModifiedDate_should_be_2021_11_11.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_candidateKey_1000044
        : When_querying_the_CandidateDim_View
        {
            public Given_candidateKey_1000044(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "c1000044";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_Cohort_should_be_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_Cohort_should_be_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_candidateKey_1000045
        : When_querying_the_CandidateDim_View
        {
            public Given_candidateKey_1000045(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "c1000045";

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CountResult>($"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_Cohort_should_be_empty()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_Cohort_should_be_empty.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_candidateKey_1000046
        : When_querying_the_CandidateDim_View
        {
            public Given_candidateKey_1000046(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "c1000046";

            [Test]
            public void Then_LastModifiedDate_should_be_2021_11_11()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_LastModifiedDate_should_be_2021_11_11.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_candidateKey_1000047
        : When_querying_the_CandidateDim_View
        {
            public Given_candidateKey_1000047(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            private readonly string _caseIdentifier = "c1000047";

            [Test]
            public void Then_LastModifiedDate_should_be_2021_11_11()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<CandidateDim>($"{TestCasesFolder}.{_caseIdentifier}_LastModifiedDate_should_be_2021_11_11.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
