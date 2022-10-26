using AutoMapper;
using OmanAirportsApp.API.Data;
using OmanAirportsApp.API.Models.Author;
using OmanAirportsApp.API.Models.Authors;
using OmanAirportsApp.API.Models.Book;
using OmanAirportsApp.API.Models.User;

namespace OmanAirportsApp.API.Configurations
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            CreateMap<AuthorCreateDTO, Author>().ReverseMap();
            CreateMap<AuthorUpdateDTO, Author>().ReverseMap();
            CreateMap<AuthorReadOnlyDTO, Author>().ReverseMap();
            CreateMap<AuthorDetailsDTO, Author>().ReverseMap();

            CreateMap<BookCreateDTO, Book>().ReverseMap();
            CreateMap<BookUpdateDTO, Book>().ReverseMap();
            CreateMap<Book, BookReadOnlyDTO>()
                .ForMember(q => q.AuthorName,
                d => d.MapFrom(map => $"{map.Author.FirstName} {map.Author.LastName}"))
            .ReverseMap();

            CreateMap<Book, BookDetailsDTO>()
                .ForMember(q => q.AuthorName,
                d => d.MapFrom(map => $"{map.Author.FirstName} {map.Author.LastName}"))
            .ReverseMap();

            CreateMap<ApiUser, UserDTO>().ReverseMap();
        }
    }
}
