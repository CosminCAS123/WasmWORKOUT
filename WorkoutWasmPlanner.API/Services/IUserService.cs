using WorkoutWasmPlanner.Shared.Models;

namespace WorkoutWasmPlanner.API.Services
{
    public interface IUserService
    {
        Task<Result> RegisterUserAsync(User user);
        Task<Result> ValidateLoginAsync(LoginModel user);
        Task<User?> GetByIDAsync(int id);

        Task<User?> GetByUsernameAsync(string username);

        Task<User?> GetByEmailAsync(string email);


    }
}
