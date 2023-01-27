// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class ContactPersonDim
    {
        public int ContactPersonKey { get; set; } //(int, not null)
        public int StudentKey { get; set; } //(int, not null)
        public string ContactFirstName { get; set; } //(nvarchar(75), not null)
        public string ContactLastName { get; set; } //(nvarchar(75), not null)
        public string RelationshipToStudent { get; set; } //(nvarchar(50), not null)
        public string ContactHomeAddress { get; set; } //(nvarchar(303), not null)
        public string ContactPhysicalAddress { get; set; } //(nvarchar(303), not null)
        public string ContactMailingAddress { get; set; } //(nvarchar(303), not null)
        public string ContactWorkAddress { get; set; } //(nvarchar(303), not null)
        public string ContactTemporaryAddress { get; set; } //(nvarchar(303), not null)
        public string HomePhoneNumber { get; set; } //(nvarchar(24), not null)
        public string MobilePhoneNumber { get; set; } //(nvarchar(24), not null)
        public string WorkPhoneNumber { get; set; } //(nvarchar(24), not null)
        public string PrimaryEmailAddress { get; set; } //(nvarchar(13), not null)
        public string PersonalEmailAddress { get; set; } //(nvarchar(128), not null)
        public string WorkEmailAddress { get; set; } //(nvarchar(128), not null)
        public bool? IsPrimaryContact { get; set; } //(bit, not null)
        public bool? StudentLivesWith { get; set; } //(bit, not null)
        public bool? IsEmergencyContact { get; set; } //(bit, not null)
        public int? ContactPriority { get; set; } //(int, not null)
        public string ContactRestrictions { get; set; } //(nvarchar(250), not null)
        public DateTime LastModifiedDate { get; set; } //(datetime, null)
        public string PostalCode { get; set; } //(nvarchar(250), not null)
    }
}
