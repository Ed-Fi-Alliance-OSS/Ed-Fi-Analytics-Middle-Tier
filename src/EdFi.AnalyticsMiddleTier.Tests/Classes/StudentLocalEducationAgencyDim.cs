// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class StudentLocalEducationAgencyDim
    {
        public string StudentLocalEducationAgencyKey { get; set; } //(nvarchar(61), null)
        public string StudentKey { get; set; } //(nvarchar(32), not null)
        public string LocalEducationAgencyKey { get; set; } //(int, not null)
        public string SchoolYear { get; set; } //(nvarchar(30), null)
        public string StudentFirstName { get; set; } //(nvarchar(75), not null)
        public string StudentMiddleName { get; set; } //(nvarchar(75), null)
        public string StudentLastName { get; set; } //(nvarchar(75), not null)
        public string GradeLevel { get; set; } //(nvarchar(50), not null)
        public string LimitedEnglishProficiency { get; set; } //(nvarchar(50), not null)
        public bool IsHispanic { get; set; } //(bit, not null)
        public string Sex { get; set; } //(nvarchar(50), null)
        public DateTime LastModifiedDate { get; set; } //(datetime, null)
        public string InternetAccessInResidence { get; set; } //(nvarchar(60), not null)
        public string InternetAccessTypeInResidence { get; set; } //(nvarchar(60), not null)
        public string InternetPerformance { get; set; } //(nvarchar(60), not null)
        public string DigitalDevice { get; set; } //(nvarchar(60), not null)
        public string DeviceAccess { get; set; } //(nvarchar(60), not null)
    }
}
