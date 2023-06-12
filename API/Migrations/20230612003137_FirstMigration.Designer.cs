﻿// <auto-generated />
using System;
using API.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20230612003137_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Models.Exercise", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Repetitions")
                        .HasColumnType("int");

                    b.Property<int>("Series")
                        .HasColumnType("int");

                    b.Property<long?>("TrainingId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TrainingId");

                    b.HasIndex("UserId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("API.Models.ExerciseRecord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Repetitions")
                        .HasColumnType("int");

                    b.Property<int>("Series")
                        .HasColumnType("int");

                    b.Property<long>("TrainingId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TrainingId");

                    b.ToTable("ExerciseRecords");
                });

            modelBuilder.Entity("API.Models.Record", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("TrainingRecordId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TrainingRecordId");

                    b.HasIndex("UserId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("API.Models.Training", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DayOfWeek")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Training");
                });

            modelBuilder.Entity("API.Models.TrainingRecord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("TrainingRecords");
                });

            modelBuilder.Entity("API.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Models.Exercise", b =>
                {
                    b.HasOne("API.Models.Training", "training")
                        .WithMany("Exercices")
                        .HasForeignKey("TrainingId");

                    b.HasOne("API.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");

                    b.Navigation("training");
                });

            modelBuilder.Entity("API.Models.ExerciseRecord", b =>
                {
                    b.HasOne("API.Models.TrainingRecord", "training")
                        .WithMany("Exercices")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("training");
                });

            modelBuilder.Entity("API.Models.Record", b =>
                {
                    b.HasOne("API.Models.TrainingRecord", "TrainingRecord")
                        .WithMany()
                        .HasForeignKey("TrainingRecordId");

                    b.HasOne("API.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("TrainingRecord");

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.Models.Training", b =>
                {
                    b.HasOne("API.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.Models.Training", b =>
                {
                    b.Navigation("Exercices");
                });

            modelBuilder.Entity("API.Models.TrainingRecord", b =>
                {
                    b.Navigation("Exercices");
                });
#pragma warning restore 612, 618
        }
    }
}
