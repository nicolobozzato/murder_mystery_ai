using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MurderMysteryAI.Application.BL
{
    public class AddNpcRequest
    {
        public required string Name { get; set; }
        public string Persona { get; set; } = string.Empty;
        public string TraitsJson { get; set; } = "{}";
        public string SecretsJson { get; set; } = "{}";
        public string MemoryJson { get; set; } = "{}";
    }
}