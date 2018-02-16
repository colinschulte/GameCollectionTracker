using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LiftoffProject.Migrations
{
    public partial class AddLocalId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Games",
                newName: "LocalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LocalId",
                table: "Games",
                newName: "ID");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Games",
                nullable: true);
        }
    }
}
