using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiftoffProject.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    AggregatedRating = table.Column<float>(nullable: false),
                    AggregatedRatingCount = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    CollectionId = table.Column<int>(nullable: false),
                    CoverId = table.Column<int>(nullable: false),
                    FirstReleaseDate = table.Column<DateTimeOffset>(nullable: false),
                    Follows = table.Column<int>(nullable: false),
                    Franchise = table.Column<long>(nullable: false),
                    Hypes = table.Column<int>(nullable: false),
                    ParentGameId = table.Column<int>(nullable: false),
                    Popularity = table.Column<double>(nullable: false),
                    PulseCount = table.Column<int>(nullable: false),
                    Rating = table.Column<double>(nullable: false),
                    RatingCount = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Storyline = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    TimeToBeatId = table.Column<int>(nullable: false),
                    TotalRating = table.Column<float>(nullable: false),
                    TotalRatingCount = table.Column<int>(nullable: false),
                    VersionParentId = table.Column<int>(nullable: false),
                    VersionTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    GameId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genres_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageId = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Game = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.id);
                    table.ForeignKey(
                        name: "FK_Image_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReleaseDates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Category = table.Column<int>(nullable: false),
                    Date = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: false),
                    Human = table.Column<string>(nullable: true),
                    Month = table.Column<int>(nullable: false),
                    Platform = table.Column<int>(nullable: false),
                    Region = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleaseDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReleaseDates_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreGameIds_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreGameIds_GameId",
                table: "GenreGameIds",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_GameId",
                table: "Genres",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_GameId",
                table: "Image",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseDates_GameId",
                table: "ReleaseDates",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreGameIds");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "ReleaseDates");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
