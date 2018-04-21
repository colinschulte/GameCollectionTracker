using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LiftoffProject.Migrations
{
    public partial class removedsuperfluousGameIdfromcompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developers_Games_GameId",
                table: "Developers");

            migrationBuilder.DropForeignKey(
                name: "FK_DevGame_Developers_DeveloperId",
                table: "DevGame");

            migrationBuilder.DropForeignKey(
                name: "FK_DevGame_Games_GameId",
                table: "DevGame");

            migrationBuilder.DropForeignKey(
                name: "FK_PubGame_Games_GameId",
                table: "PubGame");

            migrationBuilder.DropForeignKey(
                name: "FK_PubGame_Publishers_PublisherId",
                table: "PubGame");

            migrationBuilder.DropForeignKey(
                name: "FK_Publishers_Games_GameId",
                table: "Publishers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PubGame",
                table: "PubGame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DevGame",
                table: "DevGame");

            migrationBuilder.RenameTable(
                name: "PubGame",
                newName: "PubGames");

            migrationBuilder.RenameTable(
                name: "DevGame",
                newName: "DevGames");

            migrationBuilder.RenameIndex(
                name: "IX_PubGame_GameId",
                table: "PubGames",
                newName: "IX_PubGames_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_DevGame_GameId",
                table: "DevGames",
                newName: "IX_DevGames_GameId");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Publishers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "DevGames",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Developers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PubGames",
                table: "PubGames",
                columns: new[] { "PublisherId", "GameId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DevGames",
                table: "DevGames",
                columns: new[] { "DeveloperId", "GameId" });

            migrationBuilder.CreateIndex(
                name: "IX_DevGames_CompanyId",
                table: "DevGames",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Developers_Games_GameId",
                table: "Developers",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DevGames_Developers_CompanyId",
                table: "DevGames",
                column: "CompanyId",
                principalTable: "Developers",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DevGames_Games_GameId",
                table: "DevGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PubGames_Games_GameId",
                table: "PubGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PubGames_Publishers_PublisherId",
                table: "PubGames",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Publishers_Games_GameId",
                table: "Publishers",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developers_Games_GameId",
                table: "Developers");

            migrationBuilder.DropForeignKey(
                name: "FK_DevGames_Developers_CompanyId",
                table: "DevGames");

            migrationBuilder.DropForeignKey(
                name: "FK_DevGames_Games_GameId",
                table: "DevGames");

            migrationBuilder.DropForeignKey(
                name: "FK_PubGames_Games_GameId",
                table: "PubGames");

            migrationBuilder.DropForeignKey(
                name: "FK_PubGames_Publishers_PublisherId",
                table: "PubGames");

            migrationBuilder.DropForeignKey(
                name: "FK_Publishers_Games_GameId",
                table: "Publishers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PubGames",
                table: "PubGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DevGames",
                table: "DevGames");

            migrationBuilder.DropIndex(
                name: "IX_DevGames_CompanyId",
                table: "DevGames");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "DevGames");

            migrationBuilder.RenameTable(
                name: "PubGames",
                newName: "PubGame");

            migrationBuilder.RenameTable(
                name: "DevGames",
                newName: "DevGame");

            migrationBuilder.RenameIndex(
                name: "IX_PubGames_GameId",
                table: "PubGame",
                newName: "IX_PubGame_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_DevGames_GameId",
                table: "DevGame",
                newName: "IX_DevGame_GameId");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Publishers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Developers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PubGame",
                table: "PubGame",
                columns: new[] { "PublisherId", "GameId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DevGame",
                table: "DevGame",
                columns: new[] { "DeveloperId", "GameId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Developers_Games_GameId",
                table: "Developers",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DevGame_Developers_DeveloperId",
                table: "DevGame",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DevGame_Games_GameId",
                table: "DevGame",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PubGame_Games_GameId",
                table: "PubGame",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PubGame_Publishers_PublisherId",
                table: "PubGame",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Publishers_Games_GameId",
                table: "Publishers",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
