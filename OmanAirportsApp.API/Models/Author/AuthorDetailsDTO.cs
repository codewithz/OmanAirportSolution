using OmanAirportsApp.API.Models.Authors;
using OmanAirportsApp.API.Models.Book;

namespace OmanAirportsApp.API.Models.Author
{
    public class AuthorDetailsDTO :AuthorReadOnlyDTO
    {
        public List<BookReadOnlyDTO> Books { get; set; }
    }
}
