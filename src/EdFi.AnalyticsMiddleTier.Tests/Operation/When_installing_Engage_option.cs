// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Common;
using NUnit.Framework;
using Shouldly;
using CommonLib = EdFi.AnalyticsMiddleTier.Common;

// ReSharper disable once CheckNamespace
namespace EdFi.AnalyticsMiddleTier.Tests.Operation
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
    [NonParallelizable]
    public abstract class When_installing_Engage_option : When_installing_a_Collection
    {
        protected const string QUERY =
            "SELECT COUNT(1) FROM AnalyticsMiddleTierSchemaVersion WHERE ScriptName LIKE '%.Engage.%'";

        [SetUp]
        public void Act()
        {
            if (DataStandard.DataStandardEngine.Equals(Engine.MSSQL))
            {
                Result = DataStandard.Install(10, Component.Engage);
            }
            else
            {
                Assert.Ignore("Collection Engage is not installed.");
            }
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

        public class Given_data_a_standard : When_installing_Engage_option
        {
            public Given_data_a_standard(TestHarnessBase dataStandard) => SetDataStandard(dataStandard);

            [TestCase()]
            public void Then_result_success_should_be_true()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds32) || DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds33))
                {
                    Assert.Ignore("The baseline DS32 database does not have the extension tables that are required to install the 'Engage' collection. This install will fail.");
                }
                else
                {
                    Result.success.ShouldBe(true);
                }
            }

            [TestCase()]
            public void Then_error_message_should_be_null_or_empty()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds32) || DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds33))
                {
                    Assert.Ignore("The baseline DS32 database does not have the extension tables that are required to install the 'Engage' collection. This install will fail.");
                }
                else
                {
                    Result.errorMessage.ShouldBeNullOrEmpty();
                }
            }

            [Test]
            public void Then_should_not_be_installed()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds32) || DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds33))
                {
                    Assert.Ignore("The baseline DS32 database does not have the extension tables that are required to install the 'Engage' collection. This install will fail.");
                }
                else
                {
                    GetEngageRecordCount().ShouldBe(0);
                }
            }
            // The baseline DS32 database does not have the extension tables
            // that are required to install the "Engage" collection. Thus 
            // this install will fail. For the purpose of this test, that
            // is a *GOOD* thing, as it proves that the AMT _tried_ to install
            // the collection. Detailed testing of the collection, as noted
            // above, is in the LMS-Toolkit repository.
            [TestCase()]
            public void Then_result_success_should_be_false()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds32) || DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds33))
                {
                    Result.success.ShouldBe(false);
                }
                else
                {
                    Assert.Ignore("The baseline DS32 database does not have the extension tables that are required to install the 'Engage' collection. This install will fail in DS 32.");
                }
            }

            [TestCase()]
            public void Then_there_should_be_an_error_message()
            {
                if (DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds32) || DataStandard.DataStandardVersion.Equals(CommonLib.DataStandard.Ds33))
                {
                    Result.errorMessage.ShouldNotBeNullOrEmpty();
                }
                else
                {
                    Assert.Ignore("The baseline DS32 database does not have the extension tables that are required to install the 'Engage' collection. This install will fail in DS 32.");
                }
            }

        }

    }
}
