using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutWasmPlanner.Shared.Models
{
    [PrimaryKey("WorkoutID")]
    public class Workout
    {
        public int WorkoutID { get; set; }

        
        public int UserID { get; set; }

        public string WorkoutName { get; set; }

        public string Description { get; set; }

        public List<Exercise> Exercises { get; set; }

        public int CaloriesBurned { get; set; }

        public string TotalTime { get; set; } // in minutes

    }
}
