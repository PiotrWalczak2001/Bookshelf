using AutoMapper;
using BookShelf.App.Contracts;
using BookShelf.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookShelf.App.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        public CategoryService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        public async Task<List<CategoryViewModel>> GetAll()
        {
            string relativeUri = $"{_httpClient.BaseAddress}/all";

            var categories = await JsonSerializer.DeserializeAsync<ICollection<CategoryViewModel>>(
                await _httpClient.GetStreamAsync(relativeUri),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            var mappedCategories = _mapper.Map<List<CategoryViewModel>>(categories);
            return mappedCategories;
        }

        public async Task<CategoryViewModel> GetById(Guid Id)
        {
            string relativeUri = $"{_httpClient.BaseAddress}/details/{Id}";

            var category = await JsonSerializer.DeserializeAsync<CategoryViewModel>(
                await _httpClient.GetStreamAsync(relativeUri),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            var mappedCategory = _mapper.Map<CategoryViewModel>(category);

            return mappedCategory;
        }


        public Task<Guid> Create(CategoryViewModel categoryViewModel)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
