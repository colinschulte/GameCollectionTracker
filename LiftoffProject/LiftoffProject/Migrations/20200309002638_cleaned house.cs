using Microsoft.EntityFrameworkCore.Migrations;

namespace LiftoffProject.Migrations
{
    public partial class cleanedhouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Covers_GameCoverid",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_TimeToBeat_TimeToBeatId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_ReleaseDates_Games_GameId",
                table: "ReleaseDates");

            migrationBuilder.DropTable(
                name: "Covers");

            migrationBuilder.DropTable(
                name: "DevGames");

            migrationBuilder.DropTable(
                name: "PubGames");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "TimeToBeat");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropIndex(
                name: "IX_Games_TimeToBeatId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReleaseDates",
                table: "ReleaseDates");

            migrationBuilder.DropColumn(
                name: "CloudinaryId",
                table: "Screenshots");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Screenshots");

            migrationBuilder.DropColumn(
                name: "FirstReleaseDate",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "PulseCount",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "TimeToBeatId",
                table: "Games");

            migrationBuilder.RenameTable(
                name: "ReleaseDates",
                newName: "ReleaseDate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Screenshots",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_ReleaseDates_GameId",
                table: "ReleaseDate",
                newName: "IX_ReleaseDate_GameId");

            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "Screenshots",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Screenshots",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "game",
                table: "Screenshots",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "image_id",
                table: "Screenshots",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReleaseDate",
                table: "ReleaseDate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Screenshots_GameCoverid",
                table: "Games",
                column: "GameCoverid",
                principalTable: "Screenshots",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReleaseDate_Games_GameId",
                table: "ReleaseDate",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Screenshots_GameCoverid",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_ReleaseDate_Games_GameId",
                table: "ReleaseDate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReleaseDate",
                table: "ReleaseDate");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Screenshots");

            migrationBuilder.DropColumn(
                name: "game",
                table: "Screenshots");

            migrationBuilder.DropColumn(
                name: "image_id",
                table: "Screenshots");

            migrationBuilder.RenameTable(
                name: "ReleaseDate",
                newName: "ReleaseDates");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Screenshots",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ReleaseDate_GameId",
                table: "ReleaseDates",
                newName: "IX_ReleaseDates_GameId");

            migrationBuilder.AlterColumn<string>(
                name: "Height",
                table: "Screenshots",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "CloudinaryId",
                table: "Screenshots",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Screenshots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "FirstReleaseDate",
                table: "Games",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "PulseCount",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimeToBeatId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReleaseDates",
                table: "ReleaseDates",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Covers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Width = table.Column<int>(type: "int", nullable: false),
                    game = table.Column<int>(type: "int", nullable: false),
                    image_id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Covers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Ratings",
                columns: table => new
                {
                    RatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingInt = table.Column<int>(type: "int", nullable: false),
                    Synopsis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingId);
                });

            migrationBuilder.CreateTable(
                name: "TimeToBeat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Completely = table.Column<int>(type: "int", nullable: false),
                    Hastly = table.Column<int>(type: "int", nullable: false),
                    Normally = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeToBeat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DevGames",
                columns: table => new
                {
                    DeveloperId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
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
                name: "PubGames",
                columns: table => new
                {
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Games_TimeToBeatId",
                table: "Games",
                column: "TimeToBeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Developers_GameId",
                table: "Developers",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_DevGames_GameId",
                table: "DevGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PubGames_GameId",
                table: "PubGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_GameId",
                table: "Publishers",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Covers_GameCoverid",
                table: "Games",
                column: "GameCoverid",
                principalTable: "Covers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_TimeToBeat_TimeToBeatId",
                table: "Games",
                column: "TimeToBeatId",
                principalTable: "TimeToBeat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReleaseDates_Games_GameId",
                table: "ReleaseDates",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
