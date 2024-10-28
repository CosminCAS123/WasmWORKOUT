using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutWasmPlanner.API.Migrations
{
    /// <inheritdoc />
    public partial class Json : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAddedWorkouts",
                table: "UserAddedWorkouts");

            migrationBuilder.RenameTable(
                name: "UserAddedWorkouts",
                newName: "Workouts");

            migrationBuilder.AddColumn<string>(
                name: "Exercises",
                table: "Workouts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workouts",
                table: "Workouts",
                column: "WorkoutID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Workouts",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Exercises",
                table: "Workouts");

            migrationBuilder.RenameTable(
                name: "Workouts",
                newName: "UserAddedWorkouts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAddedWorkouts",
                table: "UserAddedWorkouts",
                column: "WorkoutID");

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    WorkoutID = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    ExerciseName = table.Column<string>(type: "TEXT", nullable: false),
                    Reps = table.Column<int>(type: "INTEGER", nullable: false),
                    Sets = table.Column<int>(type: "INTEGER", nullable: false),
                    Weight = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => new { x.WorkoutID, x.Id });
                    table.ForeignKey(
                        name: "FK_Exercise_UserAddedWorkouts_WorkoutID",
                        column: x => x.WorkoutID,
                        principalTable: "UserAddedWorkouts",
                        principalColumn: "WorkoutID",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
