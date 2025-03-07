﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using QuizWhizAPI.Database;

#nullable disable

namespace QuizWhizAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250305224813_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("QuizWhizAPI.Models.BuzzerEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GameSessionId")
                        .HasColumnType("integer");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.Property<int>("TeamId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TeamId");

                    b.HasIndex("GameSessionId", "Timestamp");

                    b.ToTable("BuzzerEntries");
                });

            modelBuilder.Entity("QuizWhizAPI.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("GameBoardId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GameBoardId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("QuizWhizAPI.Models.CategoryQuestion", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("PointValue")
                        .HasColumnType("integer");

                    b.HasKey("CategoryId", "QuestionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("CategoryQuestions");
                });

            modelBuilder.Entity("QuizWhizAPI.Models.GameBoard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.PrimitiveCollection<List<int>>("PointValues")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.HasKey("Id");

                    b.ToTable("GameBoards");
                });

            modelBuilder.Entity("QuizWhizAPI.Models.GameResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GameSessionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GameSessionId");

                    b.ToTable("GameResults");
                });

            modelBuilder.Entity("QuizWhizAPI.Models.GameSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("GameBoardId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("GameBoardId");

                    b.ToTable("GameSessions");
                });

            modelBuilder.Entity("QuizWhizAPI.Models.Hint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Hints");
                });

            modelBuilder.Entity("QuizWhizAPI.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TeamId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("QuizWhizAPI.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<int>("ReadingTimeSeconds")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VideoUrl")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("QuizWhizAPI.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<int?>("GameResultId")
                        .HasColumnType("integer");

                    b.Property<int?>("GameSessionId")
                        .HasColumnType("integer");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Score")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GameResultId");

                    b.HasIndex("GameSessionId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("QuizWhizAPI.Models.ThemeSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BackgroundImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PrimaryColor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ThemeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ThemeSettings");
                });

            modelBuilder.Entity("QuizWhizAPI.Models.BuzzerEntry", b =>
                {
                    b.HasOne("QuizWhizAPI.Models.GameSession", "GameSession")
                        .WithMany("BuzzerEntries")
                        .HasForeignKey("GameSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizWhizAPI.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizWhizAPI.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameSession");

                    b.Navigation("Player");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("QuizWhizAPI.Models.Category", b =>
                {
                    b.HasOne("QuizWhizAPI.Models.GameBoard", null)
                        .WithMany("Categories")
                        .HasForeignKey("GameBoardId");
                });

            modelBuilder.Entity("QuizWhizAPI.Models.CategoryQuestion", b =>
                {
                    b.HasOne("QuizWhizAPI.Models.Category", "Category")
                        .WithMany("CategoryQuestions")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizWhizAPI.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("QuizWhizAPI.Models.GameResult", b =>
                {
                    b.HasOne("QuizWhizAPI.Models.GameSession", "GameSession")
                        .WithMany()
                        .HasForeignKey("GameSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameSession");
                });

            modelBuilder.Entity("QuizWhizAPI.Models.GameSession", b =>
                {
                    b.HasOne("QuizWhizAPI.Models.GameBoard", "GameBoard")
                        .WithMany()
                        .HasForeignKey("GameBoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameBoard");
                });

            modelBuilder.Entity("QuizWhizAPI.Models.Hint", b =>
                {
                    b.HasOne("QuizWhizAPI.Models.Question", "Question")
                        .WithMany("Hints")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("QuizWhizAPI.Models.Player", b =>
                {
                    b.HasOne("QuizWhizAPI.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("QuizWhizAPI.Models.Team", b =>
                {
                    b.HasOne("QuizWhizAPI.Models.GameResult", null)
                        .WithMany("FinalTeamRankings")
                        .HasForeignKey("GameResultId");

                    b.HasOne("QuizWhizAPI.Models.GameSession", null)
                        .WithMany("Teams")
                        .HasForeignKey("GameSessionId");
                });

            modelBuilder.Entity("QuizWhizAPI.Models.Category", b =>
                {
                    b.Navigation("CategoryQuestions");
                });

            modelBuilder.Entity("QuizWhizAPI.Models.GameBoard", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("QuizWhizAPI.Models.GameResult", b =>
                {
                    b.Navigation("FinalTeamRankings");
                });

            modelBuilder.Entity("QuizWhizAPI.Models.GameSession", b =>
                {
                    b.Navigation("BuzzerEntries");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("QuizWhizAPI.Models.Question", b =>
                {
                    b.Navigation("Hints");
                });

            modelBuilder.Entity("QuizWhizAPI.Models.Team", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
