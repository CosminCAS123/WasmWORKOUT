using Microsoft.EntityFrameworkCore;
using WorkoutWasmPlanner.API.Data;
using WorkoutWasmPlanner.API.Services;

namespace WorkoutWasmPlanner.API
{
    public static class ServicesExtensions
    {

        public static void ConfigureServices(this IServiceCollection services)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var dbPath = Path.Combine(path, "workoutplanner.db");

            // Register the DbContext and configure SQLite with the specified path
            services.AddDbContext<WorkoutPlannerDbContext>(options =>
                options.UseSqlite($"Data Source={dbPath}"));

            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<PasswordService>();
        }
    }
}
