using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;
using WorkoutWasmPlanner.Shared.Models;
namespace WorkoutWasmPlanner.API.Data
{
    public class WorkoutPlannerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Workout> Workouts { get; set; } 

        public WorkoutPlannerDbContext(DbContextOptions<WorkoutPlannerDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var exerciseListComparer = new ValueComparer<List<Exercise>>(
                (c1, c2) => JsonSerializer.Serialize(c1, (JsonSerializerOptions)null) == JsonSerializer.Serialize(c2, (JsonSerializerOptions)null),
                c => c == null ? 0 : JsonSerializer.Serialize(c, (JsonSerializerOptions)null).GetHashCode(),
                c => JsonSerializer.Deserialize<List<Exercise>>(JsonSerializer.Serialize(c, (JsonSerializerOptions)null), (JsonSerializerOptions)null)
            );

            // Configure Exercises property with value converter and value comparer
            modelBuilder.Entity<Workout>()
                .Property(w => w.Exercises)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<Exercise>>(v, (JsonSerializerOptions)null))
                .Metadata
                .SetValueComparer(exerciseListComparer);

            base.OnModelCreating(modelBuilder);
        }
    }





}
