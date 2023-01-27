// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class DateDim
    {
        public string DateKey { get; set; } //(varchar(30), null)
        public DateTime Date { get; set; } //(datetime, null)
        public int Day { get; set; } //(int, null)
        public int Month { get; set; } //(int, null)
        public string MonthName { get; set; } //(nvarchar(30), null)
        public int CalendarQuarter { get; set; } //(int, null)
        public string CalendarQuarterName { get; set; } //(varchar(6), null)
        public int CalendarYear { get; set; } //(int, null)
        public string SchoolYear { get; set; } //(int, null)
    }
}
