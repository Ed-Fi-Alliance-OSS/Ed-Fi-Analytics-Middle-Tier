// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EdFi.AnalyticsMiddleTier.Common;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.AnalyticsMiddleTier.Tests.Common
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [Category("UnitTest")]
    public abstract class When_uninstalling_postgresql
    {
        protected IOrm Orm { get; set; }
        protected IReadOnlyCollection<string> ViewsList { get; set; }
        protected IReadOnlyCollection<string> IndexesList { get; set; }
        protected IReadOnlyCollection<string> StoredProcedureList { get; set; }
        protected string ConnectionString { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            ConnectionString = "Some connection String";
            Orm = A.Fake<IOrm>();
            PostgresUninstallStrategy postgresUninstallStrategy = new PostgresUninstallStrategy(Orm);
            this.ViewsList = SeedData.GetViews();
            this.IndexesList = SeedData.GetIndexes();
            this.StoredProcedureList = SeedData.GetStoredProcedures();
            A.CallTo(() => Orm.Query<String>(postgresUninstallStrategy.GetQueryViewsTemplate("analytics"))).Returns(ViewsList);
            A.CallTo(() => Orm.Query<String>(postgresUninstallStrategy.GetQueryIndexesTemplate("analytics"))).Returns(IndexesList);
            A.CallTo(() => Orm.Query<String>(postgresUninstallStrategy.GetQueryStoredProceduresTemplate("analytics"))).Returns(StoredProcedureList);
            A.CallTo(() => Orm.Execute(postgresUninstallStrategy.GetDropTableTemplate("analytics", "Table"))).Returns(1);
            A.CallTo(() => Orm.Execute(postgresUninstallStrategy.GetDropIndexTemplate("Index1"))).Returns(1);
            A.CallTo(() => Orm.Execute(postgresUninstallStrategy.GetDropStoredProceduresTemplate("analytics", "Procedure"))).Returns(1);
            A.CallTo(() => Orm.Execute(String.Join(String.Empty, ViewsList.Select(i => (postgresUninstallStrategy.GetDropViewsTemplate("analytics", i)))))).Returns(ViewsList.Count);
            A.CallTo(() => Orm.Execute(String.Join(String.Empty, StoredProcedureList.Select(i => (postgresUninstallStrategy.GetDropStoredProceduresTemplate("analytics", i)))))).Returns(StoredProcedureList.Count);
            A.CallTo(() => Orm.Execute(String.Join(String.Empty, IndexesList.Select(i => (postgresUninstallStrategy.GetDropIndexTemplate("analytics")))))).Returns(IndexesList.Count);
        }

        [Test]
        public void strategy_should_have_orm()
        {
            Should.NotThrow(() => new SqlServerUninstallStrategy(Orm));
        }

        [Test]
        public void strategy_should_not_have_orm_null()
        {
            Should.Throw<ArgumentException>(() => new SqlServerUninstallStrategy(null));
        }
    }
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [TestFixture]
    public class Given_uninstalling_drop_table_by_schema_analytics : When_uninstalling_postgresql
    {
        private int _result;
        [SetUp]
        public void Act()
        {
            var uninstallStrategy = new PostgresUninstallStrategy(Orm);
            _result = uninstallStrategy.DropTable("analytics", "Table");
        }
        [Test]
        public void Drop_table_should_drop_a_table()
        {
            _result.ShouldBe(1);
        }
        [Test]
        public void Drop_table_should_invoke_execute()
        {
            A.CallTo(() => Orm.Execute(A<string>._)).MustHaveHappened();
        }
    }
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [TestFixture]
    public class Given_uninstalling_drop_table__without_schema : When_uninstalling_postgresql
    {
        private int _result;

        [SetUp]
        public void Act()
        {
            var uninstallStrategy = new PostgresUninstallStrategy(Orm);
            _result = uninstallStrategy.DropTable("analytics", "");
        }
        [Test]
        public void Drop_table_should_not_drop_anything()
        {
            _result.ShouldBe(0);
        }

        [Test]
        public void Drop_table_should_invoke_execute()
        {
            A.CallTo(() => Orm.Execute(A<string>._)).MustHaveHappened();
        }
    }
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [TestFixture]
    public class Given_uninstalling_views_by_schema_analytics : When_uninstalling_postgresql
    {
        private int _result;
        [SetUp]
        public void Act()
        {
            var uninstallStrategy = new PostgresUninstallStrategy(Orm);
            _result = uninstallStrategy.RemoveAllViews("analytics");
        }
        [Test]
        public void Remove_Views_should_drop_a_list_views()
        {
            _result.ShouldBe(ViewsList.Count);
        }
        [Test]
        public void Remove_Views_should_select_a_list_views()
        {
            A.CallTo(() => Orm.Query<string>(A<string>._))
                .Returns(ViewsList);
        }
        [Test]
        public void Remove_Views_should_invoke_execute()
        {
            A.CallTo(() => Orm.Execute(A<string>._)).MustHaveHappened();
        }
    }
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [TestFixture]
    public class Given_uninstalling_views_without_schema : When_uninstalling_postgresql
    {
        private int _result;

        [SetUp]
        public void Act()
        {
            var uninstallStrategy = new PostgresUninstallStrategy(Orm);
            _result = uninstallStrategy.RemoveAllViews("");
        }
        [Test]
        public void Remove_Views_should_not_drop_anything()
        {
            _result.ShouldBe(0);
        }
        [Test]
        public void Remove_Views_should_select_a_empty_list_views()
        {
            A.CallTo(() => Orm.Query<string>(A<string>._))
                .Returns(new List<string>());
        }
        [Test]
        public void Remove_Views_should_not_invoke_execute()
        {
            A.CallTo(() => Orm.Execute(A<string>._)).MustNotHaveHappened();
        }
    }
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [TestFixture]
    public class Given_uninstalling_stored_procedures_by_schema_analytics : When_uninstalling_postgresql
    {
        private int _result;
        [SetUp]
        public void Act()
        {
            var uninstallStrategy = new PostgresUninstallStrategy(Orm);
            _result = uninstallStrategy.RemoveAllStoredProcedures("analytics");
        }
        [Test]
        public void Remove_StoredProcedures_should_drop_a_list_views()
        {
            _result.ShouldBe(StoredProcedureList.Count);
        }
        [Test]
        public void Remove_StoredProcedures_should_select_a_list_views()
        {
            A.CallTo(() => Orm.Query<string>(A<string>._))
                .Returns(ViewsList);
        }
        [Test]
        public void Remove_StoredProcedures_should_invoke_execute()
        {
            A.CallTo(() => Orm.Execute(A<string>._)).MustHaveHappened();
        }
    }
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [TestFixture]
    public class Given_uninstalling_stored_procedures_without_schema : When_uninstalling_postgresql
    {
        private int _result;

        [SetUp]
        public void Act()
        {
            var uninstallStrategy = new PostgresUninstallStrategy(Orm);
            _result = uninstallStrategy.RemoveAllStoredProcedures("");
        }
        [Test]
        public void Remove_StoredProcedures_should_not_drop_anything()
        {
            _result.ShouldBe(0);
        }
        [Test]
        public void Remove_StoredProcedures_should_select_a_empty_list_views()
        {
            A.CallTo(() => Orm.Query<string>(A<string>._))
                .Returns(new List<string>());
        }
        [Test]
        public void Remove_StoredProcedures_should_not_invoke_execute()
        {
            A.CallTo(() => Orm.Execute(A<string>._)).MustNotHaveHappened();
        }
    }
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [TestFixture]
    public class Given_uninstalling_indexes_by_schema_analytics : When_uninstalling_postgresql
    {
        private int _result;
        [SetUp]
        public void Act()
        {
            var uninstallStrategy = new PostgresUninstallStrategy(Orm);
            _result = uninstallStrategy.RemoveAllIndexes("analytics");
        }
        [Test]
        public void Remove_Indexes_should_drop_a_list_views()
        {
            _result.ShouldBe(IndexesList.Count);
        }
        [Test]
        public void Remove_Indexes_should_select_a_list_views()
        {
            A.CallTo(() => Orm.Query<string>(A<string>._))
                .Returns(ViewsList);
        }
        [Test]
        public void Remove_Indexes_should_invoke_execute()
        {
            A.CallTo(() => Orm.Execute(A<string>._)).MustHaveHappened();
        }
    }
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [TestFixture]
    public class Given_uninstalling_indexes_without_schema : When_uninstalling_postgresql
    {
        private int _result;

        [SetUp]
        public void Act()
        {
            var uninstallStrategy = new PostgresUninstallStrategy(Orm);
            _result = uninstallStrategy.RemoveAllIndexes("");
        }
        [Test]
        public void Remove_Indexes_should_not_drop_anything()
        {
            _result.ShouldBe(0);
        }
        [Test]
        public void Remove_Indexes_should_select_a_empty_list_views()
        {
            A.CallTo(() => Orm.Query<string>(A<string>._))
                .Returns(new List<string>());
        }
        [Test]
        public void Remove_Indexes_should_not_invoke_execute()
        {
            A.CallTo(() => Orm.Execute(A<string>._)).MustNotHaveHappened();
        }
    }
}
