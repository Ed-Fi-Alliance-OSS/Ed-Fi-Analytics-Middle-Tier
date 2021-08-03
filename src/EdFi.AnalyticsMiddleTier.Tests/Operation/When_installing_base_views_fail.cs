// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace EdFi.AnalyticsMiddleTier.Tests.Operation.BaseViews
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_installing_base_views_fail : TestCaseBase
    {
        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            DataStandard.PrepareDatabase();
            DataStandard.ExecuteQuery("ALTER TABLE [edfi].[GradingPeriod] DROP COLUMN [TotalInstructionalDays]");
        }

        public class Given_an_expected_table_column_is_missing : When_installing_base_views_fail
        {
            public Given_an_expected_table_column_is_missing(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

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
