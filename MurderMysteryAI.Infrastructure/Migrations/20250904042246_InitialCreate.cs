using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MurderMysteryAI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:pg_trgm", ",,");

            migrationBuilder.CreateTable(
                name: "CaseFacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    Predicate = table.Column<string>(type: "text", nullable: false),
                    Object = table.Column<string>(type: "text", nullable: true),
                    Time = table.Column<string>(type: "text", nullable: true),
                    Source = table.Column<string>(type: "text", nullable: false),
                    Confidence = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseFacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DialogTurns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NpcId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserMessage = table.Column<string>(type: "text", nullable: false),
                    NpcMessageJson = table.Column<string>(type: "text", nullable: false),
                    ContradictionsJson = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DialogTurns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evidences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Source = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evidences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Npcs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Persona = table.Column<string>(type: "text", nullable: false),
                    TraitsJson = table.Column<string>(type: "text", nullable: false),
                    SecretsJson = table.Column<string>(type: "text", nullable: false),
                    MemoryJson = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Npcs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseFacts_Subject_Predicate",
                table: "CaseFacts",
                columns: new[] { "Subject", "Predicate" });

            migrationBuilder.CreateIndex(
                name: "IX_DialogTurns_NpcId",
                table: "DialogTurns",
                column: "NpcId");

            migrationBuilder.CreateIndex(
                name: "IX_Evidences_Title",
                table: "Evidences",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Npcs_Name",
                table: "Npcs",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseFacts");

            migrationBuilder.DropTable(
                name: "DialogTurns");

            migrationBuilder.DropTable(
                name: "Evidences");

            migrationBuilder.DropTable(
                name: "Npcs");
        }
    }
}
