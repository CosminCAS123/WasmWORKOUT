using WorkoutWasmPlanner.API.Data;
using WorkoutWasmPlanner.API.Services;

namespace WorkoutWasmPlanner.API
{
    public static class ServicesExtensions
    {

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddDbContext<WorkoutPlannerDbContext>();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<PasswordService>();
        }
    }
}
