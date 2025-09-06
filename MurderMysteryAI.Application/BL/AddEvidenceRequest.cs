using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MurderMysteryAI.Application.BL
{
    public class AddEvidenceRequest
    {
        public required Guid CaseId { get; set; }
        public required string Title { get; set; }
        public required string Text { get; set; }
        public string Source { get; set; } = "manual";
    }
}