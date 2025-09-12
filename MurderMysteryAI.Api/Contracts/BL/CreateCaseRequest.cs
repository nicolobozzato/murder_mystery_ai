using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MurderMysteryAI.Application.BL
{
    public class CreateCaseRequest
    {
        public required string Title { get; set; }
        public string Synopsis { get; set; } = string.Empty;
    }
}