using Bookshelf.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bookshelf.App.Services
{
    public class BookDataService : IBookDataService
    {
        private readonly HttpClient _httpClient;

        public BookDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<IEnumerable<BooksListViewModel>> GetAllBooks()
        {
            // return await _httpClient.GetFromJsonAsync<IEnumerable<BooksListViewModel>>($"book/all");   
            return await JsonSerializer.DeserializeAsync<IEnumerable<BooksListViewModel>>
                     (await _httpClient.GetStreamAsync($"book/all"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<BookDetailsViewModel> GetBookDetails(Guid bookId)
        {
            return await JsonSerializer.DeserializeAsync<BookDetailsViewModel>
                (await _httpClient.GetStreamAsync($"book/details/{bookId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }   



        public async Task<Guid> AddBook(BookDetailsViewModel newBook)
        {
            var bookJson = new StringContent(JsonSerializer.Serialize(newBook), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("book", bookJson);

            if(response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Guid>(await response.Content.ReadAsStreamAsync());
            }
            return Guid.Empty;
        }

        public async Task UpdateBook(BookDetailsViewModel bookToUpdate)
        {
            var bookJson = new StringContent(JsonSerializer.Serialize(bookToUpdate), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("book", bookJson);
        }

        public async Task DeleteBook(Guid bookId)
        {
            await _httpClient.DeleteAsync($"book/{bookId}");
        }


    }
}
