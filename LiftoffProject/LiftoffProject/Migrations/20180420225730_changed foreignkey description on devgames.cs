using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LiftoffProject.Migrations
{
    public partial class changedforeignkeydescriptionondevgames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevGames_Developers_CompanyId",
                table: "DevGames");

            migrationBuilder.DropIndex(
                name: "IX_DevGames_CompanyId",
                table: "DevGames");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "DevGames");

            migrationBuilder.AddForeignKey(
                name: "FK_DevGames_Developers_DeveloperId",
                table: "DevGames",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevGames_Developers_DeveloperId",
                table: "DevGames");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "DevGames",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DevGames_CompanyId",
                table: "DevGames",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_DevGames_Developers_CompanyId",
                table: "DevGames",
                column: "CompanyId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
