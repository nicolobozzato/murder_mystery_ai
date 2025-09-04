using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MurderMysteryAI.Domain.Entitities;

namespace MurderMysteryAI.Application.Abstraction
{
public interface IContradictionService
    {
    Task<(bool hasContradiction, string reason, List<Guid> factIds)> CheckAsync(IEnumerable<Claim> claims, CancellationToken ct);
    }
}