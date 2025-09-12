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
    [Route("api/admin/cases/{caseId:guid}/npcs")]
    public sealed class AdminNpcsController(AppDbContext db, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<NpcAdminDto>> AddNpc([FromRoute] Guid caseId, [FromBody] AddNpcRequest req, CancellationToken ct)
        {
            var exists = await db.Cases.AnyAsync(c => c.Id == caseId, ct);
            if (!exists) return NotFound();
            var npc = new Npc
            {
                CaseId = caseId,
                Name = req.Name,
                Persona = req.Persona,
                TraitsJson = req.TraitsJson ?? "{}",
                SecretsJson = req.SecretsJson ?? "{}"
            };
            db.Npcs.Add(npc);
            await db.SaveChangesAsync(ct);
            return Created($"api/admin/cases/{caseId}/npcs/{npc.Id}", mapper.Map<NpcAdminDto>(npc));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NpcAdminDto>>> GetNpcs([FromRoute] Guid caseId, CancellationToken ct)
        {
            var exists = await db.Cases.AnyAsync(c => c.Id == caseId, ct);
            if (!exists) return NotFound();
            var npcs = await db.Npcs.Where(n => n.CaseId == caseId).ToListAsync(ct);
            return Ok(npcs.Select(n => mapper.Map<NpcAdminDto>(n)));
        }
    }
}