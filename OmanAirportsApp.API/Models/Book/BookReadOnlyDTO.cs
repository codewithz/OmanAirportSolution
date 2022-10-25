namespace OmanAirportsApp.API.Models.Book
{
    public class BookReadOnlyDTO :BaseDTO
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
    }
}
