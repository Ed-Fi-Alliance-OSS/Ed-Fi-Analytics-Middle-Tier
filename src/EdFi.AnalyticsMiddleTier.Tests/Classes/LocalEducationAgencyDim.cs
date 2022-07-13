// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class LocalEducationAgencyDim
    {
        public int LocalEducationAgencyKey { get; set; } //(int, not null)
        public string LocalEducationAgencyName { get; set; } //(nvarchar(75), not null)
        public string LocalEducationAgencyType { get; set; } //(nvarchar(50), not null)
        public int LocalEducationAgencyParentLocalEducationAgencyKey { get; set; } //(int, null)
        public string LocalEducationAgencyStateEducationAgencyName { get; set; } //(nvarchar(75), not null)
        public int? LocalEducationAgencyStateEducationAgencyKey { get; set; } //(int, null)
        public string LocalEducationAgencyServiceCenterName { get; set; } //(nvarchar(75), not null)
        public int LocalEducationAgencyServiceCenterKey { get; set; } //(int, null)
        public string LocalEducationAgencyCharterStatus { get; set; } //(nvarchar(50), not null)
        public DateTime LastModifiedDate { get; set; } //(datetime, null)
    }
}
