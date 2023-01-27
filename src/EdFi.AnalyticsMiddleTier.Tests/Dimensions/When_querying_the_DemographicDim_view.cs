// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;
using CommonLib = EdFi.AnalyticsMiddleTier.Common;

// ReSharper disable once CheckNamespace
namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions.DemographicDimTestGroup
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_DemographicDim_view : When_querying_a_view_postgres
    {
        protected const string TestCasesFolder = "TestCases.DemographicDim";
        protected const string TestCasesDataFileName = "0000_DemographicDim_Data_Load.xml";

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult = DataStandard.RunTestCase<TableColumns>($"{TestCasesFolder}.{DataStandard.TestDataFolderName}.0001_DemographicDim_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [SetUpFixture]
        public class SetupDemographicDimTestCase
            : When_querying_the_DemographicDim_view
        {
            [OneTimeSetUp]
            public void PrepareDatabase() => PrepareTestData<DemographicDim>(TestCasesFolder, TestCasesDataFileName);
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_CohortYear_Eighth_grade_and_School_year_2019
            : When_querying_the_DemographicDim_view
        {

            private const string _caseIdentifier = "CohortYear_2019_Eighth_grade";
            public Given_CohortYear_Eighth_grade_and_School_year_2019(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<DemographicDim>($"{TestCasesFolder}.{_caseIdentifier}_DemographicKey_should_be_unique.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicParentKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicLabel_should_be_2019-Eighth_grade.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicLabel()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicParentKey_should_be_CohortYear.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_ShortDescription_should_be_Eight_grade()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_ShortDescription_should_be_Eight_grade.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_CohortYear_School_year_2019
            : When_querying_the_DemographicDim_view
        {

            private const string _caseIdentifier = "CohortYear_2019";
            public Given_CohortYear_School_year_2019(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_have_DemographicParentKey_combinations()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicKey_should_return_possible_combinations.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicLabel_combinations()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicLabel_should_return_possible_combinations.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }



        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_CohortYear_Eleventh_grade
            : When_querying_the_DemographicDim_view
        {

            private const string _caseIdentifier = "CohortYear_Eleven_Grade";
            public Given_CohortYear_Eleventh_grade(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_have_DemographicParentKey_combinations()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicKey_should_return_possible_combinations.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicLabel_combinations()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicLabel_should_return_possible_combinations.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_DisabilityDesignation_Other
            : When_querying_the_DemographicDim_view
        {

            private const string _caseIdentifier = "DisabilityDesignation_Other";
            public Given_DisabilityDesignation_Other(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [SetUp]
            public void SetUp()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore($"The DemographicDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<DemographicDim>($"{TestCasesFolder}.{_caseIdentifier}_DemographicKey_should_be_unique.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicParentKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicParentKey_should_be_DisabilityDesignation.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicLabel()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicLabel_should_be_Other.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_ShortDescription_should_be_Other()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_ShortDescription_should_be_Other.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_DisabilityDesignation_Section_504
            : When_querying_the_DemographicDim_view
        {

            private const string _caseIdentifier = "DisabilityDesignation_Section_504";
            public Given_DisabilityDesignation_Section_504(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [SetUp]
            public void SetUp()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore($"The DemographicDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<DemographicDim>($"{TestCasesFolder}.{_caseIdentifier}_DemographicKey_should_be_unique.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicParentKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicParentKey_should_be_DisabilityDesignation.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicLabel()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicLabel_should_be_Section_504.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_a_set_of_DisabilityDesignations
            : When_querying_the_DemographicDim_view
        {

            private const string _caseIdentifier = "DisabilityDesignations";
            public Given_a_set_of_DisabilityDesignations(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [SetUp]
            public void SetUp()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore($"The DemographicDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_all_rows()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<DemographicDim>($"{TestCasesFolder}.{_caseIdentifier}_returns_all_rows.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_Language_English
            : When_querying_the_DemographicDim_view
        {

            private const string _caseIdentifier = "Language_English";
            public Given_Language_English(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<DemographicDim>($"{TestCasesFolder}.{_caseIdentifier}_DemographicKey_should_be_unique.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicParentKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicParentKey_should_be_Language.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicLabel()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicLabel_should_be_English.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_ShortDescription_should_be_English()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_ShortDescription_should_be_English.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_Language_Persian
            : When_querying_the_DemographicDim_view
        {

            private const string _caseIdentifier = "Language_Persian";
            public Given_Language_Persian(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<DemographicDim>($"{TestCasesFolder}.{_caseIdentifier}_DemographicKey_should_be_unique.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicParentKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicParentKey_should_be_Language.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicLabel()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicLabel_should_be_Persian.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_a_set_of_Languages
            : When_querying_the_DemographicDim_view
        {

            private const string _caseIdentifier = "Languages";
            public Given_a_set_of_Languages(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_return_all_rows()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<DemographicDim>($"{TestCasesFolder}.{_caseIdentifier}_returns_all_rows.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_LanguageUse_Correspondence_language
            : When_querying_the_DemographicDim_view
        {

            private const string _caseIdentifier = "LanguageUse_Correspondence_language";
            public Given_LanguageUse_Correspondence_language(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<DemographicDim>($"{TestCasesFolder}.{_caseIdentifier}_DemographicKey_should_be_unique.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicParentKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicParentKey_should_be_LanguageUse.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicLabel()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicLabel_should_be_Correspondence_language.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_LanguageUse_Dominant_language
            : When_querying_the_DemographicDim_view
        {

            private const string _caseIdentifier = "LanguageUse_Dominant_language";
            public Given_LanguageUse_Dominant_language(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<DemographicDim>($"{TestCasesFolder}.{_caseIdentifier}_DemographicKey_should_be_unique.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicParentKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicParentKey_should_be_LanguageUse.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicLabel()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicLabel_should_be_Dominant_language.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_ShortDescription_should_be_Dominant_language()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_ShortDescription_should_be_Dominant_language.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_a_set_of_LanguagesUse
            : When_querying_the_DemographicDim_view
        {

            private const string _caseIdentifier = "LanguageUses";
            public Given_a_set_of_LanguagesUse(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_return_all_rows()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<DemographicDim>($"{TestCasesFolder}.{_caseIdentifier}_returns_all_rows.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_Race_Asian
            : When_querying_the_DemographicDim_view
        {

            private const string _caseIdentifier = "Race_Asian";
            public Given_Race_Asian(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<DemographicDim>($"{TestCasesFolder}.{_caseIdentifier}_DemographicKey_should_be_unique.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicParentKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicParentKey_should_be_Race.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicLabel()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicLabel_should_be_Asian.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_Race_Asian_ShortDescription_should_be_Asian()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_ShortDescription_should_be_Asian.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_Race_White
            : When_querying_the_DemographicDim_view
        {

            private const string _caseIdentifier = "Race_White";
            public Given_Race_White(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<DemographicDim>($"{TestCasesFolder}.{_caseIdentifier}_DemographicKey_should_be_unique.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicParentKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicParentKey_should_be_Race.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicLabel()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicLabel_should_be_White.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_a_set_of_Races
            : When_querying_the_DemographicDim_view
        {

            private const string _caseIdentifier = "Races";
            public Given_a_set_of_Races(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_return_all_rows()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<DemographicDim>($"{TestCasesFolder}.{_caseIdentifier}_returns_all_rows.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_TribalAffiliation_Afognak
            : When_querying_the_DemographicDim_view
        {

            private const string _caseIdentifier = "TribalAffiliation_Afognak";
            public Given_TribalAffiliation_Afognak(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [SetUp]
            public void SetUp()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore($"The DemographicDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<DemographicDim>($"{TestCasesFolder}.{_caseIdentifier}_DemographicKey_should_be_unique.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicParentKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicParentKey_should_be_TribalAffiliation.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicLabel()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicLabel_should_be_Afognak.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_ShortDescription_should_be_Afognak()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_ShortDescription_should_be_Afognak.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_TribalAffiliation_Agdaagux
            : When_querying_the_DemographicDim_view
        {

            private const string _caseIdentifier = "TribalAffiliation_Agdaagux";
            public Given_TribalAffiliation_Agdaagux(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [SetUp]
            public void SetUp()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore($"The DemographicDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<DemographicDim>($"{TestCasesFolder}.{_caseIdentifier}_DemographicKey_should_be_unique.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicParentKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicParentKey_should_be_TribalAffiliation.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicLabel()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicLabel_should_be_Agdaagux.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_a_set_of_TribalAffiliations
            : When_querying_the_DemographicDim_view
        {

            private const string _caseIdentifier = "TribalAffiliations";
            public Given_a_set_of_TribalAffiliations(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [SetUp]
            public void SetUp()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    Assert.Ignore($"The DemographicDim view does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [Test]
            public void Then_should_return_all_rows()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<DemographicDim>($"{TestCasesFolder}.{_caseIdentifier}_returns_all_rows.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_StudentCharacteristic_Migrant
            : When_querying_the_DemographicDim_view
        {

            private const string _caseIdentifier = "StudentCharacteristic_Migrant";
            public Given_StudentCharacteristic_Migrant(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<DemographicDim>($"{TestCasesFolder}.{_caseIdentifier}_DemographicKey_should_be_unique.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicParentKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicParentKey_should_be_StudentCharacteristic.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicLabel()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicLabel_should_be_Migrant.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_ShortDescription_should_be_Migrant()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_ShortDescription_should_be_Migrant.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_StudentCharacteristic_Asylee
            : When_querying_the_DemographicDim_view
        {

            private const string _caseIdentifier = "StudentCharacteristic_Asylee";
            public Given_StudentCharacteristic_Asylee(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<DemographicDim>($"{TestCasesFolder}.{_caseIdentifier}_DemographicKey_should_be_unique.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicParentKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicParentKey_should_be_StudentCharacteristic.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicLabel()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicLabel_should_be_Asylee.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_StudentCharacteristic_EconomicDisadvantaged
            : When_querying_the_DemographicDim_view
        {

            private const string _caseIdentifier = "StudentCharacteristic_EconomicDisadvantaged";
            public Given_StudentCharacteristic_EconomicDisadvantaged(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<DemographicDim>($"{TestCasesFolder}.{_caseIdentifier}_DemographicKey_should_be_unique.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicParentKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicParentKey_should_be_StudentCharacteristic.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicLabel()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicLabel_should_be_EconomicDisadvantaged.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_a_set_of_StudentCharacteristics
            : When_querying_the_DemographicDim_view
        {

            private const string _caseIdentifier = "StudentCharacteristics";
            public Given_a_set_of_StudentCharacteristics(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_return_all_rows()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<DemographicDim>($"{TestCasesFolder}.{_caseIdentifier}_returns_all_rows.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_Disability_Medical_condition
            : When_querying_the_DemographicDim_view
        {

            private const string _caseIdentifier = "Disability_Medical_condition";
            public Given_Disability_Medical_condition(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<DemographicDim>($"{TestCasesFolder}.{_caseIdentifier}_DemographicKey_should_be_unique.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicParentKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicParentKey_should_be_Disability.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicLabel()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicLabel_should_be_Medical_condition.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_ShortDescription_should_be_Medical_condition()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_ShortDescription_should_be_Medical_condition.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_Disability_Physical_Disability
            : When_querying_the_DemographicDim_view
        {

            private const string _caseIdentifier = "Disability_Physical_disability";
            public Given_Disability_Physical_Disability(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<DemographicDim>($"{TestCasesFolder}.{_caseIdentifier}_DemographicKey_should_be_unique.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicParentKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicParentKey_should_be_Disability.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_DemographicLabel()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<DemographicDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_DemographicLabel_should_be_Physical_disability.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_a_set_of_Disabilities
            : When_querying_the_DemographicDim_view
        {

            private const string _caseIdentifier = "Disability";
            public Given_a_set_of_Disabilities(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_return_all_rows()
            {
                (bool success, string errorMessage) testResult = DataStandard.RunTestCase<DemographicDim>($"{TestCasesFolder}.{_caseIdentifier}_returns_all_rows.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
