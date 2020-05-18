﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Reflection;
using EdFi.AnalyticsMiddleTier.Common;

namespace EdFi.AnalyticsMiddleTier.DataStandard31
{
    public class Install : InstallBase
    {
        public Install(IDatabaseMigrationStrategy databaseMigrationStrategy) : base(databaseMigrationStrategy)
        {
        }
        protected override void RunInstall(string directoryName)
        {
            Install(Assembly.GetExecutingAssembly(), directoryName);
        }
    }
}