// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Common;
using NUnit.Framework;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace EdFi.AnalyticsMiddleTier.Tests.Operation
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_installing_base_views : When_installing_a_Collection
    {
        [OneTimeSetUp]
        public void Act()
        {
            Result = DataStandard.Install();
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

        [TestCase("analytics")]
        [TestCase("analytics_config")]
        public void Then_create_schema(string schema)
        {
            if (DataStandard.DataStandardEngine.Equals(Engine.MSSQL))
            {
                DataStandard
                .ExecuteScalarQuery<int>($"select 1 from sys.schemas where name = '{schema}'")
                .ShouldBe(1);
            }
            else
            {
                DataStandard
                    .ExecuteScalarQuery<int>($"select 1 from pg_catalog.pg_namespace where nspname = '{schema}'")
                    .ShouldBe(1);
            }
        }

        /*
         * TODO: removing the tests for columns. These will be tested in detail when we start doing unit testing with dapper.
         * Even that testing will replace the tests for view creation here. The following "view exists" assertions are just
         * a safety net until we can get the full unit testing in place. SF 2019-10-18
         */
        [TestCase("DateDim")]
        [TestCase("StudentSchoolDim")]
        [TestCase("SchoolDim")]
        [TestCase("ContactPersonDim")]
        [TestCase("LocalEducationAgencyDim")]
        [TestCase("GradingPeriodDim")]
        [TestCase("MostRecentGradingPeriod")]
        [TestCase("StudentSectionDim")]
        [TestCase("StudentSchoolDemographicsBridge")]
        [TestCase("StudentLocalEducationAgencyDim")]
        [TestCase("DemographicDim")]
        [TestCase("StudentLocalEducationAgencyDemographicsBridge")]
        [TestCase("StaffSectionDim")]
        [TestCase("SectionDim")]
        [TestCase("StudentProgramDim")]
        [TestCase("AllStudentSchoolDim")]
        public void Then_should_create_analytics_view(string viewName) =>
            DataStandard.ViewExists(viewName).ShouldBe(true);

        [Test]
        public void Then_should_create_analytics_middle_tier_role()
        {
            const string sql = "SELECT 1 FROM sys.database_principals WHERE [type] = 'R' AND [name] = 'analytics_middle_tier'";
            const string postgresql = "SELECT 1 FROM pg_roles WHERE rolname = 'analytics_middle_tier'";
            if (DataStandard.DataStandardEngine.Equals(Engine.MSSQL))
            {
                DataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(1);
            }
            else
            {
                DataStandard.ExecuteScalarQuery<int>(postgresql).ShouldBe(1);
            }
        }

        [TestCase("IX_AMT_Grade_SectionKey")]
        [TestCase("IX_AMT_AcademicSubjectType_CodeValue")]
        [TestCase("IX_AMT_StudentSectionAssociation_StudentSectionDim")]
        public void Then_should_not_install_indexes(string indexName)
        {
            var sql = $"select 1 from sys.indexes where [name] = '{indexName}'";
            if (DataStandard.DataStandardEngine.Equals(Engine.MSSQL))
            {
                DataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(0);
            }
            else
            {
                Assert.Ignore("Indexes are not installed (PostgreSQL).");
            }
        }

        public class Given_a_data_standard : When_installing_base_views
        {
            public Given_a_data_standard(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
        }
    }
}
