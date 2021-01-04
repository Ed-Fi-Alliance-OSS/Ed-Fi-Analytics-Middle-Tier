// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class ObjectiveAssessmentDim
    {
        public string ObjectiveAssessmentKey { get; set; }
        public string AssessmentKey { get; set; }
        public string IdentificationCode { get; set; }
        public string ParentObjectiveAssessmentKey { get; set; }
        public string Description { get; set; }
        public string Namespace { get; set; }
        public decimal PercentOfAssessment { get; set; }
        public string AcademicSubject { get; set; }
        public string MinimumScore { get; set; }
        public string MaximumScore { get; set; }
    }
}