using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MurderMysteryAI.Domain.Entitities
{
    public sealed class DialogTurn
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required Guid CaseId { get; set; }
        public required Guid NpcId { get; set; }


        public required string UserMessage { get; set; }
        public required string NpcMessageJson { get; set; }
        public string ContradictionsJson { get; set; } = "[]";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}