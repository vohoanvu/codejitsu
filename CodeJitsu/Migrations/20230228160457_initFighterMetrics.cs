using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeJitsu.Migrations
{
    /// <inheritdoc />
    public partial class initFighterMetrics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AbpUsers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "FighterId",
                table: "AbpUsers",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "BeltRanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Stripe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeltRanks", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Fighters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FighterName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Height = table.Column<double>(type: "double", nullable: false),
                    Weight = table.Column<double>(type: "double", nullable: false),
                    BMI = table.Column<double>(type: "double", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    MaxWorkoutDuration = table.Column<int>(type: "int", nullable: false),
                    BeltRankId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fighters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fighters_BeltRanks_BeltRankId",
                        column: x => x.BeltRankId,
                        principalTable: "BeltRanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_FighterId",
                table: "AbpUsers",
                column: "FighterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fighters_BeltRankId",
                table: "Fighters",
                column: "BeltRankId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Fighters_FighterId",
                table: "AbpUsers",
                column: "FighterId",
                principalTable: "Fighters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Fighters_FighterId",
                table: "AbpUsers");

            migrationBuilder.DropTable(
                name: "Fighters");

            migrationBuilder.DropTable(
                name: "BeltRanks");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_FighterId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "FighterId",
                table: "AbpUsers");
        }
    }
}
