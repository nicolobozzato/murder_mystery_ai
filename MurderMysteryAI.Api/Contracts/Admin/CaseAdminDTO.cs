using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MurderMysteryAI.Api.Contracts.Admin;

namespace MurderMysteryAI.Domain.Entitities
{
    public sealed record CaseAdminDTO(
      Guid Id,
      string Title,
      string Synopsis,
      string Status,
      DateTime CreatedAt,
      DateTime? PublishedAt,
      List<NpcAdminDto> Npcs,
      List<EvidenceAdminDto> Evidences,
      List<CaseFactAdminDto> Facts
    );
}
