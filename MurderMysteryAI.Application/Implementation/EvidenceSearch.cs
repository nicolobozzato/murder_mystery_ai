using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MurderMysteryAI.Application.Abstraction;
using MurderMysteryAI.Domain.Entitities;
using Microsoft.EntityFrameworkCore;

namespace MurderMysteryAI.Application.Implementation
{
    public class EvidenceSearch(IAppDbContext db) : IEvidenceSearch
    {
        // MVP: trigram/ILIKE
        public async Task<List<Evidence>> SearchAsync(string query, int limit = 5, CancellationToken ct = default)
        {
            return await db.Evidences
                .Where(e => EF.Functions.Like(e.Text, $"%{query}%"))
                .OrderByDescending(e => e.Text.Length)
                .Take(limit)
                .ToListAsync(ct);
 
        }
    }
}