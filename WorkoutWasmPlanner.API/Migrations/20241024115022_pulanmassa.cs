using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutWasmPlanner.API.Migrations
{
    /// <inheritdoc />
    public partial class pulanmassa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_WorkoutID",
                table: "Exercise");

            migrationBuilder.RenameColumn(
                name: "ExerciseID",
                table: "Exercise",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "WorkoutID",
                table: "Exercise",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Exercise",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise",
                columns: new[] { "WorkoutID", "Id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Exercise",
                newName: "ExerciseID");

            migrationBuilder.AlterColumn<int>(
                name: "WorkoutID",
                table: "Exercise",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseID",
                table: "Exercise",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise",
                column: "ExerciseID");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_WorkoutID",
                table: "Exercise",
                column: "WorkoutID");
        }
    }
}
