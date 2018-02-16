using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LiftoffProject.Migrations
{
    public partial class fleshedoutgamecolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Games",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Games",
                newName: "Id");

            migrationBuilder.AddColumn<float>(
                name: "AggregatedRating",
                table: "Games",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "AggregatedRatingCount",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedAt",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FirstReleaseDate",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GameGameLocalId",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Hypes",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Popularity",
                table: "Games",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "PulseCount",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Rating",
                table: "Games",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "RatingCount",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Storyline",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "TotalRating",
                table: "Games",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "TotalRatingCount",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedAt",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Games",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AlternativeName",
                columns: table => new
                {
                    LocalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: true),
                    GameLocalId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlternativeName", x => x.LocalId);
                    table.ForeignKey(
                        name: "FK_AlternativeName_Games_GameLocalId",
                        column: x => x.GameLocalId,
                        principalTable: "Games",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Collection",
                columns: table => new
                {
                    LocalId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<int>(nullable: false),
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
                    CreatedAt = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<int>(nullable: false),
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
                    CreatedAt = table.Column<int>(nullable: false),
                    GameLocalId = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<int>(nullable: false),
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
                    CreatedAt = table.Column<int>(nullable: false),
                    GameLocalId = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<int>(nullable: false),
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
                name: "Image",
                columns: table => new
                {
                    LocalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CloudinaryId = table.Column<string>(nullable: true),
                    GameLocalId = table.Column<int>(nullable: true),
                    GameLocalId1 = table.Column<int>(nullable: true),
                    Height = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Width = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.LocalId);
                    table.ForeignKey(
                        name: "FK_Image_Games_GameLocalId",
                        column: x => x.GameLocalId,
                        principalTable: "Games",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Image_Games_GameLocalId1",
                        column: x => x.GameLocalId1,
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
                    CreatedAt = table.Column<int>(nullable: false),
                    GameLocalId = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<int>(nullable: false),
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
                    CreatedAt = table.Column<int>(nullable: false),
                    GameLocalId = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<int>(nullable: false),
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
                name: "Rating",
                columns: table => new
                {
                    LocalId = table.Column<int>(nullable: false),
                    GameLocalId = table.Column<int>(nullable: true),
                    RatingInt = table.Column<int>(nullable: false),
                    Synopsis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.LocalId);
                    table.ForeignKey(
                        name: "FK_Rating_Games_GameLocalId",
                        column: x => x.GameLocalId,
                        principalTable: "Games",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rating_Games_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Games",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Cascade);
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
                    CreatedAt = table.Column<int>(nullable: false),
                    GameLocalId = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<int>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "TimeToBeat",
                columns: table => new
                {
                    LocalId = table.Column<int>(nullable: false),
                    Completely = table.Column<int>(nullable: false),
                    Hastly = table.Column<int>(nullable: false),
                    Normally = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeToBeat", x => x.LocalId);
                    table.ForeignKey(
                        name: "FK_TimeToBeat_Games_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Games",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    LocalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GameLocalId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    VideoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.LocalId);
                    table.ForeignKey(
                        name: "FK_Video_Games_GameLocalId",
                        column: x => x.GameLocalId,
                        principalTable: "Games",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Website",
                columns: table => new
                {
                    LocalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<int>(nullable: false),
                    GameLocalId = table.Column<int>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Website", x => x.LocalId);
                    table.ForeignKey(
                        name: "FK_Website_Games_GameLocalId",
                        column: x => x.GameLocalId,
                        principalTable: "Games",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameGameLocalId",
                table: "Games",
                column: "GameGameLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_AlternativeName_GameLocalId",
                table: "AlternativeName",
                column: "GameLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_GameMode_GameLocalId",
                table: "GameMode",
                column: "GameLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_GameLocalId",
                table: "Genre",
                column: "GameLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_GameLocalId",
                table: "Image",
                column: "GameLocalId",
                unique: true,
                filter: "[GameLocalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Image_GameLocalId1",
                table: "Image",
                column: "GameLocalId1");

            migrationBuilder.CreateIndex(
                name: "IX_Keyword_GameLocalId",
                table: "Keyword",
                column: "GameLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPerspective_GameLocalId",
                table: "PlayerPerspective",
                column: "GameLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_GameLocalId",
                table: "Rating",
                column: "GameLocalId",
                unique: true,
                filter: "[GameLocalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseDate_GameLocalId",
                table: "ReleaseDate",
                column: "GameLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Theme_GameLocalId",
                table: "Theme",
                column: "GameLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Video_GameLocalId",
                table: "Video",
                column: "GameLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Website_GameLocalId",
                table: "Website",
                column: "GameLocalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Games_GameGameLocalId",
                table: "Games",
                column: "GameGameLocalId",
                principalTable: "Games",
                principalColumn: "LocalId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Games_GameGameLocalId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "AlternativeName");

            migrationBuilder.DropTable(
                name: "Collection");

            migrationBuilder.DropTable(
                name: "Franchise");

            migrationBuilder.DropTable(
                name: "GameMode");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Keyword");

            migrationBuilder.DropTable(
                name: "PlayerPerspective");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "ReleaseDate");

            migrationBuilder.DropTable(
                name: "Theme");

            migrationBuilder.DropTable(
                name: "TimeToBeat");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "Website");

            migrationBuilder.DropIndex(
                name: "IX_Games_GameGameLocalId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "AggregatedRating",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "AggregatedRatingCount",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "FirstReleaseDate",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GameGameLocalId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Hypes",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Popularity",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "PulseCount",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "RatingCount",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Storyline",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "TotalRating",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "TotalRatingCount",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Games",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Games",
                newName: "id");
        }
    }
}
