using Microsoft.AspNetCore.Mvc;
using WorkoutWasmPlanner.API.Services;
using WorkoutWasmPlanner.Shared.Models;
namespace WorkoutWasmPlanner.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService userService;

        public UsersController(IUserService user_service)
        {
            this.userService = user_service;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
          

            var result = await userService.RegisterUserAsync(user);

            if (!result.Success)
            {
                return Conflict(result.Error);
            }

            return CreatedAtAction(nameof(Register), new { id = user.UserID }, "User registered successfully.");

        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel user)
        {
         

            var result = await userService.ValidateLoginAsync(user);

            if (!result.Success)
            {
                return Unauthorized(result.Error);
            }

            return Ok("Login successfull.");
        }



    }
}
