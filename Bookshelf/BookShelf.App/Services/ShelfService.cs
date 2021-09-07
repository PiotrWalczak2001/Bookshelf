using AutoMapper;
using Blazored.LocalStorage;
using BookShelf.App.Auth;
using BookShelf.App.Contracts;
using BookShelf.App.ViewModels;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookShelf.App.Services
{
    public class ShelfService : DataService, IShelfService
    {
        private readonly IMapper _mapper;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public ShelfService(HttpClient httpClient, IMapper mapper, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider) : base(httpClient, localStorage)
        {
            _mapper = mapper;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<List<ShelfListViewModel>> GetAll()
        {
            await AddBearerToken();

            var userId = await ((CustomAuthenticationStateProvider)_authenticationStateProvider).GetUserId();

            string relativeUri = $"{_httpClient.BaseAddress}/all/{userId}";

            var allShelves = await JsonSerializer.DeserializeAsync<ICollection<ShelfListViewModel>>(
                await _httpClient.GetStreamAsync(relativeUri),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            var mappedShelves = _mapper.Map<List<ShelfListViewModel>>(allShelves);
            return mappedShelves;
        }

        public async Task<ShelfDetailViewModel> GetById(Guid Id)
        {
            await AddBearerToken();

            string relativeUri = $"{_httpClient.BaseAddress}/{Id}";

            var shelf = await JsonSerializer.DeserializeAsync<ShelfDetailViewModel>(
                await _httpClient.GetStreamAsync(relativeUri),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            var mappedShelf = _mapper.Map<ShelfDetailViewModel>(shelf);

            return mappedShelf;
        }

        public async Task<Guid> Create(ShelfDetailViewModel shelfDetailViewModel)
        {
            await AddBearerToken();
            string relativeUri = $"{_httpClient.BaseAddress}";

            var uid = await ((CustomAuthenticationStateProvider)_authenticationStateProvider).GetUserId();
            shelfDetailViewModel.UserId = Guid.Parse(uid);

            var shelfJson = new StringContent(JsonSerializer.Serialize(shelfDetailViewModel), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(relativeUri, shelfJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Guid>(await response.Content.ReadAsStreamAsync());
            }
            return Guid.Empty;
        }

        public async Task Delete(Guid Id)
        {
            await AddBearerToken();
            string relativeUri = $"{_httpClient.BaseAddress}/{Id}";
            await _httpClient.DeleteAsync(relativeUri);
        }


        public async Task Update(ShelfDetailViewModel shelfDetailViewModel)
        {
            await AddBearerToken();
            string relativeUri = $"{_httpClient.BaseAddress}";
            var shelfJson = new StringContent(JsonSerializer.Serialize(shelfDetailViewModel), Encoding.UTF8, "application/json");
            await _httpClient.PutAsync(relativeUri, shelfJson);
        }
    }
}
