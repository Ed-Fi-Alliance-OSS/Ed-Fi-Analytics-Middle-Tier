// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class CandidateSurveyDim
    {
        public string CandidateSurveyKey { get; set; }
        public string CandidateKey { get; set; }
        public string SurveyTitle { get; set; }
        public string SurveySectionTitle { get; set; }
        public string ResponseDateKey { get; set; }
        public string QuestionCode { get; set; }
        public string QuestionText { get; set; }
        public int? NumericResponse { get; set; }
        public string TextResponse { get; set; }
        public DateTime LastModifiedDate { get; set; }

    }
}
