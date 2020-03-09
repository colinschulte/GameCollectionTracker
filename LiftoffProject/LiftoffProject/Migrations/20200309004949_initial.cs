using Microsoft.EntityFrameworkCore.Migrations;

namespace LiftoffProject.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_id = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    game = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.id);
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
                    GameCoverid = table.Column<int>(nullable: true),
                    Cover = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Image_GameCoverid",
                        column: x => x.GameCoverid,
                        principalTable: "Image",
                        principalColumn: "id",
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
                name: "ReleaseDate",
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
                    table.PrimaryKey("PK_ReleaseDate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReleaseDate_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
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
                name: "IX_Games_GameCoverid",
                table: "Games",
                column: "GameCoverid");

            migrationBuilder.CreateIndex(
                name: "IX_GenreGameIds_GameId",
                table: "GenreGameIds",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_GameId",
                table: "Genres",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseDate_GameId",
                table: "ReleaseDate",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreGameIds");

            migrationBuilder.DropTable(
                name: "ReleaseDate");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Image");
        }
    }
}
