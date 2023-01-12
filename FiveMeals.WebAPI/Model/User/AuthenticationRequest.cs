using System.ComponentModel.DataAnnotations;

namespace FiveMeals.WebAPI.Model.User
{
    public class AuthenticationRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
