using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LiftoffProject.Migrations
{
    public partial class createdgenrestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    LocalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<long>(nullable: false),
                    GameLocalId = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<long>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.LocalId);
                    table.ForeignKey(
                        name: "FK_Genres_Games_GameLocalId",
                        column: x => x.GameLocalId,
                        principalTable: "Games",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReleaseDates",
                columns: table => new
                {
                    LocalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<int>(nullable: false),
                    Date = table.Column<int>(nullable: false),
                    GameLocalId = table.Column<int>(nullable: true),
                    Human = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Platform = table.Column<int>(nullable: false),
                    Region = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleaseDates", x => x.LocalId);
                    table.ForeignKey(
                        name: "FK_ReleaseDates_Games_GameLocalId",
                        column: x => x.GameLocalId,
                        principalTable: "Games",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GenreGameIds",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreGameIds", x => new { x.GenreId, x.GameId });
                    table.ForeignKey(
                        name: "FK_GenreGameIds_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreGameIds_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreGameIds_GameId",
                table: "GenreGameIds",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_GameLocalId",
                table: "Genres",
                column: "GameLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseDates_GameLocalId",
                table: "ReleaseDates",
                column: "GameLocalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreGameIds");

            migrationBuilder.DropTable(
                name: "ReleaseDates");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
