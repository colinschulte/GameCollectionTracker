using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LiftoffProject.Migrations
{
    public partial class changedcompanyidtoid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Publishers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Developers",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Publishers",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Developers",
                newName: "CompanyId");
        }
    }
}
