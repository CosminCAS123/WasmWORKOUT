using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorkoutWasmPlanner.Shared.Enums;

namespace WorkoutWasmPlanner.Shared.Models
{
    
    public class Exercise
    {
       
        public ExerciseName Name { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }
        public decimal Weight { get; set; }
    }
}   
