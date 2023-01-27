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
    public class When_installing_EWS_views : When_installing_a_Collection
    {
        public When_installing_EWS_views(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

        [SetUp]
        public void Act()
        {
            Result = DataStandard.Install(10, Component.Ews);
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

        [Test]
        public void Then_should_create_analytics_config_table() => DataStandard.TableExists("ews_lettergradetranslation").ShouldBe(true);

        [Test]
        public void Then_should_create_analytics_view_ews_StudentSectionGradeFact() => DataStandard.ViewExists("ews_studentsectiongradefact").ShouldBe(true);

        [Test]
        public void Then_should_create_analytics_view_ews_StudentEarlyWarningFact() => DataStandard.ViewExists("ews_studentearlywarningfact").ShouldBe(true);

        [Test]
        public void Then_should_create_ews_LetterGradeTranslation() => DataStandard.TableExists("ews_lettergradetranslation").ShouldBe(true);

    }
}
