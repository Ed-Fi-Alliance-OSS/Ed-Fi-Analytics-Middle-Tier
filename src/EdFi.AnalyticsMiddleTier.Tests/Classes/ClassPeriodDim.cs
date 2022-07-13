// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class ClassPeriodDim
    {
        public string ClassPeriodKey { get; set; } //(string, not null)
        public string SectionKey { get; set; }
        public string ClassPeriodName { get; set; } //(string, not null)
        public string LocalCourseCode { get; set; } //(string, not null)
        public int SchoolId { get; set; } //(string, not null)
        public int SchoolYear { get; set; } //(string, not null)
        public string SectionIdentifier { get; set; } //(string, not null)
        public string SessionName { get; set; } //(string, not null)
    }
}
