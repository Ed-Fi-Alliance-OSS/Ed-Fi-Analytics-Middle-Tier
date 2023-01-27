// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class StudentEarlyWarningFact
    {
        public int StudentKey { get; set; } //(int, not null)
        public int SchoolKey { get; set; } //(int, not null)
        public string DateKey { get; set; } //(varchar(30), null)
        public int? IsInstructionalDay { get; set; } //(int, not null)
        public int? IsEnrolled { get; set; } //(int, not null)
        public int? IsPresentSchool { get; set; } //(int, not null)
        public int? IsAbsentFromSchoolExcused { get; set; } //(int, not null)
        public int? IsAbsentFromSchoolUnexcused { get; set; } //(int, not null)
        public int? IsTardyToSchool { get; set; } //(int, not null)
        public int? IsPresentHomeroom { get; set; } //(int, not null)
        public int? IsAbsentFromHomeroomExcused { get; set; } //(int, not null)
        public int? IsAbsentFromHomeroomUnexcused { get; set; } //(int, not null)
        public int? IsTardyToHomeroom { get; set; } //(int, not null)
        public int? IsPresentAnyClass { get; set; } //(int, not null)
        public int? IsAbsentFromAnyClassExcused { get; set; } //(int, not null)
        public int? IsAbsentFromAnyClassUnexcused { get; set; } //(int, not null)
        public int? IsTardyToAnyClass { get; set; } //(int, not null)
        public int? CountByDayOfStateOffenses { get; set; } //(int, not null)
        public int? CountByDayOfConductOffenses { get; set; } //(int, not null)
    }
}
