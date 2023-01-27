// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class StudentSectionGradeFact
    {
        public int StudentKey { get; set; } //(int, not null)
        public int SchoolKey { get; set; } //(int, not null)
        public string GradingPeriodKey { get; set; } //(nvarchar(92), null)
        public string StudentSectionKey { get; set; } //(nvarchar(544), null)
        public string SectionKey { get; set; } //(nvarchar(482), null)
        public decimal? NumericGradeEarned { get; set; } //(decimal(9,2), null)
        public string LetterGradeEarned { get; set; } //(nvarchar(20), null)
        public string GradeType { get; set; }
    }
}
