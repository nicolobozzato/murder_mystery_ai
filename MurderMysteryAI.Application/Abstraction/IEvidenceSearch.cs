using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MurderMysteryAI.Domain.Entitities;

namespace MurderMysteryAI.Application.Abstraction
{
    public interface IEvidenceSearch
    {
    Task<List<Evidence>> SearchAsync(string query, int limit = 5, CancellationToken ct = default);
    }
}