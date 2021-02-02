// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class AssessmentDim
    {
        public string AssessmentKey { get; set; }
        public string Namespace { get; set; }
        public string Title { get; set; }
        public int Version { get; set; }
        public string Category { get; set; }
        public string AssessedGradeLevel { get; set; }
        public string AcademicSubject { get; set; }
        public string MinScore { get; set; }
        public string MaxScore { get; set; }
    }
}