using AutoMapper;
using OmanAirportApp.Blazor.Server.UI.Services.Base;

namespace OmanAirportApp.Blazor.Server.UI.Configuration
{
    public class MapperConfig :Profile
    {
        public MapperConfig()
        {
            CreateMap<AuthorReadOnlyDTO, AuthorUpdateDTO>().ReverseMap();
        }
    }
}
