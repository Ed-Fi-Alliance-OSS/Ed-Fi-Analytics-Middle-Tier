﻿using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class StudentInternetAccessDim
    {
        public string StudentSchoolKey { get; set; }

        public string SchoolKey { get; set; }

        public string InternetAccessInResidence { get; set; }

        public string InternetAccessTypeInResidence { get; set; }

        public string InternetPerformance { get; set; }

        public string DigitalDevice { get; set; }

        public string DeviceAccess { get; set; }
    }
}
