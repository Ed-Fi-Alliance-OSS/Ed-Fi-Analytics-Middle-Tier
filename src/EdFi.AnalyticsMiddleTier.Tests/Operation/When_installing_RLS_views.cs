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
    public class When_installing_RLS_views : When_installing_a_Collection
    {
        public When_installing_RLS_views(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

        [SetUp]
        public void Act()
        {
            Result = DataStandard.Install(10, Component.RLS);
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
        public void Then_should_create_analytics_view_rls_StudentDataAuthorization() => DataStandard.ViewExists("rls_studentdataauthorization").ShouldBe(true);

        [TestCase]
        public void Then_should_create_analytics_view_rls_UserDim() => DataStandard.ViewExists("rls_userdim").ShouldBe(true);

        [TestCase]
        public void Then_should_create_analytics_view_rls_UserAuthorization() => DataStandard.ViewExists("rls_userauthorization").ShouldBe(true);

        [TestCase]
        public void Then_should_create_analytics_view_rls_UserStudentDataAuthorization() => DataStandard.ViewExists("rls_userstudentdataauthorization").ShouldBe(true);

        [TestCase]
        public void Then_should_create_analytics_config_view() =>
            DataStandard.ViewExists("rls_staffclassificationdescriptorscopelist", "analytics_config").ShouldBe(true);

        [TestCase]
        public void Then_should_create_stored_procedure_rls_InsertStaffClassificationDescriptorScope()
        {
            var sql = "SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_SCHEMA = 'analytics_config' AND ROUTINE_NAME = 'rls_insertstaffclassificationdescriptorscope'";
            DataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(1);
        }

        [TestCase]
        public void Then_should_create_stored_procedure_rls_RemoveStaffClassificationDescriptorScope()
        {
            var sql = "SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_SCHEMA = 'analytics_config' AND ROUTINE_NAME = 'rls_removestaffclassificationdescriptorscope'";
            DataStandard.ExecuteScalarQuery<int>(sql).ShouldBe(1);
        }
    }
}
