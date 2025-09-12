using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MurderMysteryAI.Api.Contracts.Admin
{
    public sealed record EvidenceAdminDto(Guid Id, string Title, string Text, string Source, DateTime CreatedAt);
}