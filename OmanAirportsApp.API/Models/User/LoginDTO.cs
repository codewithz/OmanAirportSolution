using System.ComponentModel.DataAnnotations;

namespace OmanAirportsApp.API.Models.User
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
