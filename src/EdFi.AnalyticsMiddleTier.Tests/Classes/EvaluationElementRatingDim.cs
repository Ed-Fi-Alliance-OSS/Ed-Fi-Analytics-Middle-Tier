// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class EvaluationElementRatingDim
    {
        public string CandidateKey { get; set; }
        public DateTime EvaluationDate { get; set; }
        public string PerformanceEvaluationTitle { get; set; }
        public string EvaluationObjectiveTitle { get; set; }
        public string EvaluationElementTitle { get; set; }
        public string RatingResultTitle { get; set; }
        public decimal Rating { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
