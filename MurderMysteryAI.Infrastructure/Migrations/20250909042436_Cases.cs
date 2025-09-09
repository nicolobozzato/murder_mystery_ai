using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MurderMysteryAI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Cases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE EXTENSION IF NOT EXISTS pg_trgm;");
            migrationBuilder.Sql("CREATE INDEX IF NOT EXISTS idx_evidence_text_trgm ON \"Evidences\" USING gin (\"Text\" gin_trgm_ops);");
            migrationBuilder.AddColumn<Guid>(
                name: "CaseId",
                table: "Npcs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CaseId",
                table: "Evidences",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CaseId",
                table: "DialogTurns",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CaseId",
                table: "CaseFacts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Synopsis = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Npcs_CaseId",
                table: "Npcs",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Evidences_CaseId",
                table: "Evidences",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseFacts_CaseId",
                table: "CaseFacts",
                column: "CaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseFacts_Cases_CaseId",
                table: "CaseFacts",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evidences_Cases_CaseId",
                table: "Evidences",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Npcs_Cases_CaseId",
                table: "Npcs",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseFacts_Cases_CaseId",
                table: "CaseFacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Evidences_Cases_CaseId",
                table: "Evidences");

            migrationBuilder.DropForeignKey(
                name: "FK_Npcs_Cases_CaseId",
                table: "Npcs");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Npcs_CaseId",
                table: "Npcs");

            migrationBuilder.DropIndex(
                name: "IX_Evidences_CaseId",
                table: "Evidences");

            migrationBuilder.DropIndex(
                name: "IX_CaseFacts_CaseId",
                table: "CaseFacts");

            migrationBuilder.DropColumn(
                name: "CaseId",
                table: "Npcs");

            migrationBuilder.DropColumn(
                name: "CaseId",
                table: "Evidences");

            migrationBuilder.DropColumn(
                name: "CaseId",
                table: "DialogTurns");

            migrationBuilder.DropColumn(
                name: "CaseId",
                table: "CaseFacts");
        }
    }
}
