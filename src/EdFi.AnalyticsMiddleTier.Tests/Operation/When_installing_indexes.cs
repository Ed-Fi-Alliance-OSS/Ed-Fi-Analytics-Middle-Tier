// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Common;
using NUnit.Framework;
using Shouldly;

namespace EdFi.AnalyticsMiddleTier.Tests.Operation
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_installing_indexes
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
            Result = _dataStandard.Install(10, Component.Indexes);
        }

        [Test]
        public void Then_result_success_should_be_true() => Result.success.ShouldBe(true);

        [Test]
        public void Then_error_message_should_be_null_or_empty() => Result.errorMessage.ShouldBeNullOrEmpty();

        protected void AssertIndexCreated(string index)
        {
            var sql = $"select 1 from sys.indexes where [name] = '{index}'";
            _dataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(1);
        }

        protected void AssertIndexJournalPopulated(string tableName, string index)
        {
            var sql = $"select 1 from analytics_config.indexjournal where FullyQualifiedIndexName = '[edfi].[{tableName}].[{index}]'";
            _dataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(1);
        }

        [Test]
        public void Then_should_create_index_journal() => _dataStandard.TableExists("IndexJournal").ShouldBe(true);

        [TestFixture]
        public class Given_data_standard_two : When_installing_indexes
        {
            protected override TestHarness _dataStandard => TestHarness.DataStandard2;

            [TestCase("IX_AMT_Grade_SectionKey")]
            [TestCase("IX_AMT_AcademicSubjectType_CodeValue")]
            [TestCase("IX_AMT_StudentSectionAssociation_StudentSectionDim")]
            public void Then_should_create_index(string indexName) => AssertIndexCreated(indexName);

            [TestCase("Grade", "IX_AMT_Grade_SectionKey")]
            [TestCase("AcademicSubjectType", "IX_AMT_AcademicSubjectType_CodeValue")]
            [TestCase("StudentSectionAssociation", "IX_AMT_StudentSectionAssociation_StudentSectionDim")]
            public void Then_should_record_index_in_journal(string tableName, string indexName) => AssertIndexJournalPopulated(tableName, indexName);
        }

        [TestFixture]
        public class Given_data_standard_three_one : When_installing_indexes
        {
            protected override TestHarness _dataStandard => TestHarness.DataStandard31;

            [TestCase("IX_AMT_Grade_SectionKey")]
            public void Then_should_create_index(string indexName) => AssertIndexCreated(indexName);

            [TestCase("Grade", "IX_AMT_Grade_SectionKey")]
            public void Then_should_record_index_in_journal(string tableName, string indexName) => AssertIndexJournalPopulated(tableName, indexName);
        }
        [TestFixture]
        public class Given_data_standard_three_two : When_installing_indexes
        {
            protected override TestHarness _dataStandard => TestHarness.DataStandard32;

            [TestCase("IX_AMT_Grade_SectionKey")]
            public void Then_should_create_index(string indexName) => AssertIndexCreated(indexName);

            [TestCase("Grade", "IX_AMT_Grade_SectionKey")]
            public void Then_should_record_index_in_journal(string tableName, string indexName) => AssertIndexJournalPopulated(tableName, indexName);
        }
    }
}
