namespace OmanAirportsApp.API.Models.Authors
{
    public class AuthorReadOnlyDTO :BaseDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Bio { get; set; }
    }
}
