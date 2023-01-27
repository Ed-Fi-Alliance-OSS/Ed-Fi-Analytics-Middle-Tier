// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class StudentSectionDim
    {
        public string StudentSectionKey { get; set; } //(nvarchar(544), null)
        public string StudentSchoolKey { get; set; } //(nvarchar(61), null)
        public int StudentKey { get; set; } //(int, not null)
        public string SectionKey { get; set; } //(nvarchar(482), null)
        public string LocalCourseCode { get; set; } //(nvarchar(60), not null)
        public string Subject { get; set; } //(nvarchar(50), not null)
        public string CourseTitle { get; set; } //(nvarchar(60), not null)
        public string TeacherName { get; set; } //(nvarchar(max), not null)
        public string StudentSectionStartDateKey { get; set; } //(nvarchar(30), null)
        public string StudentSectionEndDateKey { get; set; } //(nvarchar(30), null)
        public int SchoolKey { get; set; } //(int, not null)
        public string SchoolYear { get; set; } //(int, not null)
        public DateTime LastModifiedDate { get; set; } //(datetime, null)
    }
}
