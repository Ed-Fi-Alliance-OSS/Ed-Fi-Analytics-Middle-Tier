// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using Shouldly;

namespace EdFi.AnalyticsMiddleTier.Tests.Operation
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [TestFixtureSource(nameof(FixtureDataProvider))]
    public class When_uninstalling_the_views
    {
        protected static TestHarnessSQLServer[] FixtureDataProvider() => (new[] { TestHarnessSQLServer.DataStandard2, TestHarnessSQLServer.DataStandard31, TestHarnessSQLServer.DataStandard32 });
        // There is only one uninstall procedure, so it is not necessary to run it for every data standard

        protected TestHarnessSQLServer _dataStandard;
        public When_uninstalling_the_views(TestHarnessSQLServer dataStandard)
        {
            _dataStandard = dataStandard;
        }
       

        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            _dataStandard.PrepareDatabase();
            Result = _dataStandard.Install();
        }

        [SetUp]
        public void Act()
        {
            Result = _dataStandard.Uninstall();
        }

        [Test]
        public void Then_result_success_should_be_true() => Result.success.ShouldBe(true);

        [Test]
        public void Then_error_message_should_be_null_or_empty() => Result.errorMessage.ShouldBeNullOrEmpty();

        [Test]
        public void Then_should_uninstall_all_analytics_views()
        {
            const string sql = "SELECT COUNT(1) FROM INFORMATION_SCHEMA.views WHERE TABLE_SCHEMA = 'analytics'";
            _dataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(0);
        }

        [Test]
        public void Then_should_uninstall_all_analytics_config_views()
        {
            const string sql = "SELECT COUNT(1) FROM INFORMATION_SCHEMA.views WHERE TABLE_SCHEMA = 'analytics_config'";
            _dataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(0);
        }

        [TestCase("IX_AMT_Grade_SectionKey")]
        [TestCase("IX_AMT_AcademicSubjectType_CodeValue")]
        [TestCase("IX_AMT_StudentSectionAssociation_StudentSectionDim")]
        public void Then_should_remove_index(string indexName)
        {
            var sql = $"select 1 from sys.indexes where [name] = '{indexName}'";
            _dataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(0);
        }

        [Test]
        public void Then_should_remove_index_journal()
        {
            _dataStandard.TableExists("IndexJournal").ShouldBe(false);
        }

        [Test]
        public void Then_should_remove_the_analytics_middle_tier_schema_version_table()
        {
            _dataStandard.TableExists("dbo", "AnalyticsMiddleTierSchemaVersion").ShouldBe(false);
        }

        [Test]
        public void Then_should_remove_the_stored_procedures()
        {
            const string sql = "select count(1) from INFORMATION_SCHEMA.ROUTINES where specific_schema = 'analytics_config'";
            _dataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(0);
        }
    }
}
