// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class StudentAssessmentFact
    {
        public string StudentAssessmentKey { get; set; }
        public string AssessmentKey { get; set; }
        public string StudentSchoolKey { get; set; }
        public int SchoolKey { get; set; }
        public string AdministrationDate { get; set; }
        public string StudentScore { get; set; }
        public string ResultDataType { get; set; }
        public string ReportingMethod { get; set; }
        public string PerformanceResult { get; set; }
    }
}
