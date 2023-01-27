// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.AnalyticsMiddleTier.Common;

namespace EdFi.AnalyticsMiddleTier.Tests.DataStandardConfiguration
{
    public class SqlServerDataStandardSettings : DataStandardSettings
    {
        public override Engine DatabaseEngine => Engine.MSSQL;

        protected override string DatabaseBackupFileFormat => "EdFi_Ods_{0}.dacpac";

        public SqlServerDataStandardSettings(DataStandard dataStandard)
        {
            InitializeSettings(dataStandard);
            DatabaseConnection
                = new SqlServerConnection(DatabaseVersionSuffix);

        }
    }
}
