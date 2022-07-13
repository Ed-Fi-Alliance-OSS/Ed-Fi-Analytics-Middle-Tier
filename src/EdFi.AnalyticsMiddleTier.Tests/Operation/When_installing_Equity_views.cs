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
    public class When_installing_Equity_views : When_installing_a_Collection
    {
        public When_installing_Equity_views(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

        [SetUp]
        public void Act()
        {
            if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
            {
                Assert.Ignore($"The collection Equity does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
            }
            else
            {
                Result = DataStandard.Install(10, Component.Equity);
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

        [TestCase]
        public void Then_should_create_analytics_view_equity_FeederSchoolDim() => DataStandard.ViewExists("equity_feederschooldim").ShouldBe(true);

        [TestCase("fn_GetStudentEnrollmentHistory")]
        [TestCase("fn_GetStudentGradesSummary")]
        public void Then_should_create_analytics_functions(string scalarFunctionName)
        {
            if (DataStandard.DataStandardEngine.Equals(Engine.MSSQL))
            {
                DataStandard.ScalarFunctionExists(scalarFunctionName).ShouldBe(true);
            }
            else
            {
                Assert.Ignore($"The function {scalarFunctionName} is only for MSSQL databases.");
            }
        }


        [TestCase]
        public void Then_should_create_analytics_view_equity_StudentDisciplineActionDim() => DataStandard.ViewExists("equity_studentdisciplineactiondim").ShouldBe(true);

        [TestCase]
        public void Then_should_create_analytics_view_equity_StudentHistoryDim() => DataStandard.ViewExists("equity_studenthistorydim").ShouldBe(true);

        [TestCase]
        public void Then_should_create_analytics_view_equity_StudentSchoolFoodServiceProgramDim() => DataStandard.ViewExists("equity_studentschoolfoodserviceprogramdim").ShouldBe(true);

        [TestCase]
        public void Then_should_create_analytics_view_equity_StudentProgramCohortDim() => DataStandard.ViewExists("equity_studentprogramcohortdim").ShouldBe(true);

    }
}
