using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MurderMysteryAI.Domain.Entitities;

namespace MurderMysteryAI.Application.Abstraction
{
    public interface IAppDbContext
    {
        public DbSet<Npc> Npcs { get; }
        public DbSet<Evidence> Evidences { get; }
        public DbSet<CaseFact> CaseFacts { get; }
        public DbSet<DialogTurn> DialogTurns { get; }
    }
}