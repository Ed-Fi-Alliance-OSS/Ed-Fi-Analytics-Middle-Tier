// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class ChronicAbsenteeismAttendanceFact
    {
        public string StudentSchoolKey { get; set; }
        public string StudentKey { get; set; }
        public string SchoolKey { get; set; }
        public string DateKey { get; set; }
        public int? ReportedAsPresentAtSchool { get; set; }
        public int? ReportedAsAbsentFromSchool { get; set; }
        public int? ReportedAsPresentAtHomeRoom { get; set; }
        public int? ReportedAsAbsentFromHomeRoom { get; set; }
        public int? ReportedAsIsPresentInAllSections { get; set; }
        public int? ReportedAsAbsentFromAnySection { get; set; }
    }
}
