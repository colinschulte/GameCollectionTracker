using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LiftoffProject.Migrations
{
    public partial class tweakedcolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collection");

            migrationBuilder.DropTable(
                name: "Franchise");

            migrationBuilder.DropTable(
                name: "GameMode");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Keyword");

            migrationBuilder.DropTable(
                name: "PlayerPerspective");

            migrationBuilder.DropTable(
                name: "ReleaseDate");

            migrationBuilder.DropTable(
                name: "Theme");

            migrationBuilder.AlterColumn<long>(
                name: "FirstReleaseDate",
                table: "Games",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<long>(
                name: "Collection",
                table: "Games",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Franchise",
                table: "Games",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Collection",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Franchise",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "FirstReleaseDate",
                table: "Games",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.CreateTable(
                name: "Collection",
                columns: table => new
                {
                    LocalId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<long>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collection", x => x.LocalId);
                    table.ForeignKey(
                        name: "FK_Collection_Games_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Games",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Franchise",
                columns: table => new
                {
                    LocalId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<long>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchise", x => x.LocalId);
                    table.ForeignKey(
                        name: "FK_Franchise_Games_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Games",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameMode",
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
                    table.PrimaryKey("PK_GameMode", x => x.LocalId);
                    table.ForeignKey(
                        name: "FK_GameMode_Games_GameLocalId",
                        column: x => x.GameLocalId,
                        principalTable: "Games",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
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
                    table.PrimaryKey("PK_Genre", x => x.LocalId);
                    table.ForeignKey(
                        name: "FK_Genre_Games_GameLocalId",
                        column: x => x.GameLocalId,
                        principalTable: "Games",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Keyword",
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
                    table.PrimaryKey("PK_Keyword", x => x.LocalId);
                    table.ForeignKey(
                        name: "FK_Keyword_Games_GameLocalId",
                        column: x => x.GameLocalId,
                        principalTable: "Games",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerPerspective",
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
                    table.PrimaryKey("PK_PlayerPerspective", x => x.LocalId);
                    table.ForeignKey(
                        name: "FK_PlayerPerspective_Games_GameLocalId",
                        column: x => x.GameLocalId,
                        principalTable: "Games",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReleaseDate",
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
                    table.PrimaryKey("PK_ReleaseDate", x => x.LocalId);
                    table.ForeignKey(
                        name: "FK_ReleaseDate_Games_GameLocalId",
                        column: x => x.GameLocalId,
                        principalTable: "Games",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Theme",
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
                    table.PrimaryKey("PK_Theme", x => x.LocalId);
                    table.ForeignKey(
                        name: "FK_Theme_Games_GameLocalId",
                        column: x => x.GameLocalId,
                        principalTable: "Games",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameMode_GameLocalId",
                table: "GameMode",
                column: "GameLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_GameLocalId",
                table: "Genre",
                column: "GameLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Keyword_GameLocalId",
                table: "Keyword",
                column: "GameLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPerspective_GameLocalId",
                table: "PlayerPerspective",
                column: "GameLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseDate_GameLocalId",
                table: "ReleaseDate",
                column: "GameLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Theme_GameLocalId",
                table: "Theme",
                column: "GameLocalId");
        }
    }
}
