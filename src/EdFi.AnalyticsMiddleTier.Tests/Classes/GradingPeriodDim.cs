// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class GradingPeriodDim
    {
        public string GradingPeriodKey { get; set; } //(nvarchar(92), null)
        public string GradingPeriodBeginDateKey { get; set; } //(nvarchar(30), null)
        public string GradingPeriodEndDateKey { get; set; } //(nvarchar(30), null)
        public string GradingPeriodDescription { get; set; } //(nvarchar(50), not null)
        public int TotalInstructionalDays { get; set; } //(int, not null)
        public int PeriodSequence { get; set; } //(int, null)
        public int SchoolKey { get; set; } //(int, not null)
        public string SchoolYear { get; set; } //(int, not null)
        public DateTime LastModifiedDate { get; set; } //(datetime, not null)
    }
}
