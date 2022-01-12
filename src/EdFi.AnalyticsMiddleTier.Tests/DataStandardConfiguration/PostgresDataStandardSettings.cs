// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.AnalyticsMiddleTier.Common;

namespace EdFi.AnalyticsMiddleTier.Tests.DataStandardConfiguration
{
    public class PostgresDataStandardSettings : DataStandardSettings
    {
        private readonly string _databaseBackupFilenameFormat = "EdFi.Ods{0}.Minimal.Template.sql";

        public PostgresDataStandardSettings(DataStandard dataStandard)
        {
            DatabaseEngine = Engine.PostgreSQL;
            InitializeSettings(dataStandard,
                "edfi_ods_tests_ds",
                "POSTGRES_DATABASE_DS",
                _databaseBackupFilenameFormat);
            DatabaseConnectionString
                = new PostgresConnectionString(DefaultDatabaseName, EnvDatabaseParameterName);
        }
    }
}
