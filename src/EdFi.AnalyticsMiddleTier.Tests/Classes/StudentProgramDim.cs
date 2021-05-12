﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class StudentProgramDim
    {
        public DateTime BeginDate { get; set; } //(date, not null)
        public int EducationOrganizationId { get; set; } //(int, not null)
        public string ProgramName { get; set; } //(nvarchar(60), not null)
        public int StudentUsi { get; set; } //(int, not null)
        public string StudentSchoolKey { get; set; } //(nvarchar(45), not null)
    }
}
