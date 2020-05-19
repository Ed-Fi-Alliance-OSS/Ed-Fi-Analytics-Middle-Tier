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
    public abstract class When_installing_RLS_views
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
            Result = _dataStandard.Install(10, Component.RLS);
        }

        [Test]
        public void Then_result_success_should_be_true() => Result.success.ShouldBe(true);

        [Test]
        public void Then_error_message_should_be_null_or_empty() => Result.errorMessage.ShouldBeNullOrEmpty();

        [TestCase("rls_StudentDataAuthorization")]
        [TestCase("rls_UserDim")]
        [TestCase("rls_UserAuthorization")]
        [TestCase("rls_UserStudentDataAuthorization")]
        public void Then_should_create_analytics_view(string viewName) => _dataStandard.ViewExists(viewName).ShouldBe(true);

        [TestCase("rls_StaffClassificationDescriptorScopeList")]
        public void Then_should_create_analytics_config_view(string viewName) =>
            _dataStandard.ViewExists(viewName, "analytics_config").ShouldBe(true);

        [TestCase("rls_InsertStaffClassificationDescriptorScope")]
        [TestCase("rls_RemoveStaffClassificationDescriptorScope")]
        public void Then_should_create_stored_procedure(string procedureName)
        {
            var sql = $"SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_SCHEMA = 'analytics_config' AND ROUTINE_NAME = '{procedureName}'";
            _dataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(1);
        }
       // [Test]
       // public void Then_should_create_EWS_configuration_table() => _dataStandard.TableExists("EWS").ShouldBe(true);


        [TestFixture]
        public class Given_data_standard_two : When_installing_RLS_views
        {
            protected override TestHarness _dataStandard => TestHarness.DataStandard2;
        }

        [TestFixture]
        public class Given_data_standard_three_one : When_installing_RLS_views
        {
            protected override TestHarness _dataStandard => TestHarness.DataStandard31;
        }

        [TestFixture]
        public class Given_data_standard_three_two : When_installing_RLS_views
        {
            protected override TestHarness _dataStandard => TestHarness.DataStandard32;
        }
    }
}