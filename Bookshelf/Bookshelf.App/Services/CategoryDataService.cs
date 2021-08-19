using Bookshelf.App.Contracts;
using Bookshelf.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bookshelf.App.Services
{
    public class CategoryDataService : ICategoryDataService
    {
        private readonly HttpClient _httpClient;
        public CategoryDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategories()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<CategoryViewModel>>
                     (await _httpClient.GetStreamAsync($"category/all"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<CategoryViewModel> GetCategoryDetails(Guid categoryId)
        {
            return await JsonSerializer.DeserializeAsync<CategoryViewModel>
                (await _httpClient.GetStreamAsync($"category/details/{categoryId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Guid> AddCategory(CategoryViewModel newCategory)
        {
            var categoryJson = new StringContent(JsonSerializer.Serialize(newCategory), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("category", categoryJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Guid>(await response.Content.ReadAsStreamAsync());
            }
            return Guid.Empty;
        }

        public async Task DeleteCategory(Guid categoryId)
        {
            await _httpClient.DeleteAsync($"category/{categoryId}");
        }

       
    }
}
