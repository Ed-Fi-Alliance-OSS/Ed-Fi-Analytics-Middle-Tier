// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Common;
using NUnit.Framework;
using Shouldly;

namespace EdFi.AnalyticsMiddleTier.Tests.Operation.CollectionViews
{
    /// <summary>
    /// The tests test are very basic, only insuring that:
    /// 
    /// (a) Data Standard 2.x is not supported, and
    /// (b) The install completes successfully for Data Standard 3.x
    /// 
    /// Detailed testing of the "Engage" views is handled in the LMS-Toolkit repository.
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [Parallelizable(ParallelScope.Children)]
    public abstract class When_installing_Engage_option
    {
        protected const string QUERY =
            "SELECT COUNT(1) FROM AnalyticsMiddleTierSchemaVersion WHERE ScriptName LIKE '%.Engage.%'";

        protected abstract TestHarnessSQLServer DataStandard { get; }

        protected (bool success, string errorMessage) Result;

        [SetUp]
        public void Act()
        {
            Result = DataStandard.Install(10, Component.Engage);
        }

        [OneTimeTearDown]
        public void Uninstall()
        {
            Result = DataStandard.Uninstall();
        }

        protected int GetEngageRecordCount()
        {
            return DataStandard.Orm.ExecuteScalar<int>(QUERY);
        }

        [TestFixture]
        public class Given_data_standard_two : When_installing_Engage_option
        {
            protected override TestHarnessSQLServer DataStandard => TestHarnessSQLServer.DataStandard2;

            [TestCase()]
            public void Then_result_success_should_be_true() => Result.success.ShouldBe(true);

            [TestCase()]
            public void Then_error_message_should_be_null_or_empty() => Result.errorMessage.ShouldBeNullOrEmpty();

            [Test]
            public void Then_should_not_be_installed()
            {
                GetEngageRecordCount().ShouldBe(0);
            }
        }

        [TestFixture]
        public class Given_data_standard_three_one : When_installing_Engage_option
        {
            protected override TestHarnessSQLServer DataStandard => TestHarnessSQLServer.DataStandard31;

            [TestCase()]
            public void Then_result_success_should_be_true() => Result.success.ShouldBe(true);

            [TestCase()]
            public void Then_error_message_should_be_null_or_empty() => Result.errorMessage.ShouldBeNullOrEmpty();

            [Test]
            public void Then_should_not_be_installed()
            {
                GetEngageRecordCount().ShouldBe(0);
            }
        }

        [TestFixture]
        public class Given_data_standard_three_two : When_installing_Engage_option
        {
            protected override TestHarnessSQLServer DataStandard => TestHarnessSQLServer.DataStandard32;

            // The baseline DS32 database does not have the extension tables
            // that are required to install the "Engage" collection. Thus 
            // this install will fail. For the purpose of this test, that
            // is a *GOOD* thing, as it proves that the AMT _tried_ to install
            // the collection. Detailed testing of the collection, as noted
            // above, is in the LMS-Toolkit repository.

            [TestCase()]
            public void Then_result_success_should_be_false() => Result.success.ShouldBe(false);

            [TestCase()]
            public void Then_there_should_be_an_error_message() => Result.errorMessage.ShouldNotBeNullOrEmpty();
        }
    }
}