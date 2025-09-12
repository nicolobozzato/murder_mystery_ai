using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MurderMysteryAI.Application.BL;
using MurderMysteryAI.Domain.Entitities;
using MurderMysteryAI.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MurderMysteryAI.Application.DTOs;
using AutoMapper;

namespace MurderMysteryAI.Api.Controllers
{
    [ApiController]
    [Route("api/admin/cases")]
    public sealed class AdminCasesController(AppDbContext db, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<CaseAdminDTO>> CreateCase([FromBody] CreateCaseRequest req, CancellationToken ct)
        {
            var caseInstance = new Case { Title = req.Title, Synopsis = req.Synopsis };
            db.Cases.Add(caseInstance);
            await db.SaveChangesAsync(ct);
            var dto = mapper.Map<CaseAdminDTO>(caseInstance);
            return CreatedAtAction(nameof(GetCase), new { caseId = caseInstance.Id }, dto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CasesLightInfoDTO>>> GetAllCases(CancellationToken ct)
        {
            var cases = await db.Cases
            .Include(c => c.Npcs)
            .Include(c => c.Evidences)
            .Include(c => c.Facts)
            .ToListAsync(ct);
            return Ok(cases.Select(c => new CasesLightInfoDTO
            {
                Id = c.Id,
                Title = c.Title,
                Synopsis = c.Synopsis
            }));
        }

        [HttpGet("{caseId:guid}")]
        public async Task<ActionResult<CaseAdminDTO>> GetCase([FromRoute] Guid caseId, CancellationToken ct)
        {
            var caseInstance = await db.Cases
            .Include(c => c.Npcs)
            .Include(c => c.Evidences)
            .Include(c => c.Facts)
            .FirstOrDefaultAsync(c => c.Id == caseId, ct);
            return caseInstance is null ? NotFound() : Ok(mapper.Map<CaseAdminDTO>(caseInstance));
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
