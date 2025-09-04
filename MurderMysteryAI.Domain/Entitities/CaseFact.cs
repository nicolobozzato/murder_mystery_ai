using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MurderMysteryAI.Domain.Entitities
{
    public class CaseFact
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Subject { get; set; } // e.g., "NPC_A"
        public required string Predicate { get; set; } // e.g., "arrived_at"
        public string? Object { get; set; } // e.g., "bar"
        public string? Time { get; set; } // ISO8601 or custom slot
        public string Source { get; set; } = "canon";
        public double Confidence { get; set; } = 1.0;
    }
}