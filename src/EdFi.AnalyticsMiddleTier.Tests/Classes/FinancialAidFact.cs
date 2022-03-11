using System;
using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class FinancialAidFact
    {
        public string CandidateIdentifier { get; set; }
        public string BeginDate { get; set; }
        public string EndDate { get; set; }
        public int AidConditionDescription { get; set; }
        public int AidType { get; set; }
        public bool AidAmount { get; set; }
        public int PellGrantRecipient { get; set; }
    }
}