// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class SchoolDim
    {
        public int SchoolKey { get; set; } //(int, not null)
        public string SchoolName { get; set; } //(nvarchar(75), not null)
        public string SchoolType { get; set; } //(nvarchar(50), not null)
        public string SchoolAddress { get; set; } //(nvarchar(302), not null)
        public string SchoolCity { get; set; } //(nvarchar(30), not null)
        public string SchoolCounty { get; set; } //(nvarchar(30), not null)
        public string SchoolState { get; set; } //(nvarchar(50), not null)
        public string LocalEducationAgencyName { get; set; } //(nvarchar(75), not null)
        public int LocalEducationAgencyKey { get; set; } //(int, null)
        public string StateEducationAgencyName { get; set; } //(nvarchar(75), not null)
        public int StateEducationAgencyKey { get; set; } //(int, null)
        public string EducationServiceCenterName { get; set; } //(nvarchar(75), not null)
        public int EducationServiceCenterKey { get; set; } //(int, null)
        public DateTime LastModifiedDate { get; set; } //(datetime, null)
    }
}
