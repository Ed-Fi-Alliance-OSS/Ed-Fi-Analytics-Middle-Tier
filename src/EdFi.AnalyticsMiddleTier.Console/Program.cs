﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using CommandLine;
using CommandLine.Text;
using EdFi.AnalyticsMiddleTier.Common;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using Ds2 = EdFi.AnalyticsMiddleTier.DataStandard2;
using Ds31 = EdFi.AnalyticsMiddleTier.DataStandard31;
using Ds32 = EdFi.AnalyticsMiddleTier.DataStandard32;

namespace EdFi.AnalyticsMiddleTier.Console
{
    internal class Program
    {
        private static readonly string _postgresqlWarning
            = "> .\\EdFi.AnalytcsMiddleTier.Console.exe --connectionString \"...\" --engine postgres " + System.Environment.NewLine + System.Environment.NewLine
              + "Warning: PostgreSQL is an experimental feature that has not been fully tested " + System.Environment.NewLine
              + "yet. To proceed with the install, rerun the command using switch --experimental.";

        private static readonly string _odsVersionNotSupportedMessage
            = "Unable to determine the ODS database version. Please submit a ticket in Tracker for assistance: https://tracker.ed-fi.org/projects/EDFI." + System.Environment.NewLine + System.Environment.NewLine
                                                                                                                                                         + "Supported versions:" + System.Environment.NewLine
                                                                                                                                                         + "* Data Standard 2 (auto-detect presence of AddressType table)" +
                                                                                                                                                         System.Environment.NewLine
                                                                                                                                                         + "* Data Standard 3.1 (auto-detect presence of VersionLevel table and no AddressType)" +
                                                                                                                                                         System.Environment.NewLine
                                                                                                                                                         + "* Data Standard 3.2 (auto-detect presence of DeployJournal table)" +
                                                                                                                                                         System.Environment.NewLine;
        internal static void Main(string[] args)
        {
            var parser = new Parser(settings =>
            {
                settings.CaseInsensitiveEnumValues = true;
                settings.CaseSensitive = false;
                settings.HelpWriter = System.Console.Error;
            });

            parser
                .ParseArguments<Options>(args)
                .WithParsed(RunWithOptions)
                .WithNotParsed(WriteArgumentErrorMessage);

            void RunWithOptions(Options options)
            {
                bool successful = false;
                string message = string.Empty;

                string errorMessage;
                IConnectionStringValidator connectionStringValidator;
                if (options.DatabaseEngine == Engine.Default
                        || options.DatabaseEngine == Engine.MSSQL 
                        || options.DatabaseEngine == Engine.Sql 
                        || options.DatabaseEngine == Engine.Sqlserver)
                    connectionStringValidator = new SQLServerConnectionStringValidator(options.ConnectionString);
                else
                    connectionStringValidator = new NpgsqlConnectionStringValidator(options.ConnectionString);

                if (!connectionStringValidator.IsConnectionStringValid(out errorMessage))
                    message = $"Bad connection string provided. {errorMessage}";

                if (String.IsNullOrEmpty(message))
                {
                    if (options.Uninstall)
                    {
                        IUninstallStrategy strategy = null;
                        switch (options.DatabaseEngine)
                        {
                            case Engine.Postgres:
                            case Engine.Postgresql:
                                var pgsqlOrm = new DapperWrapper(new NpgsqlConnection(options.ConnectionString));
                                strategy = new PostgresUninstallStrategy(pgsqlOrm);
                                break;
                            case Engine.MSSQL:
                            case Engine.Sql:
                            case Engine.Sqlserver:
                                var sqlOrm = new DapperWrapper(new SqlConnection(options.ConnectionString));
                                strategy = new SqlServerUninstallStrategy(sqlOrm);
                                break;
                            default:
                                message = $"Database engine {options.DatabaseEngine.ToString()} is not supported. ";
                                break;
                        }
                        if (string.IsNullOrWhiteSpace(message))
                        {
                            (successful, message) = strategy?.Uninstall() ?? (false, "Strategy cannot be null");
                        }
                    }
                    else
                    {
                        InstallBase install = null;
                        IDatabaseMigrationStrategy migrationStrategy = null;
                        DataStandard dataStandardVersion = DataStandard.InvalidDs;
                        switch (options.DatabaseEngine)
                        {
                            case Engine.Sql:
                            case Engine.Sqlserver:
                            case Engine.MSSQL:
                                var sqlOrm = new DapperWrapper(new SqlConnection(options.ConnectionString));
                                migrationStrategy = new SqlServerMigrationStrategy(sqlOrm);
                                break;
                            case Engine.Postgres:
                            case Engine.Postgresql:
                            case Engine.PostgreSQL:
                                if (options.Experimental)
                                {
                                    var pgsqlOrm = new DapperWrapper(new NpgsqlConnection(options.ConnectionString));
                                    migrationStrategy = new PostgresMigrationStrategy(pgsqlOrm);
                                }
                                else
                                {
                                    message = _postgresqlWarning;
                                }
                                break;
                        }

                        if (String.IsNullOrEmpty(message))
                        {
                            dataStandardVersion = migrationStrategy?.GetDataStandardVersion() ?? DataStandard.InvalidDs;
                            switch (dataStandardVersion)
                            {
                                case DataStandard.Ds2:
                                    install = new Ds2.Install(migrationStrategy);
                                    break;

                                case DataStandard.Ds31:
                                    install = new Ds31.Install(migrationStrategy);
                                    break;
                                case DataStandard.Ds32:
                                    install = new Ds32.Install(migrationStrategy);
                                    break;
                                default:
                                    message = _odsVersionNotSupportedMessage;
                                    break;
                            }
                        }

                        if (String.IsNullOrEmpty(message))
                        {
                            try
                            {
                                (successful, message) = install?.Run(options.ConnectionString, options.TimeoutSeconds,
                                    options.Components?.ToArray()) ?? (false, "Install object is null.");
                            }
                            catch (Exception ex)
                            {
                                (successful, message) = (false, ex.ConcatenateInnerMessages());
                            }
                        }
                    }
                }

                if (!successful)
                {
                    System.Console.WriteLine(string.Empty);
                    System.Console.WriteLine(message);
                    System.Console.WriteLine(string.Empty);

                    if (Debugger.IsAttached)
                    {
                        System.Console.WriteLine("Press enter to continue.");
                        System.Console.ReadLine();
                    }

                    Environment.ExitCode = -2;
                }
                else
                {
                    System.Console.WriteLine("Success!");
                }

                Environment.ExitCode = 0;
            }

            void WriteArgumentErrorMessage(IEnumerable<Error> errors)
            {
                Environment.ExitCode = -1;
            }
        }
    }

    internal class Options
    {
        [Option('c', "connectionString", Required = true, HelpText = "Connection string for the ODS database in which to install the solution")]
        public string ConnectionString { get; set; }

        [Option('o', "options", Required = false, Default = new[] { Component.None }, HelpText = "Install optional components - provide a comma separated list with no spaces")]
        public IEnumerable<Component> Components { get; set; }

        [Option('u', "uninstall", Required = false, Default = false, HelpText = "Uninstall all analytics views and indexes")]
        public bool Uninstall { get; set; }

        [Option("experimental", Required = false, Default = false, HelpText = "PostgreSQL is an experimental feature that has not been fully tested yet. To proceed with the install, rerun the command using switch --experimental.")]
        public bool Experimental { get; set; }

        [Option('t', "timeout", Required = false, Default = 30, HelpText = "SQL Execution timeout in seconds")]
        public int TimeoutSeconds { get; set; }

        [Option('e', "engine", Required = false, Default = Engine.Sqlserver, HelpText = "Database Engine")]
        public Engine DatabaseEngine { get; set; }

        [Usage(ApplicationAlias = "EdFi.AnalyticsMiddleTier.Console.exe")]
        // ReSharper disable once UnusedMember.Global
        public static IEnumerable<Example> Examples
        {
            get
            {
                yield return new Example("Base views only, default data standard (2.x)", new Options { ConnectionString = SampleConnectionString });
                yield return new Example("Include indexes", new Options { ConnectionString = SampleConnectionString, Components = new[] { Component.Indexes } });
                yield return new Example("Include indexes and QuickSightEWS views", new Options { ConnectionString = SampleConnectionString, Components = new[] { Component.Indexes, Component.Qews } });
            }
        }

        private const string SampleConnectionString = "Server=yourServer;Initial Catalog=yourODSdbName;Integrated Security=SSPI";

    }
}