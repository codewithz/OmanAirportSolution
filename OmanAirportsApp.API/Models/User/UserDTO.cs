using System.ComponentModel.DataAnnotations;

namespace OmanAirportsApp.API.Models.User
{
    public class UserDTO: LoginDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
