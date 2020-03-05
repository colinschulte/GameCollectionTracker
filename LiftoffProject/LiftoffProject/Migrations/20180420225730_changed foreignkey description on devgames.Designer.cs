﻿// <auto-generated />
using LiftoffProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace LiftoffProject.Migrations
{
    [DbContext(typeof(GameDbContext))]
    [Migration("20180420225730_changed foreignkey description on devgames")]
    partial class changedforeignkeydescriptionondevgames
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LiftoffProject.Models.Cover", b =>
                {
                    b.Property<int>("CoverId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CloudinaryId");

                    b.Property<string>("Height");

                    b.Property<string>("Url");

                    b.Property<int>("Width");

                    b.HasKey("CoverId");

                    b.ToTable("Covers");
                });

            modelBuilder.Entity("LiftoffProject.Models.Developer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GameId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("LiftoffProject.Models.DevGame", b =>
                {
                    b.Property<int>("DeveloperId");

                    b.Property<int>("GameId");

                    b.HasKey("DeveloperId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("DevGames");
                });

            modelBuilder.Entity("LiftoffProject.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("AggregatedRating");

                    b.Property<int>("AggregatedRatingCount");

                    b.Property<int>("Category");

                    b.Property<long>("Collection");

                    b.Property<int>("CoverId");

                    b.Property<long>("CreatedAt");

                    b.Property<long>("FirstReleaseDate");

                    b.Property<long>("Franchise");

                    b.Property<int>("Hypes");

                    b.Property<string>("Name");

                    b.Property<float>("Popularity");

                    b.Property<int>("PulseCount");

                    b.Property<float>("Rating");

                    b.Property<int>("RatingCount");

                    b.Property<string>("Slug");

                    b.Property<int>("Status");

                    b.Property<string>("Storyline");

                    b.Property<string>("Summary");

                    b.Property<int?>("TimeToBeatId");

                    b.Property<float>("TotalRating");

                    b.Property<int>("TotalRatingCount");

                    b.Property<long>("UpdatedAt");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("CoverId");

                    b.HasIndex("TimeToBeatId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("LiftoffProject.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CreatedAt");

                    b.Property<int?>("GameId");

                    b.Property<string>("Name");

                    b.Property<string>("Slug");

                    b.Property<long>("UpdatedAt");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("LiftoffProject.Models.GenreGameId", b =>
                {
                    b.Property<int>("GenreId");

                    b.Property<int>("GameId");

                    b.HasKey("GenreId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("GenreGameIds");
                });

            modelBuilder.Entity("LiftoffProject.Models.PubGame", b =>
                {
                    b.Property<int>("PublisherId");

                    b.Property<int>("GameId");

                    b.HasKey("PublisherId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("PubGames");
                });

            modelBuilder.Entity("LiftoffProject.Models.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GameId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("LiftoffProject.Models.Rating", b =>
                {
                    b.Property<int>("RatingId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RatingInt");

                    b.Property<string>("Synopsis");

                    b.HasKey("RatingId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("LiftoffProject.Models.ReleaseDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Category");

                    b.Property<int>("CreatedAt");

                    b.Property<int>("Date");

                    b.Property<int?>("GameId");

                    b.Property<string>("Human");

                    b.Property<int>("Month");

                    b.Property<string>("Name");

                    b.Property<int>("Platform");

                    b.Property<int>("Region");

                    b.Property<int>("UpdatedAt");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("ReleaseDates");
                });

            modelBuilder.Entity("LiftoffProject.Models.TimeToBeat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Completely");

                    b.Property<int>("Hastly");

                    b.Property<int>("Normally");

                    b.HasKey("Id");

                    b.ToTable("TimeToBeat");
                });

            modelBuilder.Entity("LiftoffProject.Models.Developer", b =>
                {
                    b.HasOne("LiftoffProject.Models.Game")
                        .WithMany("Developers")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("LiftoffProject.Models.DevGame", b =>
                {
                    b.HasOne("LiftoffProject.Models.Developer", "Developer")
                        .WithMany("DevGames")
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("LiftoffProject.Models.Game", "Game")
                        .WithMany("DevGames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("LiftoffProject.Models.Game", b =>
                {
                    b.HasOne("LiftoffProject.Models.Cover", "Cover")
                        .WithMany()
                        .HasForeignKey("CoverId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("LiftoffProject.Models.TimeToBeat", "TimeToBeat")
                        .WithMany()
                        .HasForeignKey("TimeToBeatId");
                });

            modelBuilder.Entity("LiftoffProject.Models.Genre", b =>
                {
                    b.HasOne("LiftoffProject.Models.Game")
                        .WithMany("Genres")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("LiftoffProject.Models.GenreGameId", b =>
                {
                    b.HasOne("LiftoffProject.Models.Game", "Game")
                        .WithMany("GenreGameIds")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("LiftoffProject.Models.Genre", "Genre")
                        .WithMany("GenreGameIds")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("LiftoffProject.Models.PubGame", b =>
                {
                    b.HasOne("LiftoffProject.Models.Game", "Game")
                        .WithMany("PubGames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("LiftoffProject.Models.Publisher", "Publisher")
                        .WithMany("PubGames")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("LiftoffProject.Models.Publisher", b =>
                {
                    b.HasOne("LiftoffProject.Models.Game")
                        .WithMany("Publishers")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("LiftoffProject.Models.ReleaseDate", b =>
                {
                    b.HasOne("LiftoffProject.Models.Game")
                        .WithMany("ReleaseDates")
                        .HasForeignKey("GameId");
                });
#pragma warning restore 612, 618
        }
    }
}
