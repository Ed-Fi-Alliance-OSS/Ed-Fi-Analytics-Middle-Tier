// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Common;
using NUnit.Framework;
using Shouldly;
using CommonLib = EdFi.AnalyticsMiddleTier.Common;

// ReSharper disable once CheckNamespace
namespace EdFi.AnalyticsMiddleTier.Tests.Operation
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class When_installing_Epp_views : When_installing_a_Collection
    {
        public When_installing_Epp_views(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

        [OneTimeSetUp]
        public void Act()
        {
            if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2)
                || DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds31)
                || DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds32))
            {
                Assert.Ignore($"The collection Epp does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
            }
            else
            {
                Result = DataStandard.Install(10, Component.EPP);
            }
        }

        [OneTimeTearDown]
        public void Uninstall()
        {
            Result = DataStandard.Uninstall();
        }

        [Test]
        public void Then_result_success_should_be_true() => Result.success.ShouldBe(true);

        [Test]
        public void Then_error_message_should_be_null_or_empty() => Result.errorMessage.ShouldBeNullOrEmpty();

        [TestCase("EPP_CandidateDim")]
        [TestCase("epp_CandidateSurveyDim")]
        [TestCase("EPP_EvaluationElementRatingDim")]
        [TestCase("epp_TermDescriptorDim")]
        [TestCase("EPP_EppDim")]
        [TestCase("EPP_SexDescriptorDim")]
        [TestCase("EPP_FinancialAidFact")]
        [TestCase("epp_RaceDescriptorDim")]
        public void Then_should_create_analytics_epp_views(string viewName) =>
            DataStandard.ViewExists(viewName).ShouldBe(true);

    }
}
