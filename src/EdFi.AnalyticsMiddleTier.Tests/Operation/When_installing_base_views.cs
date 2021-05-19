// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using Shouldly;

namespace EdFi.AnalyticsMiddleTier.Tests.Operation
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_installing_base_views
    {
        protected abstract TestHarness _dataStandard { get; }

        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            _dataStandard.PrepareDatabase();
        }

        [SetUp]
        public void Act()
        {
            Result = _dataStandard.Install();
        }

        [Test]
        public void Then_result_success_should_be_true() => Result.success.ShouldBe(true);

        [Test]
        public void Then_error_message_should_be_null_or_empty() => Result.errorMessage.ShouldBeNullOrEmpty();

        [TestCase("analytics")]
        [TestCase("analytics_config")]
        public void Then_create_schema(string schema) =>
            _dataStandard
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
        public void Then_should_create_analytics_view(string viewName) =>
            _dataStandard.ViewExists(viewName).ShouldBe(true);

        [Test]
        public void Then_should_create_analytics_middle_tier_role()
        {
            const string sql = "SELECT 1 FROM sys.database_principals WHERE [type] = 'R' AND [name] = 'analytics_middle_tier'";
            _dataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(1);
        }

        [TestCase("IX_AMT_Grade_SectionKey")]
        [TestCase("IX_AMT_AcademicSubjectType_CodeValue")]
        [TestCase("IX_AMT_StudentSectionAssociation_StudentSectionDim")]
        public void Then_should_not_install_indexes(string indexName)
        {
            var sql = $"select 1 from sys.indexes where [name] = '{indexName}'";
            _dataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(0);
        }

        [TestFixture]
        public class Given_data_standard_two : When_installing_base_views
        {
            protected override TestHarness _dataStandard => TestHarness.DataStandard2;
        }

        [TestFixture]
        public class Given_data_standard_three_one : When_installing_base_views
        {
            protected override TestHarness _dataStandard => TestHarness.DataStandard31;
        }
        [TestFixture]
        public class Given_data_standard_three_two : When_installing_base_views
        {
            protected override TestHarness _dataStandard => TestHarness.DataStandard32;
        }

        [TestFixture]
        public class And_data_standard_2 : Given_an_expected_table_column_is_missing
        {
            protected override TestHarness _dataStandard => TestHarness.DataStandard2;
        }

        [TestFixture]
        public class And_data_standard_three_one : Given_an_expected_table_column_is_missing
        {
            protected override TestHarness _dataStandard => TestHarness.DataStandard31;
        }
        [TestFixture]
        public class And_data_standard_three_two : Given_an_expected_table_column_is_missing
        {
            protected override TestHarness _dataStandard => TestHarness.DataStandard32;
        }

        public abstract class Given_an_expected_table_column_is_missing
        {
            protected abstract TestHarness _dataStandard { get; }

            protected (bool success, string errorMessage) Result;

            [OneTimeSetUp]
            public void PrepareDatabase()
            {
                _dataStandard.PrepareDatabase();
                _dataStandard.ExecuteQuery("ALTER TABLE [edfi].[GradingPeriod] DROP COLUMN [TotalInstructionalDays]");
            }

            [SetUp]
            public void Act()
            {
                Result = _dataStandard.Install();
            }

            [Test]
            public void Then_should_not_be_successful() => Result.success.ShouldBe(false);

            [Test]
            public void Then_error_message_should_be_set() => Result.errorMessage.ShouldNotBeNullOrEmpty();

            [Test]
            public void Then_should_not_install_any_views()
            {
                const string sql = "SELECT count(1) FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA = 'analytics'";
                _dataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(0);
            }

            [Test]
            public void Then_should_not_install_any_indexes()
            {
                var sql = "select count(1) from sys.indexes where [name] LIKE 'IX_AMT_%'";
                _dataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(0);
            }

            [Test]
            public void Then_should_not_install_any_tables()
            {
                var sql = "SELECT count(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'analytics_config'";
                _dataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(0);
            }

            [Test]
            public void Then_should_not_install_any_procedures()
            {
                var sql = "select count(1) from information_schema.routines where routine_schema = 'analytics_config'";
                _dataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(0);
            }
        }
    }
}
