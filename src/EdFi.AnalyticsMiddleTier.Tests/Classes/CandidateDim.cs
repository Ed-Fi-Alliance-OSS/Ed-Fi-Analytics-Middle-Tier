// SPDX-License-Identifier: Apache-2.0
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
        public string CandidateKey { get; set; }
        public string FirstName { get; set; }
        public string LastSurname { get; set; }
        public string SexDescriptorKey { get; set; }
        public string SexDescriptor { get; set; }
        public string RaceDescriptorKey { get; set; }
        public string RaceDescriptor { get; set; }
        public bool? HispanicLatinoEthnicity { get; set; }
        public bool? EconomicDisadvantaged { get; set; }
        public string Cohort { get; set; }
        public bool ProgramComplete { get; set; }
        public string StudentUSI { get; set; }
        public string StudentKey { get; set; }
        public string ProgramName { get; set; }
        public DateTime BeginDate { get; set; }
        public int EducationOrganizationId { get; set; }
        public string PersonId { get; set; }
        public string IssuanceDate { get; set; }
        public string CohortYearTermDescription { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}