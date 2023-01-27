// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class AssessmentFact
    {
        public string AssessmentFactKey { get; set; }
        public string AssessmentKey { get; set; }
        public string AssessmentIdentifier { get; set; }
        public string Namespace { get; set; }
        public string Title { get; set; }
        public int Version { get; set; }
        public string Category { get; set; }
        public string AssessedGradeLevel { get; set; }
        public string AcademicSubject { get; set; }
        public string ResultDataType { get; set; }
        public string ReportingMethod { get; set; }
        public string ObjectiveAssessmentKey { get; set; }
        public string IdentificationCode { get; set; }
        public string ParentObjectiveAssessmentKey { get; set; }
        public string ObjectiveAssessmentDescription { get; set; }
        public string PercentOfAssessment { get; set; }
        public string MinScore { get; set; }
        public string MaxScore { get; set; }
        public string LearningStandard { get; set; }
    }
}
