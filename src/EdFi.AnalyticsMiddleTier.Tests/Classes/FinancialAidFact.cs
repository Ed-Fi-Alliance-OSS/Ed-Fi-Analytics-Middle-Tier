// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class FinancialAidFact
    {
        public string CandidateAidKey { get; set; }
        public string CandidateIdentifier { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AidConditionDescription { get; set; }
        public string AidType { get; set; }
        public decimal AidAmount { get; set; }
        public Boolean PellGrantRecipient { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
