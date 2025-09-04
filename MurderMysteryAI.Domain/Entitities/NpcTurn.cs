using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MurderMysteryAI.Domain.Entitities
{
    public sealed record NpcTurn(string Utterance, NpcMood Mood, List<Claim> Claims, List<string>? PotentialContradictionWith);
}