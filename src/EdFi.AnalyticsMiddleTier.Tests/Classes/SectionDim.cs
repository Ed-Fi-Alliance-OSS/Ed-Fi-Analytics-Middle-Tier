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
        public int SchoolKey { get; set; } //(int, not null)
        public string SectionKey { get; set; } //(nvarchar(75), not null)
        public string SectionName { get; set; } //(nvarchar(75), not null)
        public string SessionName { get; set; } //(nvarchar(75), not null)
        public string LocalCourseCode { get; set; } //(nvarchar(75), not null)
        public int SchoolYear { get; set; } //(int, not null)
        public string EducationalEnvironmentTypeId { get; set; } //(nvarchar(75), not null)
        public int LocalEducationAgencyId { get; set; } //(int, not null)
    }
}