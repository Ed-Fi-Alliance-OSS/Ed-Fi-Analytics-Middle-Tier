// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Common;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.AnalyticsMiddleTier.Tests.Common
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [Category("UnitTest")]
    public abstract class When_installing_datastandard_version
    {
        protected IOrm Orm { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            Orm = A.Fake<IOrm>();
        }

    }
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [TestFixture]
    [TestFixtureSource("FixtureArgs")]
    public class Given_SqlServer_database_with_a_valid_datastandard_version : When_installing_datastandard_version
    {
        protected SqlServerMigrationStrategy sqlServerMigrationStrategy { get; set; }

        private readonly DataStandard _dataStandard;
        private DataStandard _result;
        private static object[] FixtureArgs = {
        new object[] { DataStandard.Ds2 },
        new object[] { DataStandard.Ds31 },
        new object[] { DataStandard.Ds32 },
        new object[] { DataStandard.Ds33 }
        };
        public Given_SqlServer_database_with_a_valid_datastandard_version(DataStandard dataStandard)
        {
            _dataStandard = dataStandard;
        }

        [SetUp]
        public void Act()
        {
            sqlServerMigrationStrategy = new SqlServerMigrationStrategy(Orm);
            string statement = SqlServerMigrationStrategy.DataStandardVersionTemplate;
            A.CallTo(() => Orm.ExecuteScalar<string>(statement)).Returns(_dataStandard.ToString());
            _result = sqlServerMigrationStrategy.GetDataStandardVersion();
        }
        [Test]
        public void strategy_should_have_orm()
        {
            Should.NotThrow(() => new SqlServerMigrationStrategy(Orm));
        }

        [Test]
        public void strategy_should_not_have_orm_null()
        {
            Should.Throw<ArgumentException>(() => new SqlServerMigrationStrategy(null));
        }
        [Test]
        public void Get_datastandardversion_should_invoke_execute()
        {
            A.CallTo(() => Orm.ExecuteScalar<string>(A<string>._)).MustHaveHappened();
        }
        [Test]
        public void Get_datastandardversion_should_be_correct()
        {
            _result.ShouldBe(_dataStandard);
        }
    }
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [TestFixture]
    [TestFixtureSource("FixtureArgs")]
    public class Given_SqlServer_database_with_an_invalid_datastandard_version : When_installing_datastandard_version
    {
        protected SqlServerMigrationStrategy sqlServerMigrationStrategy { get; set; }

        private static object[] FixtureArgs = {
        new object[] { DataStandard.InvalidDs }
        };
        private readonly DataStandard _dataStandard;
        private DataStandard _result;
        public Given_SqlServer_database_with_an_invalid_datastandard_version(DataStandard dataStandard)
        {
            _dataStandard = dataStandard;
        }

        [SetUp]
        public void Act()
        {
            sqlServerMigrationStrategy = new SqlServerMigrationStrategy(Orm);
            string statement = SqlServerMigrationStrategy.DataStandardVersionTemplate;
            A.CallTo(() => Orm.ExecuteScalar<string>(statement)).Returns(_dataStandard.ToString());
            _result = sqlServerMigrationStrategy?.GetDataStandardVersion() ?? DataStandard.InvalidDs;
        }
        [Test]
        public void strategy_should_have_orm()
        {
            Should.NotThrow(() => new SqlServerMigrationStrategy(Orm));
        }

        [Test]
        public void strategy_should_not_have_orm_null()
        {
            Should.Throw<ArgumentException>(() => new SqlServerMigrationStrategy(null));
        }
        [Test]
        public void Get_datastandardversion_should_invoke_execute()
        {
            A.CallTo(() => Orm.ExecuteScalar<string>(A<string>._)).MustHaveHappened();
        }
        [Test]
        public void Get_datastandardversion_should_be_invalid()
        {
            _result.ShouldBe(_dataStandard);
        }
    }


    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [TestFixture]
    [TestFixtureSource("FixtureArgs")]
    public class Given_Postgresql_database_with_a_valid_datastandard_version : When_installing_datastandard_version
    {
        protected PostgresMigrationStrategy postgresqlServerMigrationStrategy { get; set; }

        private static object[] FixtureArgs = {
            new object[] { DataStandard.Ds32 },
            new object[] { DataStandard.Ds33 }
        };
        private readonly DataStandard _dataStandard;
        private DataStandard _result;
        public Given_Postgresql_database_with_a_valid_datastandard_version(DataStandard dataStandard)
        {
            _dataStandard = dataStandard;
        }

        [SetUp]
        public void Act()
        {
            postgresqlServerMigrationStrategy = new PostgresMigrationStrategy(Orm);
            //
            string statement = PostgresMigrationStrategy.DataStandardVersionTemplate;
            A.CallTo(() => Orm.ExecuteScalar<string>(statement)).Returns(_dataStandard.ToString());
            //
            _result = postgresqlServerMigrationStrategy.GetDataStandardVersion();
        }
        [Test]
        public void strategy_should_have_orm()
        {
            Should.NotThrow(() => new SqlServerMigrationStrategy(Orm));
        }

        [Test]
        public void strategy_should_not_have_orm_null()
        {
            Should.Throw<ArgumentException>(() => new SqlServerMigrationStrategy(null));
        }
        [Test]
        public void Get_datastandardversion_should_not_invoke_execute()
        {
            A.CallTo(() => Orm.ExecuteScalar<string>(A<string>._)).MustHaveHappened();
        }
        [Test]
        public void Get_datastandardversion_should_be_valid()
        {
            _result.ShouldBe(_dataStandard);
        }
    }
}
