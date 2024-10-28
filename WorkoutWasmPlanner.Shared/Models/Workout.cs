using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutWasmPlanner.Shared.Models
{
    [PrimaryKey("WorkoutID")]
    public class Workout
    {
        public int WorkoutID { get; set; }
        public string WorkoutName { get; set; }
        public string Description { get; set; }

        public bool IsDefault { get; set; }  // True if it's a default workout
            
        public int? UserID { get; set; }  // Only populated for user-created workouts

        // List of exercises
        public List<Exercise> Exercises { get; set; }
    }
}
