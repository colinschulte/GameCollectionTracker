using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LiftoffProject.Migrations
{
    public partial class changeddeleterestrictions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevGames_Developers_DeveloperId",
                table: "DevGames");

            migrationBuilder.DropForeignKey(
                name: "FK_DevGames_Games_GameId",
                table: "DevGames");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Covers_CoverId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreGameIds_Games_GameId",
                table: "GenreGameIds");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreGameIds_Genres_GenreId",
                table: "GenreGameIds");

            migrationBuilder.DropForeignKey(
                name: "FK_PubGames_Games_GameId",
                table: "PubGames");

            migrationBuilder.DropForeignKey(
                name: "FK_PubGames_Publishers_PublisherId",
                table: "PubGames");

            migrationBuilder.AddForeignKey(
                name: "FK_DevGames_Developers_DeveloperId",
                table: "DevGames",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DevGames_Games_GameId",
                table: "DevGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Covers_CoverId",
                table: "Games",
                column: "CoverId",
                principalTable: "Covers",
                principalColumn: "CoverId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreGameIds_Games_GameId",
                table: "GenreGameIds",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreGameIds_Genres_GenreId",
                table: "GenreGameIds",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PubGames_Games_GameId",
                table: "PubGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PubGames_Publishers_PublisherId",
                table: "PubGames",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevGames_Developers_DeveloperId",
                table: "DevGames");

            migrationBuilder.DropForeignKey(
                name: "FK_DevGames_Games_GameId",
                table: "DevGames");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Covers_CoverId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreGameIds_Games_GameId",
                table: "GenreGameIds");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreGameIds_Genres_GenreId",
                table: "GenreGameIds");

            migrationBuilder.DropForeignKey(
                name: "FK_PubGames_Games_GameId",
                table: "PubGames");

            migrationBuilder.DropForeignKey(
                name: "FK_PubGames_Publishers_PublisherId",
                table: "PubGames");

            migrationBuilder.AddForeignKey(
                name: "FK_DevGames_Developers_DeveloperId",
                table: "DevGames",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DevGames_Games_GameId",
                table: "DevGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Covers_CoverId",
                table: "Games",
                column: "CoverId",
                principalTable: "Covers",
                principalColumn: "CoverId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreGameIds_Games_GameId",
                table: "GenreGameIds",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreGameIds_Genres_GenreId",
                table: "GenreGameIds",
                column: "GenreId",
                principalTable: "Genres",
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
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
