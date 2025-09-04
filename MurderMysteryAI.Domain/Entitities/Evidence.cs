using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MurderMysteryAI.Domain.Entitities
{
    public class Evidence
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Title { get; set; }
        public required string Text { get; set; }
        public string Source { get; set; } = "manual";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}