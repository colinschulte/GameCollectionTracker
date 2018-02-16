using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LiftoffProject.Migrations
{
    public partial class addedimagestodbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Games_GameGameLocalId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Games_GameLocalId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Games_GameLocalId1",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Games_GameLocalId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Games_LocalId",
                table: "Ratings");

            migrationBuilder.DropTable(
                name: "AlternativeName");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "Website");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_GameLocalId",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Image",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_GameLocalId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_GameLocalId1",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Games_GameGameLocalId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GameLocalId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "GameLocalId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "GameLocalId1",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "GameGameLocalId",
                table: "Games");

            migrationBuilder.RenameTable(
                name: "Image",
                newName: "Images");

            migrationBuilder.AlterColumn<int>(
                name: "LocalId",
                table: "Ratings",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "LocalId2",
                table: "Images",
                nullable: true);

            migrationBuilder.Sql("update Images set LocalId2 = LocalId");

            migrationBuilder.DropColumn(
                name: "LocalId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "LocalId2",
                table: "Images",
                newName: "LocalId");

            migrationBuilder.AlterColumn<int>(
                name: "LocalId",
                table: "Images",
                nullable: false,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "LocalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Games_LocalId",
                table: "Images",
                column: "LocalId",
                principalTable: "Games",
                principalColumn: "LocalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Games_LocalId",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "Image");

            migrationBuilder.AlterColumn<int>(
                name: "LocalId",
                table: "Ratings",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "GameLocalId",
                table: "Ratings",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocalId",
                table: "Image",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "GameLocalId",
                table: "Image",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameLocalId1",
                table: "Image",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameGameLocalId",
                table: "Games",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Image",
                table: "Image",
                column: "LocalId");

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
                name: "IX_Ratings_GameLocalId",
                table: "Ratings",
                column: "GameLocalId",
                unique: true,
                filter: "[GameLocalId] IS NOT NULL");

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
                name: "IX_Games_GameGameLocalId",
                table: "Games",
                column: "GameGameLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_AlternativeName_GameLocalId",
                table: "AlternativeName",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Games_GameLocalId",
                table: "Image",
                column: "GameLocalId",
                principalTable: "Games",
                principalColumn: "LocalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Games_GameLocalId1",
                table: "Image",
                column: "GameLocalId1",
                principalTable: "Games",
                principalColumn: "LocalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Games_GameLocalId",
                table: "Ratings",
                column: "GameLocalId",
                principalTable: "Games",
                principalColumn: "LocalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Games_LocalId",
                table: "Ratings",
                column: "LocalId",
                principalTable: "Games",
                principalColumn: "LocalId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
