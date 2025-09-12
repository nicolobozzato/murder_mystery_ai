using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MurderMysteryAI.Api.Contracts.Admin
{
    public sealed record NpcAdminDto(Guid Id, string Name, string Persona, string TraitsJson, string SecretsJson);
}