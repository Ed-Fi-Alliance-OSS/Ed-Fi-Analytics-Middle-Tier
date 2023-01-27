// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Common
{
    /// <summary>
    /// These component names should correspond precisely - including case - with the names
    /// of directories contain optional components. For example, if you add a directory
    /// called "Assessments" then add "Assessments" as a new enumeration below.
    /// </summary>
    public enum Component
    {
        None,
        Indexes,
        Qews,
        Ews,
        RLS,
        Chrab,
        Asmt,
        Equity,
        Engage,
        EPP
    }
    public enum DataStandard
    {
        InvalidDs,
        Ds2,
        Ds31,
        Ds32,
        Ds33
    }
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum Engine
    {
        Default,
        Sql,
        Sqlserver,
        MSSQL,
        Postgres,
        Postgresql,
        PostgreSQL
    }
}
