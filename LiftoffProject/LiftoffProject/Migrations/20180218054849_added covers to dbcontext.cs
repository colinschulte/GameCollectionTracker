using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LiftoffProject.Migrations
{
    public partial class addedcoverstodbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.AddColumn<int>(
                name: "CoverId",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Covers",
                columns: table => new
                {
                    CoverId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CloudinaryId = table.Column<string>(nullable: true),
                    Height = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Width = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Covers", x => x.CoverId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_CoverId",
                table: "Games",
                column: "CoverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Covers_CoverId",
                table: "Games",
                column: "CoverId",
                principalTable: "Covers",
                principalColumn: "CoverId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Covers_CoverId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Covers");

            migrationBuilder.DropIndex(
                name: "IX_Games_CoverId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CoverId",
                table: "Games");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    LocalId = table.Column<int>(nullable: false),
                    CloudinaryId = table.Column<string>(nullable: true),
                    Height = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Width = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.LocalId);
                    table.ForeignKey(
                        name: "FK_Images_Games_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Games",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
