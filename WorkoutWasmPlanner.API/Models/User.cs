using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace  WorkoutWasmPlanner.API.Models
{
    [PrimaryKey("UserID")]
    public class User
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "Username is required")]
        [StringLength(20, ErrorMessage = "Username cannot exceed 50 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Birthdate is required")]
        public DateTime Birthdate { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        public List<int> CompletedWorkoutIds { get; set; } = new List<int>();
        public int Height { get; set; }

        public int Weight { get; set; }


    }
}
