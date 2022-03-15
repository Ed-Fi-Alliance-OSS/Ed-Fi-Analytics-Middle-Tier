using System;
using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Tests.Classes
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class FinancialAidFact
    {
        public string CandidateIdentifier { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AidConditionDescription { get; set; }
        public string AidType { get; set; }
        public decimal AidAmount { get; set; }
        public Boolean PellGrantRecipient { get; set; }
    }
}