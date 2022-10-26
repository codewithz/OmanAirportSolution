﻿using AutoMapper;
using Blazored.LocalStorage;
using OmanAirportApp.Blazor.Server.UI.Services.Base;

namespace OmanAirportApp.Blazor.Server.UI.Services
{
    public class AuthorService : BaseHttpService, IAuthorService
    {
        Client client;
        ILocalStorageService localStorage;
        IMapper mapper;
        public AuthorService(Client client, ILocalStorageService localStorage,IMapper mapper) : base(client, localStorage)
        {
            this.client = client;
            this.localStorage = localStorage;
            this.mapper = mapper;
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

        public async Task<Response<int>> Edit(int id, AuthorUpdateDTO author)
        {
            Response<int> response = new();

            try
            {
                await GetBearerToken();
                await client.AuthorsPUTAsync(id, author);
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

        public async Task<Response<AuthorDetailsDTO>> Get(int id)
        {
            Response<AuthorDetailsDTO> response;

            try
            {
                await GetBearerToken();
                var data = await client.AuthorsGETAsync(id);
                response = new Response<AuthorDetailsDTO>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<AuthorDetailsDTO>(exception);
            }

            return response;
        }


        public async Task<Response<AuthorUpdateDTO>> GetForUpdate(int id)
        {
            Response<AuthorUpdateDTO> response;

            try
            {
                await GetBearerToken();
                var data = await client.AuthorsGETAsync(id);
                response = new Response<AuthorUpdateDTO>
                {
                    Data = mapper.Map<AuthorUpdateDTO>(data),
                    Success = true
                };
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<AuthorUpdateDTO>(exception);
            }

            return response;
        }
    }
}
