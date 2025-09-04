using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MurderMysteryAI.Application.Abstraction;
using MurderMysteryAI.Domain.Entitities;

namespace MurderMysteryAI.Application.Implementation
{
    public sealed class ContradictionService(IAppDbContext db) : IContradictionService
    {
        public async Task<(bool, string, List<Guid>)> CheckAsync(IEnumerable<Claim> claims, CancellationToken ct)
        {
            var reasons = new List<string>();
            var linked = new List<Guid>();
            foreach (var c in claims)
            {
                var matches = await db.CaseFacts
                .Where(f => f.Subject == c.Subject && f.Predicate == c.Predicate)
                .ToListAsync(ct);


                foreach (var f in matches)
                {
                    // simple mismatch logic
                    if (f.Object != null && c.Object != null && !string.Equals(f.Object, c.Object, StringComparison.OrdinalIgnoreCase))
                    {
                        reasons.Add($"Object mismatch: '{c.Object}' vs canon '{f.Object}'");
                        linked.Add(f.Id);
                    }
                    if (!string.IsNullOrEmpty(f.Time) && !string.IsNullOrEmpty(c.Time) && !string.Equals(f.Time, c.Time, StringComparison.OrdinalIgnoreCase))
                    {
                        reasons.Add($"Time mismatch: '{c.Time}' vs canon '{f.Time}'");
                        linked.Add(f.Id);
                    }
                }
            }
            return (reasons.Count > 0, string.Join("; ", reasons.Distinct()), linked);
        }
    }
}