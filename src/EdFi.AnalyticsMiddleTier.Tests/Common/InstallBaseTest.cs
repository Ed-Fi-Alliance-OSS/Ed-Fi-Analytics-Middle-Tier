// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using DbUp.Engine;
using EdFi.AnalyticsMiddleTier.Common;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace EdFi.AnalyticsMiddleTier.Tests.Common
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [Category("UnitTest")]
    internal abstract class When_running_installation
    {
        protected bool Successful;
        protected string Message;
        protected InstallBase Install;

        protected const string ValidConnectionString = "connection_string";
        protected const string InvalidConnectionString = "invalid_connection_string";
        protected const string DatabaseAccessErrorMessage = "Some database access error";
        protected const int ValidTimeout = 2;

        protected const string BaseDirectory = "Base";
        protected const string IndexesDirectory = "Indexes";
        protected const string QuickSightEWSDirectory = "Qews";

        protected IDatabaseMigrationStrategy MigrationStrategy { get; set; }
        protected DatabaseUpgradeResult migrationResult = new DatabaseUpgradeResult(new List<SqlScript>(), true, null);
        protected DatabaseUpgradeResult DatabaseAccessError = new DatabaseUpgradeResult(new List<SqlScript>(), false, new Exception(DatabaseAccessErrorMessage));

        [OneTimeSetUp]
        public void Setup()
        {
            MigrationStrategy = A.Fake<IDatabaseMigrationStrategy>();
            Install = new InstallBaseImplementation(MigrationStrategy);

            A.CallTo(() => MigrationStrategy.Migrate(A<Assembly>._, BaseDirectory, ValidConnectionString, ValidTimeout)).Returns(migrationResult);
            A.CallTo(() => MigrationStrategy.Migrate(A<Assembly>._, IndexesDirectory, ValidConnectionString, ValidTimeout)).Returns(migrationResult);
            A.CallTo(() => MigrationStrategy.Migrate(A<Assembly>._, QuickSightEWSDirectory, ValidConnectionString, ValidTimeout)).Returns(migrationResult);
        }

        [Test]
        public void InstallBase_implementation_should_have_migration_strategy()
        {
            Should.NotThrow(() => new InstallBaseImplementation(MigrationStrategy));
        }

        [Test]
        public void InstallBase_implementation_should_not_have_migration_strategy_null()
        {
            Should.Throw<ArgumentNullException>(() => new InstallBaseImplementation(null));
        }
    }

    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal class Given_an_installation_with_a_connection_string_null_or_empty : When_running_installation
    {
        [Test]
        public void When_running_migration_and_connectionstring_is_null_we_get_exception()
        {
            Should.Throw<ArgumentNullException>(() => (Successful, Message) = Install.Run(null, 0, null));
        }

        [Test]
        public void When_running_migration_and_connectionstring_is_empty_we_get_exception()
        {
            Should.Throw<ArgumentException>(() => (Successful, Message) = Install.Run("  ", 0, null));
        }
    }

    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal class Given_an_installation_with_an_escenario_where_all_parameters_all_valid : When_running_installation
    {
        private Component[] _components;

        [SetUp]
        public void Act()
        {
            _components = new[] { Component.Indexes };
        }

        [Test]
        public void Database_migration_is_called_when_all_parameters_are_set_properly()
        {
            (Successful, Message) = Install.Run(ValidConnectionString, ValidTimeout, _components);

            A.CallTo(() => MigrationStrategy.Migrate(A<Assembly>._, A<string>._, A<string>._, A<int>._)).MustHaveHappened();
        }

        [Test]
        public void Database_migration_returns_successful_result_when_all_parameters_are_set_properly()
        {
            (Successful, Message) = Install.Run(ValidConnectionString, ValidTimeout, _components);

            Successful.ShouldBeTrue();
        }
    }

    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal class Given_an_installation_with_a_not_valid_connection_string : When_running_installation
    {
        private Component[] _components;

        [SetUp]
        public void Act()
        {
            _components = new[] { Component.Indexes };
            A.CallTo(() => MigrationStrategy.Migrate(A<Assembly>._, BaseDirectory, InvalidConnectionString, ValidTimeout)).Returns(DatabaseAccessError);
        }

        [Test]
        public void Then_the_successful_returned_is_false()
        {
            (Successful, Message) = Install.Run(InvalidConnectionString, ValidTimeout, _components);
            Successful.ShouldBeFalse();
        }

        [Test]
        public void Then_an_error_message_is_returned()
        {
            (Successful, Message) = Install.Run(InvalidConnectionString, ValidTimeout, _components);
            Message.ShouldBe<string>(DatabaseAccessErrorMessage);
        }
    }

    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal class Given_an_installation_with_a_not_valid_timeout : When_running_installation
    {
        private Component[] _components;

        [SetUp]
        public void Act()
        {
            _components = new[] { Component.Indexes };

            A.CallTo(() => MigrationStrategy.Migrate(A<Assembly>._, BaseDirectory, ValidConnectionString, ValidTimeout)).Returns(DatabaseAccessError);
        }

        [Test]
        public void Then_the_successful_returned_is_false()
        {
            (Successful, Message) = Install.Run(ValidConnectionString, ValidTimeout, _components);
            Successful.ShouldBeFalse();
        }

        [Test]
        public void Then_an_error_message_is_returned()
        {
            (Successful, Message) = Install.Run(ValidConnectionString, ValidTimeout, _components);
            Message.ShouldBe<string>(DatabaseAccessErrorMessage);
        }
    }

    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal class Given_an_installation_without_collections_included : When_running_installation
    {
        private List<Component> _components;

        [SetUp]
        public void Act()
        {
            _components = new List<Component>();
        }

        [Test]
        public void Then_the_method_GetComponentsToInstall_returns_empty()
        {
            var result = Install.GetComponentsToInstall(_components);
            result.ShouldBe(_components);
        }
    }

    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal class Given_an_installation_with_Indexes_collection_included : When_running_installation
    {
        private List<Component> _components;

        [SetUp]
        public void Act()
        {
            _components = new List<Component>() { Component.Indexes };
        }

        [Test]
        public void Then_the_method_GetComponentsToInstall_returns_Indexes_component()
        {
            var result = Install.GetComponentsToInstall(_components);
            result.ShouldBe(_components);
        }
    }

    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal class Given_an_installation_with_Rls_collection_included : When_running_installation
    {
        private List<Component> _components;

        [SetUp]
        public void Act()
        {
            _components = new List<Component>() { Component.RLS };
        }

        [Test]
        public void Then_the_method_GetComponentsToInstall_returns_Rls_component()
        {
            var result = Install.GetComponentsToInstall(_components);
            result.ShouldBe(_components);
        }
    }

    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal class Given_an_installation_with_Ews_collection_included : When_running_installation
    {
        private List<Component> _components;

        [SetUp]
        public void Act()
        {
            _components = new List<Component>() { Component.Ews };
        }

        [Test]
        public void Then_the_method_GetComponentsToInstall_returns_Ews_component()
        {
            var result = Install.GetComponentsToInstall(_components);
            result.ShouldBe(_components);
        }
    }

    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal class Given_an_installation_with_Qews_collection_included : When_running_installation
    {
        private List<Component> _components;

        [SetUp]
        public void Act()
        {
            _components = new List<Component>() { Component.Qews };
        }

        [Test]
        public void Then_the_method_GetComponentsToInstall_returns_Qews_component()
        {
            var expectedResult = new List<Component>() { Component.Ews, Component.RLS, Component.Qews };

            var result = Install.GetComponentsToInstall(_components);
            result.ShouldBe(expectedResult);
        }
    }

    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal class Given_an_installation_with_Chrab_collection_included : When_running_installation
    {
        private List<Component> _components;

        [SetUp]
        public void Act()
        {
            _components = new List<Component>() { Component.Chrab };
        }

        [Test]
        public void Then_the_method_GetComponentsToInstall_returns_Chrab_component()
        {
            var result = Install.GetComponentsToInstall(_components);
            result.ShouldBe(_components);
        }
    }
}
