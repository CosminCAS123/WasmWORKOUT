using Microsoft.EntityFrameworkCore;
using WorkoutWasmPlanner.API.Models;

namespace WorkoutWasmPlanner.API.Data
{
    public class WorkoutPlannerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

   
        public DbSet<Workout> UserAddedWorkouts { get; set; } // user added workouts


        public WorkoutPlannerDbContext(DbContextOptions<WorkoutPlannerDbContext> options) : base(options)
        {
        }


    }
}
