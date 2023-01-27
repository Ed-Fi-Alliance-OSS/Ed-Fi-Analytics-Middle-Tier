// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class StudentHistoryDim
    {
        public string StudentKey { get; set; }
        public string StudentSchoolKey { get; set; }
        public string GradeSummary { get; set; }
        public string CurrentSchoolKey { get; set; }
        public decimal? AttendanceRate
        {
            get
            {
                return _AttendanceRate;
            }
            set
            {
                _AttendanceRate = value != null ? Math.Round(value ?? 0, 2) : value;
            }
        }
        public int? ReferralsAndSuspensions { get; set; }
        public string EnrollmentHistory { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        private decimal? _AttendanceRate = 0;
    }
}
