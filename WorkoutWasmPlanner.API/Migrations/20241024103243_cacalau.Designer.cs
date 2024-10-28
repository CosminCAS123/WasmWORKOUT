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
    [Migration("20241024103243_cacalau")]
    partial class cacalau
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("WorkoutWasmPlanner.Shared.Models.Exercise", b =>
                {
                    b.Property<int>("ExerciseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ExerciseName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Reps")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Sets")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Weight")
                        .HasColumnType("TEXT");

                    b.Property<int?>("WorkoutID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ExerciseID");

                    b.HasIndex("WorkoutID");

                    b.ToTable("Exercise");
                });

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

                    b.Property<int>("CaloriesBurned")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TotalTime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("WorkoutName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("WorkoutID");

                    b.ToTable("UserAddedWorkouts");
                });

            modelBuilder.Entity("WorkoutWasmPlanner.Shared.Models.Exercise", b =>
                {
                    b.HasOne("WorkoutWasmPlanner.Shared.Models.Workout", null)
                        .WithMany("Exercises")
                        .HasForeignKey("WorkoutID");
                });

            modelBuilder.Entity("WorkoutWasmPlanner.Shared.Models.Workout", b =>
                {
                    b.Navigation("Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}
