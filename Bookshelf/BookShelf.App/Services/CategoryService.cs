using AutoMapper;
using Blazored.LocalStorage;
using BookShelf.App.Contracts;
using BookShelf.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookShelf.App.Services
{
    public class CategoryService : DataService, ICategoryService
    {
        private readonly IMapper _mapper;
        public CategoryService(HttpClient httpClient, IMapper mapper, ILocalStorageService localStorage) : base(httpClient, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<CategoryViewModel>> GetAll()
        {
            await AddBearerToken();
            string relativeUri = $"{_httpClient.BaseAddress}/all";

            var categories = await JsonSerializer.DeserializeAsync<ICollection<CategoryViewModel>>(
                await _httpClient.GetStreamAsync(relativeUri),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            var mappedCategories = _mapper.Map<List<CategoryViewModel>>(categories);
            return mappedCategories;
        }

        public async Task<CategoryViewModel> GetById(Guid Id)
        {
            await AddBearerToken();
            string relativeUri = $"{_httpClient.BaseAddress}/details/{Id}";

            var category = await JsonSerializer.DeserializeAsync<CategoryViewModel>(
                await _httpClient.GetStreamAsync(relativeUri),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            var mappedCategory = _mapper.Map<CategoryViewModel>(category);

            return mappedCategory;
        }


        public async Task<Guid> Create(CategoryViewModel categoryViewModel)
        {
            await AddBearerToken();

            string relativeUri = $"{_httpClient.BaseAddress}";
            var categoryJson = new StringContent(JsonSerializer.Serialize(categoryViewModel), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(relativeUri, categoryJson);

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
    }
}
