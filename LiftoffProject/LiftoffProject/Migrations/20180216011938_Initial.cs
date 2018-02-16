using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LiftoffProject.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    LocalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AggregatedRating = table.Column<float>(nullable: false),
                    AggregatedRatingCount = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    Collection = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    FirstReleaseDate = table.Column<long>(nullable: false),
                    Franchise = table.Column<long>(nullable: false),
                    Hypes = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Popularity = table.Column<float>(nullable: false),
                    PulseCount = table.Column<int>(nullable: false),
                    Rating = table.Column<float>(nullable: false),
                    RatingCount = table.Column<int>(nullable: false),
                    Slug = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Storyline = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    TotalRating = table.Column<float>(nullable: false),
                    TotalRatingCount = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<long>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.LocalId);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    LocalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RatingInt = table.Column<int>(nullable: false),
                    Synopsis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.LocalId);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    LocalId = table.Column<int>(nullable: false),
                    CloudinaryId = table.Column<string>(nullable: true),
                    Height = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Width = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.LocalId);
                    table.ForeignKey(
                        name: "FK_Images_Games_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Games",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeToBeat",
                columns: table => new
                {
                    LocalId = table.Column<int>(nullable: false),
                    Completely = table.Column<int>(nullable: false),
                    Hastly = table.Column<int>(nullable: false),
                    Normally = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeToBeat", x => x.LocalId);
                    table.ForeignKey(
                        name: "FK_TimeToBeat_Games_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Games",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "TimeToBeat");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
