using System.ComponentModel.DataAnnotations;

namespace FiveMeals.WebAPI.Model.User
{
    public class CreateUserDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
