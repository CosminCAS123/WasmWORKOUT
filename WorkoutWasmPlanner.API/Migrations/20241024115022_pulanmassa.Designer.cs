﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkoutWasmPlanner.API.Data;

#nullable disable

namespace WorkoutWasmPlanner.API.Migrations
{
    [DbContext(typeof(WorkoutPlannerDbContext))]
    [Migration("20241024115022_pulanmassa")]
    partial class pulanmassa
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("WorkoutWasmPlanner.Shared.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("TEXT");

                    b.Property<string>("CompletedWorkoutIds")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int>("Weight")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WorkoutWasmPlanner.Shared.Models.Workout", b =>
                {
                    b.Property<int>("WorkoutID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("WorkoutName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("WorkoutID");

                    b.ToTable("UserAddedWorkouts");
                });

            modelBuilder.Entity("WorkoutWasmPlanner.Shared.Models.Workout", b =>
                {
                    b.OwnsMany("WorkoutWasmPlanner.Shared.Models.Exercise", "Exercises", b1 =>
                        {
                            b1.Property<int>("WorkoutID")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<string>("ExerciseName")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<int>("Reps")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Sets")
                                .HasColumnType("INTEGER");

                            b1.Property<decimal>("Weight")
                                .HasColumnType("TEXT");

                            b1.HasKey("WorkoutID", "Id");

                            b1.ToTable("Exercise");

                            b1.WithOwner()
                                .HasForeignKey("WorkoutID");
                        });

                    b.Navigation("Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}
