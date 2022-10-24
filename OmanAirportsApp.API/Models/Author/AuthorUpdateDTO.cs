using System.ComponentModel.DataAnnotations;

namespace OmanAirportsApp.API.Models.Authors
{
    public class AuthorUpdateDTO:BaseDTO
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(250)]
        public string Bio { get; set; }
    }
}
