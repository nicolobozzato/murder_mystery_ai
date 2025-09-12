using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MurderMysteryAI.Api.Contracts.BL
{
    public sealed record CaseFactUpsert(string Subject, string Predicate, string? Object, string? Time, double? Confidence);

}