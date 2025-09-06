using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MurderMysteryAI.Domain.Entitities
{
    public sealed class CaseFact
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required Guid CaseId { get; set; }
        public Case Case { get; set; } = default!;


        public required string Subject { get; set; }
        public required string Predicate { get; set; }
        public string? Object { get; set; }
        public string? Time { get; set; }
        public string Source { get; set; } = "canon";
        public double Confidence { get; set; } = 1.0;
    }
}