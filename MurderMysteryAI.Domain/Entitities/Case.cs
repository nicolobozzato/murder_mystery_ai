using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MurderMysteryAI.Domain.Entitities
{
    public sealed class Case
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Title { get; set; }
        public string Synopsis { get; set; } = string.Empty;
        public CaseStatus Status { get; set; } = CaseStatus.Draft;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? PublishedAt { get; set; }


        public ICollection<Npc> Npcs { get; set; } = new List<Npc>();
        public ICollection<Evidence> Evidences { get; set; } = new List<Evidence>();
        public ICollection<CaseFact> Facts { get; set; } = new List<CaseFact>();
    }

}