using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MurderMysteryAI.Api.Contracts.Admin
{
    public sealed record CaseFactAdminDto(Guid Id, string Subject, string Predicate, string? Object, string? Time, double Confidence);
}