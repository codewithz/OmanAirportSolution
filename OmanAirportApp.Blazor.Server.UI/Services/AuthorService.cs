using Blazored.LocalStorage;
using OmanAirportApp.Blazor.Server.UI.Services.Base;

namespace OmanAirportApp.Blazor.Server.UI.Services
{
    public class AuthorService : BaseHttpService, IAuthorService
    {
        Client client;
        ILocalStorageService localStorage;
        public AuthorService(Client client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            this.client = client;
            this.localStorage = localStorage;
        }

        public async Task<Response<int>> Create(AuthorCreateDTO author)
        {
            Response<int> response = new();

            try
            {
                await GetBearerToken();
                await client.AuthorsPOSTAsync(author);
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<int>(exception);
            }

            return response;
        }

        public async Task<Response<List<AuthorReadOnlyDTO>>> Get()
        {
            Response<List<AuthorReadOnlyDTO>> response;

            try
            {
                await GetBearerToken();
                var data = await client.AuthorsAllAsync();
                response = new Response<List<AuthorReadOnlyDTO>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<List<AuthorReadOnlyDTO>>(exception);
            }

            return response;
        }
    }
}
