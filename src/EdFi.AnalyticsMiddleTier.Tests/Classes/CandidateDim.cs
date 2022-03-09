﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class CandidateDim
    {
        public string CandidateIdentifier { get; set; }
        public string FirstName { get; set; }
        public string LastSurname { get; set; }
        public int SexDescriptorId { get; set; }
        public int? RaceDescriptorId { get; set; }
        public bool? HispanicLatinoEthnicity { get; set; }
        public bool? EconomicDisadvantaged { get; set; }
        public int Cohort { get; set; }
        public bool ProgramComplete { get; set; }
        public int? StudentUSI { get; set; }
        public string ProgramName { get; set; }
        public DateTime BeginDate { get; set; }
        public int EducationOrganizationId { get; set; }
        public string PersonId { get; set; }
        public string? IssuanceDate { get; set; }
        public string CohortYearTermDescription { get; set; }
    }
}