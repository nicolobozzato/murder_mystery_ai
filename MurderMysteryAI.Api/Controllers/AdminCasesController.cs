using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MurderMysteryAI.Application.BL;
using MurderMysteryAI.Domain.Entitities;
using MurderMysteryAI.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MurderMysteryAI.Api.Controllers
{
    [ApiController]
    [Route("api/admin/cases")]
    public sealed class AdminCasesController(AppDbContext db) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Case>> CreateCase([FromBody] CreateCaseRequest req, CancellationToken ct)
        {
            var caseInstance = new Case { Title = req.Title, Synopsis = req.Synopsis };
            db.Cases.Add(caseInstance);
            await db.SaveChangesAsync(ct);
            return CreatedAtAction(nameof(GetCase), new { caseId = caseInstance.Id }, caseInstance);
        }


        [HttpGet("{caseId:guid}")]
        public async Task<ActionResult<Case>> GetCase([FromRoute] Guid caseId, CancellationToken ct)
        {
            var caseInstance = await db.Cases
            .Include(c => c.Npcs)
            .Include(c => c.Evidences)
            .Include(c => c.Facts)
            .FirstOrDefaultAsync(c => c.Id == caseId, ct);
            return caseInstance is null ? NotFound() : Ok(caseInstance);
        }


        [HttpPost("{caseId:guid}/publish")]
        public async Task<IActionResult> Publish([FromRoute] Guid caseId, CancellationToken ct)
        {
            var caseInstance = await db.Cases.FindAsync([caseId], ct);
            if (caseInstance is null) return NotFound();
            caseInstance.Status = CaseStatus.Published;
            caseInstance.PublishedAt = DateTime.UtcNow;
            await db.SaveChangesAsync(ct);
            return Ok(new { caseInstance.Id, caseInstance.Status, caseInstance.PublishedAt });
        }
    }
}
