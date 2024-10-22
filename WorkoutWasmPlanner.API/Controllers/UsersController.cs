using Microsoft.AspNetCore.Mvc;
using WorkoutWasmPlanner.API.Models;
using WorkoutWasmPlanner.API.Services;

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
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid user data.");
            }

            var result = await userService.RegisterUserAsync(user);

            if (!result.Success)
            {
                return BadRequest(result.Error);
            }

            return Ok("User registered successfully.");
        }






    }
}
