// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class StaffSectionDim
    {
        public string StaffSectionKey { get; set; }
        public string UserKey { get; set; }
        public string SchoolKey { get; set; }
        public string SectionKey { get; set; }
        public string PersonalTitlePrefix { get; set; }
        public string StaffFirstName { get; set; }
        public string StaffMiddleName { get; set; }
        public string StaffLastName { get; set; }
        public string ElectronicMailAddress { get; set; }
        public string Sex { get; set; }
        public string BirthDate { get; set; }
        public string Race { get; set; }
        public int? HispanicLatinoEthnicity { get; set; }
        public string HighestCompletedLevelOfEducation { get; set; }
        public decimal? YearsOfPriorProfessionalExperience { get; set; }
        public decimal? YearsOfPriorTeachingExperience { get; set; }
        public int? HighlyQualifiedTeacher { get; set; }
        public string LoginId { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
