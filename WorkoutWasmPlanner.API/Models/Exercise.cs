using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutWasmPlanner.API.Models
{
 
    public class Exercise
    {
      
        public string ExerciseName { get; set;}

        public int Reps { get; set; }

        public int Sets { get; set; }

        public decimal Weight { get; set; }

        

    }
}
