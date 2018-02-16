using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LiftoffProject.Migrations
{
    public partial class addedratingstodbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Games_GameLocalId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Games_LocalId",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rating",
                table: "Rating");

            migrationBuilder.RenameTable(
                name: "Rating",
                newName: "Ratings");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_GameLocalId",
                table: "Ratings",
                newName: "IX_Ratings_GameLocalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "LocalId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Games_GameLocalId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Games_LocalId",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.RenameTable(
                name: "Ratings",
                newName: "Rating");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_GameLocalId",
                table: "Rating",
                newName: "IX_Rating_GameLocalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rating",
                table: "Rating",
                column: "LocalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Games_GameLocalId",
                table: "Rating",
                column: "GameLocalId",
                principalTable: "Games",
                principalColumn: "LocalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Games_LocalId",
                table: "Rating",
                column: "LocalId",
                principalTable: "Games",
                principalColumn: "LocalId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
