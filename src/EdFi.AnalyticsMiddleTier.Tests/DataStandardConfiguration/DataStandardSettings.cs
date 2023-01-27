// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.Collections.Generic;
using EdFi.AnalyticsMiddleTier.Common;

namespace EdFi.AnalyticsMiddleTier.Tests.DataStandardConfiguration
{
    public abstract class DataStandardSettings : IDataStandardSettings
    {
        private const string DefaultVersionSeparator = ".";
        private const string FileNameSeparator = "_";

        public abstract Engine DatabaseEngine { get; }
        public DataStandard CurrentDataStandard { get; protected set; }
        public string Version { get; protected set; }
        public string VersionFolderName => ($"v{FileNameSeparator}{Version.Replace(DefaultVersionSeparator, FileNameSeparator)}");
        public string BaseVersionFolderName => $"v{FileNameSeparator}{BaseVersion.Replace(DefaultVersionSeparator, FileNameSeparator)}";
        public string TestDataFolderName => $"{DatabaseEngine}.{VersionFolderName}";
        public string DatabaseBackupFile => String.Format(DatabaseBackupFileFormat, (Version.Equals("2") ? "2.0" : Version));
        public IDatabaseConnection DatabaseConnection { get; protected set; }
        public Type DataStandardInstallType { get; protected set; }

        protected string BaseVersion => Version.Split(DefaultVersionSeparator)[0];
        protected abstract string DatabaseBackupFileFormat { get; }
        protected string DatabaseVersionSuffix => $"{Version.Replace(DefaultVersionSeparator, string.Empty)}";
        protected Dictionary<DataStandard, (string version, Type typeInstall)> SupportedVersion
            => (new DataStandardVersion()).SupportedVersion;

        protected DataStandardSettings()
        {
            Version = string.Empty;
        }

        protected void InitializeSettings(DataStandard dataStandard)
        {
            CurrentDataStandard = dataStandard;
            Version = SupportedVersion[dataStandard].version;
            DataStandardInstallType = SupportedVersion[dataStandard].typeInstall;
        }
    }
}
