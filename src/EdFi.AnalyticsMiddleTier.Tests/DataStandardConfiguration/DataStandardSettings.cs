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
        protected Dictionary<DataStandard, (string version, Type typeInstall)> SupportedVersion
        {
            get
            {
                var versions = new Dictionary<DataStandard, (string version, Type typeInstall)>
                {
                    {DataStandard.Ds2,  ("2", typeof(DataStandard2.Install))},
                    {DataStandard.Ds31, ("3.1", typeof(DataStandard31.Install))},
                    {DataStandard.Ds32, ("3.2", typeof(DataStandard32.Install))},
                    {DataStandard.Ds33, ("3.3", typeof(DataStandard33.Install))}
                };
                return versions;
            }
        }
        public Engine DatabaseEngine { get; protected set; }
        public DataStandard CurrentDataStandard { get; protected set; }
        public string Version { get; set; }
        public string VersionFolderName => ($"v{FileNameSeparator}{Version.Replace(DefaultVersionSeparator, FileNameSeparator)}");
        public string BaseVersionFolderName => $"v{FileNameSeparator}{BaseVersion.Replace(DefaultVersionSeparator, FileNameSeparator)}";
        public string TestDataFolderName => $"{DatabaseEngine}.{VersionFolderName}";
        public string DatabaseBackupFile => String.Format(DatabaseBackupFileFormat, Version.Replace("2","2.0"));
        public IDatabaseConnectionString DatabaseConnectionString { get;protected set; }
        public Type DataStandardInstallType { get; set; }

        protected string BaseVersion => Version.Split(DefaultVersionSeparator)[0];
        protected string DefaultDatabaseName => $"{DatabaseNamePrefix}{DatabaseVersionSuffix}";
        protected string EnvDatabaseParameterName => $"{EnvParameterPrefix}{DatabaseVersionSuffix.ToUpper()}";
        
        protected string DatabaseBackupFileFormat { get; set; }
        protected string DatabaseNamePrefix { get; set; }
        protected string DatabaseVersionSuffix => $"{Version.Replace(DefaultVersionSeparator, string.Empty)}";
        protected string EnvParameterPrefix { get; set; }

        protected DataStandardSettings()
        {
            Version = string.Empty;
        }

        protected void InitializeSettings(DataStandard dataStandard, 
            string databaseNamePrefix,
            string envParameterPrefix,
            string databaseBackupFileFormat)
        {
            CurrentDataStandard = dataStandard;
            Version = SupportedVersion[dataStandard].version;
            DatabaseNamePrefix = databaseNamePrefix;
            EnvParameterPrefix = envParameterPrefix;
            DataStandardInstallType = SupportedVersion[dataStandard].typeInstall;
            DatabaseBackupFileFormat = databaseBackupFileFormat;
        }
    }
}
