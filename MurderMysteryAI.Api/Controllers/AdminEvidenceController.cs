using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MurderMysteryAI.Api.Contracts.Admin;
using MurderMysteryAI.Application.BL;
using MurderMysteryAI.Domain.Entitities;
using MurderMysteryAI.Infrastructure;

namespace MurderMysteryAI.Api.Controllers
{
    [ApiController]
    [Route("api/admin/cases/{caseId:guid}/evidences")]
    public sealed class AdminEvidencesController(AppDbContext db, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<EvidenceAdminDto>> AddEvidence([FromRoute] Guid caseId, [FromBody] AddEvidenceRequest req, CancellationToken ct)
        {
            if (!await db.Cases.AnyAsync(c => c.Id == caseId, ct)) return NotFound();
            var ev = new Evidence { CaseId = caseId, Title = req.Title, Text = req.Text, Source = req.Source ?? "manual" };
            db.Evidences.Add(ev);
            await db.SaveChangesAsync(ct);
            return Created($"api/admin/cases/{caseId}/evidences/{ev.Id}", mapper.Map<EvidenceAdminDto>(ev));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EvidenceAdminDto>>> GetEvidences([FromRoute] Guid caseId, CancellationToken ct)
        {
            if (!await db.Cases.AnyAsync(c => c.Id == caseId, ct)) return NotFound();
            var evidences = await db.Evidences.Where(e => e.CaseId == caseId).ToListAsync(ct);
            return Ok(evidences.Select(e => mapper.Map<EvidenceAdminDto>(e)));
        }
    }
}