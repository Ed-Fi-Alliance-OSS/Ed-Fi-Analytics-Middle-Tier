// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using EdFi.AnalyticsMiddleTier.Tests.Dimensions;
using Shouldly;

namespace EdFi.AnalyticsMiddleTier.Tests.Operation.BaseViews
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [Parallelizable(ParallelScope.Children)]
    public abstract class When_installing_base_views : When_querying_a_view
    {
        [SetUp]
        public void Act()
        {
            DataStandard.PrepareDatabase();
            Result = DataStandard.Install();
        }

        [Test]
        public void Then_result_success_should_be_true() => Result.success.ShouldBe(true);

        [Test]
        public void Then_error_message_should_be_null_or_empty() => Result.errorMessage.ShouldBeNullOrEmpty();

        [TestCase("analytics")]
        [TestCase("analytics_config")]
        public void Then_create_schema(string schema) =>
            DataStandard
                .ExecuteScalarQuery<int>($"select 1 from sys.schemas where [name] = '{schema}'")
                .ShouldBe(1);

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
        public void Then_should_create_analytics_view(string viewName) =>
            DataStandard.ViewExists(viewName).ShouldBe(true);

        [Test]
        public void Then_should_create_analytics_middle_tier_role()
        {
            const string sql = "SELECT 1 FROM sys.database_principals WHERE [type] = 'R' AND [name] = 'analytics_middle_tier'";
            DataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(1);
        }

        [TestCase("IX_AMT_Grade_SectionKey")]
        [TestCase("IX_AMT_AcademicSubjectType_CodeValue")]
        [TestCase("IX_AMT_StudentSectionAssociation_StudentSectionDim")]
        public void Then_should_not_install_indexes(string indexName)
        {
            var sql = $"select 1 from sys.indexes where [name] = '{indexName}'";
            DataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(0);
        }
       
        public class Given_a_data_standard : When_installing_base_views
        {
            public Given_a_data_standard(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);
        }
      
        public class Given_an_expected_table_column_is_missing : When_querying_a_view
        {
            public Given_an_expected_table_column_is_missing(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [OneTimeSetUp]
            public void PrepareDatabase()
            {
                DataStandard.PrepareDatabase();
                DataStandard.ExecuteQuery("ALTER TABLE [edfi].[GradingPeriod] DROP COLUMN [TotalInstructionalDays]");
            }

            [SetUp]
            public void Act()
            {
                Result = DataStandard.Install();
            }

            [Test]
            public void Then_should_not_be_successful() => Result.success.ShouldBe(false);

            [Test]
            public void Then_error_message_should_be_set() => Result.errorMessage.ShouldNotBeNullOrEmpty();

            [Test]
            public void Then_should_not_install_any_views()
            {
                const string sql = "SELECT count(1) FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA = 'analytics'";
                DataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(0);
            }

            [Test]
            public void Then_should_not_install_any_indexes()
            {
                var sql = "select count(1) from sys.indexes where [name] LIKE 'IX_AMT_%'";
                DataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(0);
            }

            [Test]
            public void Then_should_not_install_any_tables()
            {
                var sql = "SELECT count(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'analytics_config'";
                DataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(0);
            }

            [Test]
            public void Then_should_not_install_any_procedures()
            {
                var sql = "select count(1) from information_schema.routines where routine_schema = 'analytics_config'";
                DataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(0);
            }
        }
    }
}
