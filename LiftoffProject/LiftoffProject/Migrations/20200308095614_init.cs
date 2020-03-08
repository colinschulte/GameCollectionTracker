using Microsoft.EntityFrameworkCore.Migrations;

namespace LiftoffProject.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Covers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_id = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    game = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Covers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingInt = table.Column<int>(nullable: false),
                    Synopsis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingId);
                });

            migrationBuilder.CreateTable(
                name: "Screenshots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true),
                    CloudinaryId = table.Column<string>(nullable: true),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<string>(nullable: true),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screenshots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeToBeat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hastly = table.Column<int>(nullable: false),
                    Normally = table.Column<int>(nullable: false),
                    Completely = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeToBeat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    VideoId = table.Column<string>(nullable: true),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<long>(nullable: false),
                    UpdatedAt = table.Column<long>(nullable: false),
                    Slug = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    Storyline = table.Column<string>(nullable: true),
                    Collection = table.Column<long>(nullable: false),
                    Franchise = table.Column<long>(nullable: false),
                    Hypes = table.Column<int>(nullable: false),
                    Rating = table.Column<float>(nullable: false),
                    Popularity = table.Column<float>(nullable: false),
                    AggregatedRating = table.Column<float>(nullable: false),
                    AggregatedRatingCount = table.Column<int>(nullable: false),
                    TotalRating = table.Column<float>(nullable: false),
                    TotalRatingCount = table.Column<int>(nullable: false),
                    RatingCount = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    TimeToBeatId = table.Column<int>(nullable: true),
                    FirstReleaseDate = table.Column<long>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    PulseCount = table.Column<int>(nullable: false),
                    GameCoverid = table.Column<int>(nullable: true),
                    Cover = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Covers_GameCoverid",
                        column: x => x.GameCoverid,
                        principalTable: "Covers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_TimeToBeat_TimeToBeatId",
                        column: x => x.TimeToBeatId,
                        principalTable: "TimeToBeat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    GameId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Developers_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<long>(nullable: false),
                    UpdatedAt = table.Column<long>(nullable: false),
                    Slug = table.Column<string>(nullable: true),
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
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    GameId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publishers_Games_GameId",
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
                    Name = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    Platform = table.Column<int>(nullable: false),
                    Human = table.Column<string>(nullable: true),
                    Date = table.Column<int>(nullable: false),
                    Region = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleaseDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReleaseDates_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DevGames",
                columns: table => new
                {
                    DeveloperId = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevGames", x => new { x.DeveloperId, x.GameId });
                    table.ForeignKey(
                        name: "FK_DevGames_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DevGames_Games_GameId",
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

            migrationBuilder.CreateTable(
                name: "PubGames",
                columns: table => new
                {
                    PublisherId = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PubGames", x => new { x.PublisherId, x.GameId });
                    table.ForeignKey(
                        name: "FK_PubGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PubGames_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Developers_GameId",
                table: "Developers",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_DevGames_GameId",
                table: "DevGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameCoverid",
                table: "Games",
                column: "GameCoverid");

            migrationBuilder.CreateIndex(
                name: "IX_Games_TimeToBeatId",
                table: "Games",
                column: "TimeToBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreGameIds_GameId",
                table: "GenreGameIds",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_GameId",
                table: "Genres",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PubGames_GameId",
                table: "PubGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_GameId",
                table: "Publishers",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseDates_GameId",
                table: "ReleaseDates",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevGames");

            migrationBuilder.DropTable(
                name: "GenreGameIds");

            migrationBuilder.DropTable(
                name: "PubGames");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "ReleaseDates");

            migrationBuilder.DropTable(
                name: "Screenshots");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Covers");

            migrationBuilder.DropTable(
                name: "TimeToBeat");
        }
    }
}
