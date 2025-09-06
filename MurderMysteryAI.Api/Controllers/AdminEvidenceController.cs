using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MurderMysteryAI.Application.BL;
using MurderMysteryAI.Domain.Entitities;
using MurderMysteryAI.Infrastructure;

namespace MurderMysteryAI.Api.Controllers
{
    [ApiController]
    [Route("api/admin/cases/{caseId:guid}/evidences")]
    public sealed class AdminEvidencesController(AppDbContext db) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Evidence>> AddEvidence([FromRoute] Guid caseId, [FromBody] AddEvidenceRequest req, CancellationToken ct)
        {
            if (!await db.Cases.AnyAsync(c => c.Id == caseId, ct)) return NotFound();
            var ev = new Evidence { CaseId = caseId, Title = req.Title, Text = req.Text, Source = req.Source ?? "manual" };
            db.Evidences.Add(ev);
            await db.SaveChangesAsync(ct);
            return Created($"api/admin/cases/{caseId}/evidences/{ev.Id}", ev);
        }
    }
}