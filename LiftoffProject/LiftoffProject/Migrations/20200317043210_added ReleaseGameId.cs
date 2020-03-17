using Microsoft.EntityFrameworkCore.Migrations;

namespace LiftoffProject.Migrations
{
    public partial class addedReleaseGameId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameId1",
                table: "Image",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReleaseGameIds",
                columns: table => new
                {
                    ReleaseDateId = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleaseGameIds", x => new { x.ReleaseDateId, x.GameId });
                    table.ForeignKey(
                        name: "FK_ReleaseGameIds_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReleaseGameIds_ReleaseDates_ReleaseDateId",
                        column: x => x.ReleaseDateId,
                        principalTable: "ReleaseDates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_GameId1",
                table: "Image",
                column: "GameId1");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseGameIds_GameId",
                table: "ReleaseGameIds",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Games_GameId1",
                table: "Image",
                column: "GameId1",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Games_GameId1",
                table: "Image");

            migrationBuilder.DropTable(
                name: "ReleaseGameIds");

            migrationBuilder.DropIndex(
                name: "IX_Image_GameId1",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "GameId1",
                table: "Image");
        }
    }
}
