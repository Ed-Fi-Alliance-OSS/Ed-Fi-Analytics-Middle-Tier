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
    public class When_uninstalling_the_views : TestCaseBase
    {
        public When_uninstalling_the_views(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

        [OneTimeSetUp]
        public void Act()
        {
            DataStandard.Install(10, Component.Indexes);
            Result = DataStandard.Uninstall();
        }

        [Test]
        public void Then_result_success_should_be_true() => Result.success.ShouldBe(true);

        [Test]
        public void Then_error_message_should_be_null_or_empty() => Result.errorMessage.ShouldBeNullOrEmpty();

        [Test]
        public void Then_should_uninstall_all_analytics_views()
        {
            const string sql = "SELECT COUNT(1) FROM INFORMATION_SCHEMA.views WHERE TABLE_SCHEMA = 'analytics'";
            DataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(0);
        }

        [Test]
        public void Then_should_uninstall_all_analytics_config_views()
        {
            const string sql = "SELECT COUNT(1) FROM INFORMATION_SCHEMA.views WHERE TABLE_SCHEMA = 'analytics_config'";
            DataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(0);
        }

        [TestCase("IX_AMT_Grade_SectionKey")]
        [TestCase("IX_AMT_AcademicSubjectType_CodeValue")]
        [TestCase("IX_AMT_StudentSectionAssociation_StudentSectionDim")]
        public void Then_should_remove_index(string indexName)
        {
            var sql = $"select 1 from sys.indexes where [name] = '{indexName}'";
            DataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(0);
        }

        [Test]
        public void Then_should_remove_index_journal()
        {
            DataStandard.TableExists("IndexJournal").ShouldBe(false);
        }

        [Test]
        public void Then_should_remove_the_analytics_middle_tier_schema_version_table()
        {
            DataStandard.TableExists("dbo", "AnalyticsMiddleTierSchemaVersion").ShouldBe(false);
        }

        [Test]
        public void Then_should_remove_the_stored_procedures()
        {
            const string sql = "select count(1) from INFORMATION_SCHEMA.ROUTINES where specific_schema = 'analytics_config'";
            DataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(0);
        }
    }
}
