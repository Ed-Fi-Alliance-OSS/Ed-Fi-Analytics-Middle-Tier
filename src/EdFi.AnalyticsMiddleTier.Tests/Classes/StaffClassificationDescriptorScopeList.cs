// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class StaffClassificationDescriptorScopeList
    {
        public string AuthorizationScopeName { get; set; } //(varchar, not null)
        public string CodeValue { get; set; } //(nvarchar(128), not null)
    }
}
