using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MurderMysteryAI.Domain.Entitities
{
    public sealed record Claim(string Subject, string Predicate, string? Object, string? Time, double Certainty);
}