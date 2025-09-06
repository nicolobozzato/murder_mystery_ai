using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MurderMysteryAI.Application.Abstraction;
using MurderMysteryAI.Domain.Entitities;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace MurderMysteryAI.Infrastructure
{
public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IAppDbContext
    {
    public DbSet<Case> Cases => Set<Case>();
    public DbSet<Npc> Npcs => Set<Npc>();
    public DbSet<Evidence> Evidences => Set<Evidence>();
    public DbSet<CaseFact> CaseFacts => Set<CaseFact>();
    public DbSet<DialogTurn> DialogTurns => Set<DialogTurn>();


    protected override void OnModelCreating(ModelBuilder b)
    {
        b.HasPostgresExtension("pg_trgm"); // fuzzy search for MVP


        b.Entity<Npc>(e =>
        {
        e.Property(x => x.Name).HasMaxLength(120);
        e.HasIndex(x => x.Name);
        });


        b.Entity<Evidence>(e =>
        {
        e.Property(x => x.Title).HasMaxLength(200);
        e.HasIndex(x => x.Title);
        // Create GIN index for trigram on Text via migration (see below)
        });


        b.Entity<CaseFact>(e =>
        {
        e.HasIndex(x => new { x.Subject, x.Predicate });
        });


        b.Entity<DialogTurn>(e =>
            {
            e.HasIndex(x => x.NpcId);
            });
        }
    }
}