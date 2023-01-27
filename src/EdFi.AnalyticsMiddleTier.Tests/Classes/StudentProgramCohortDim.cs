// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class StudentProgramCohortDim
    {
        public string StudentProgramCohortKey { get; set; }
        public string StudentSchoolProgramKey { get; set; }
        public string StudentSchoolKey { get; set; }
        public string EntryGradeLevelDescriptor { get; set; }
        public string CohortTypeDescriptor { get; set; }
        public string CohortDescription { get; set; }
        public string ProgramName { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
