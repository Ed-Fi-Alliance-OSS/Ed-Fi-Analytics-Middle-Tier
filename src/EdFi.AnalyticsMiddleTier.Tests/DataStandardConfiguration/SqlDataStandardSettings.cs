// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.AnalyticsMiddleTier.Common;

namespace EdFi.AnalyticsMiddleTier.Tests.DataStandardConfiguration
{
    public class SqlDataStandardSettings : DataStandardSettings
    {
        private readonly string DATABASE_BACKUP_FILENAME_FORMAT = "EdFi_Ods_{0}.dacpac";

        public SqlDataStandardSettings(DataStandard dataStandard)
        {
            DatabaseEngine = Engine.MSSQL;
            InitializeSettings(dataStandard,
                "AnalyticsMiddleTier_Testing_Ds",
                "SQLSERVER_DATABASE_DS",
                DATABASE_BACKUP_FILENAME_FORMAT);
            DatabaseConnectionString
                = new SqlServerConnectionString(DefaultDatabaseName, EnvDatabaseParameterName);

        }
    }
}
