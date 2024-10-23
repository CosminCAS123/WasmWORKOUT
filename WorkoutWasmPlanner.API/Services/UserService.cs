using Microsoft.EntityFrameworkCore;
using WorkoutWasmPlanner.API.Data;
using WorkoutWasmPlanner.Shared.Models;

namespace WorkoutWasmPlanner.API.Services
{
    public class UserService : IUserService
    {
        private WorkoutPlannerDbContext dbContext;
        private PasswordService passwordService;
        public UserService(WorkoutPlannerDbContext dbcontext , PasswordService pass_service)
        {
            this.dbContext = dbcontext;
            this.passwordService = pass_service;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await this.dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User?> GetByIDAsync(int id)
        {
           var user = await this.dbContext.Users.FirstOrDefaultAsync(x => x.UserID == id);
            return user;
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
           return await this.dbContext.Users.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<Result> RegisterUserAsync(User user)
        {
            //the username and email should not already be existent in the database.

            var check_for_email_task = GetByEmailAsync(user.Email);
            var check_for_username = GetByUsernameAsync(user.Username);
            var finished_task = await Task.WhenAny(check_for_username, check_for_email_task);

            if (finished_task.Result is not null)
            {
                var error_message = finished_task == check_for_email_task ? "This email already exists." : "This username already exists";

                return new Result
                {
                    Success = false,
                    Error = error_message
                };
            }
            // its not existent in the database
            //add to db

            await this.dbContext.Users.AddAsync(user);

            await this.dbContext.SaveChangesAsync();

            return new Result { Success = true };
             

        }

        public async Task<Result> ValidateLoginAsync(User user)
        {
            //get the user by username
            User? check_user = await GetByUsernameAsync(user.Username); 
            if (check_user is null)
            {
                return new Result
                {
                    Error = "This username does not exist.",
                    Success = false
                };
            }
            //the username exists
            //check if its password matches the entered password
            bool matches_password = await this.passwordService.VerifyPasswordAsync(user.Password, check_user.Password);
            if (!matches_password)
            {
                return new Result
                {
                    Error = "The password is incorrect",
                    Success = false
                };
            }
            return new Result
            {
                Success = true
            };

        }
    }
}
