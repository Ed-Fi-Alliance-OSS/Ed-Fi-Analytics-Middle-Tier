// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using EdFi.AnalyticsMiddleTier.Common;

namespace EdFi.AnalyticsMiddleTier.Tests.DataStandardConfiguration
{
    public interface IDataStandardSettings
    {
        Engine DatabaseEngine { get; }
        DataStandard CurrentDataStandard { get; }
        string Version { get; }
        string VersionFolderName { get; }
        string BaseVersionFolderName { get; }
        string TestDataFolderName { get; }
        IDatabaseConnection DatabaseConnection { get; }
        string DatabaseBackupFile { get; }
        Type DataStandardInstallType { get; }
    }
}
