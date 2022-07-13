// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class SectionDim
    {
        public string SchoolKey { get; set; } //(nvarchar(30), null)
        public string SectionKey { get; set; } //(nvarchar(439), null)
        public string SectionName { get; set; } //(nvarchar(121), not null)
        public string SessionName { get; set; } //(nvarchar(60), not null)
        public string LocalCourseCode { get; set; } //(nvarchar(60), not null)
        public int SchoolYear { get; set; } //(smallint, not null)
        public string EducationalEnvironmentDescriptor { get; set; } //(nvarchar(1024), null)
        public int LocalEducationAgencyKey { get; set; } //(int, null)
        public string Description { get; set; } //(nvarchar(75), null)
        public DateTime LastModifiedDate { get; set; } //(datetime, null)

        public string SessionKey { get; set; }
    }
}
