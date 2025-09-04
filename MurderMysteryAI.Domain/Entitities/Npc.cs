using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MurderMysteryAI.Domain.Entitities
{
    public sealed class Npc
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public string Persona { get; set; } = string.Empty; // system prompt fragment
        public string TraitsJson { get; set; } = "{}";
        public string SecretsJson { get; set; } = "{}";
        public string MemoryJson { get; set; } = "{}"; // per-session can be elsewhere
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}