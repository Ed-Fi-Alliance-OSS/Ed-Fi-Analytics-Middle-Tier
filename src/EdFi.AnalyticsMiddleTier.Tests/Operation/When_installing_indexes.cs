// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Common;
using CommonLib = EdFi.AnalyticsMiddleTier.Common;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace EdFi.AnalyticsMiddleTier.Tests.Operation
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_installing_indexes : When_installing_a_Collection
    {

        [SetUp]
        public void Act()
        {
            if (DataStandard.DataStandardEngine.Equals(Engine.MSSQL))
            {
                Result = DataStandard.Install(10, Component.Indexes);
            }
            else
            {
                Assert.Ignore("Indexes are not installed (PostgreSQL).");
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

        protected void AssertIndexCreated(string index)
        {
            var sql = $"select 1 from sys.indexes where [name] = '{index}'";
            DataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(1);
        }

        protected void AssertIndexJournalPopulated(string tableName, string index)
        {
            var sql = $"select 1 from analytics_config.indexjournal where FullyQualifiedIndexName = '[edfi].[{tableName}].[{index}]'";
            DataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(1);
        }

        [Test]
        public void Then_should_create_index_journal() => DataStandard.TableExists("IndexJournal").ShouldBe(true);

        public class Given_data_standard_indexes : When_installing_indexes
        {
            public Given_data_standard_indexes(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [TestCase("IX_AMT_AcademicSubjectType_CodeValue")]
            [TestCase("IX_AMT_StudentSectionAssociation_StudentSectionDim")]
            public void Then_should_create_index_ds2(string indexName)
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    AssertIndexCreated(indexName);
                }
                else
                {
                    Assert.Ignore($"The index {indexName} does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [TestCase("AcademicSubjectType", "IX_AMT_AcademicSubjectType_CodeValue")]
            [TestCase("StudentSectionAssociation", "IX_AMT_StudentSectionAssociation_StudentSectionDim")]
            public void Then_should_record_index_in_journal_ds2(string tableName, string indexName)
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds2))
                {
                    AssertIndexJournalPopulated(tableName, indexName);
                }
                else
                {
                    Assert.Ignore($"The index {indexName} does not exist in this version of the Data Standard. ({DataStandard.DataStandardVersion.ToString()})");
                }
            }

            [TestCase("IX_AMT_Grade_SectionKey")]
            public void Then_should_create_index(string indexName)
            {
                AssertIndexCreated(indexName);
            }

            [TestCase("Grade", "IX_AMT_Grade_SectionKey")]
            public void Then_should_record_index_in_journal(string tableName, string indexName)
            {
                AssertIndexJournalPopulated(tableName, indexName);
            }
        }
    }
}
