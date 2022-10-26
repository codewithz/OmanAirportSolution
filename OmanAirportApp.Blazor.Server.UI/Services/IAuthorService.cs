using OmanAirportApp.Blazor.Server.UI.Services.Base;

namespace OmanAirportApp.Blazor.Server.UI.Services
{
    public interface IAuthorService
    {
        Task<Response<List<AuthorReadOnlyDTO>>> Get();
        Task<Response<int>> Create(AuthorCreateDTO author);
    }
}
