using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MurderMysteryAI.Domain.Entitities
{
    public class DialogTurn
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid NpcId { get; set; }
        public required string UserMessage { get; set; }
        public required string NpcMessageJson { get; set; } // structured JSON returned by LLM
        public string ContradictionsJson { get; set; } = "[]";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}