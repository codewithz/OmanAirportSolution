using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using OmanAirportApp.Blazor.Server.UI.Provider;
using OmanAirportApp.Blazor.Server.UI.Services.Base;

namespace OmanAirportApp.Blazor.Server.UI.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly Client httpClient;
        private readonly ILocalStorageService localStorage;
        private readonly AuthenticationStateProvider stateProvider;

        public AuthenticationService(Client httpClient,ILocalStorageService localStorage
            ,AuthenticationStateProvider stateProvider)
        {
            this.httpClient = httpClient;
            this.localStorage = localStorage;
            this.stateProvider = stateProvider;
        }

        public async Task<bool> AuthenticateAsync(LoginDTO loginModel)
        {
            var response = await httpClient.LoginAsync(loginModel);

            //Store Token
            await localStorage.SetItemAsync("accessToken", response.Token);


            //Update Auth State of App 
            await ((ApiAuthenticationStateProvider)stateProvider).LoggedIn();

            return true;
        }

        public async Task Logout()
        {
            await ((ApiAuthenticationStateProvider)stateProvider).LoggedOut();
        }
    }
}
