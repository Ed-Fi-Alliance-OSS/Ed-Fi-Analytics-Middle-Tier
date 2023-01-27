// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.AnalyticsMiddleTier.Common;

namespace EdFi.AnalyticsMiddleTier.Tests.DataStandardConfiguration
{

    public interface IDatabaseConnection
    {
        IOrm Orm { get; }

        IDatabaseMigrationStrategy DatabaseMigrationStrategy { get; }

        IUninstallStrategy UninstallStrategy { get; }

        string DatabaseName { get; }

        string MainDatabaseConnectionString { get; }

        string ConnectionString { get; }
    }
}
