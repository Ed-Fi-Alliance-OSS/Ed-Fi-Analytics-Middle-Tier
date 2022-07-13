// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;

namespace EdFi.AnalyticsMiddleTier.Tests.Common
{
    public class SeedData
    {
        public static List<String> GetViews()
        {
            return new List<string>()
            {
                {"GradingPeriodDim"},
                {"MostRecentGradingPeriod"}
            };
        }

        public static IReadOnlyList<String> GetStoredProcedures()
        {
            return new List<string>()
            {
                {"rls_InsertStaffClassificationDescriptorScope"},
                {"rls_RemoveStaffClassificationDescriptorScope"}
            };
        }

        public static IReadOnlyList<String> GetIndexes()
        {
            return new List<string>()
            {
                {"Index1"}
            };
        }
    }
}
