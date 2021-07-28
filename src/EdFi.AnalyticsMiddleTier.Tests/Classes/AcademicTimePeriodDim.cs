﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    public class AcademicTimePeriodDim
    {
        public string AcademicTimePeriodKey { get; set; }

        public string SchoolYear { get; set; }

        public string SchoolYearName { get; set; }

        public bool IsCurrentSchoolYear { get; set; }

        public string SchoolKey { get; set; }

        public string SessionKey { get; set; }

        public string SessionName { get; set; }

        public string TermName { get; set;  }

        public string GradingPeriodKey { get; set; }

        public string GradingPeriodName { get; set; }

        public DateTime LastModifieDate { get; set; }
    }
}
