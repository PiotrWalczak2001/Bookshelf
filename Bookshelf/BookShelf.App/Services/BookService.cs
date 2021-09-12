using AutoMapper;
using Blazored.LocalStorage;
using Bookshelf.Shared;
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
    public class BookService : DataService, IBookService
    {
        private readonly IMapper _mapper;
        public BookService(HttpClient httpClient, IMapper mapper, ILocalStorageService localStorage) : base (httpClient, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<BookListViewModel>> GetAll()
        {
            string relativeUri = $"{_httpClient.BaseAddress}/all";

            var allBooks = await JsonSerializer.DeserializeAsync<ICollection<BookListViewModel>>(
                await _httpClient.GetStreamAsync(relativeUri),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            var mappedBooks = _mapper.Map<List<BookListViewModel>>(allBooks);
            return mappedBooks;
        }

        public async Task<BookDetailViewModel> GetById(Guid Id)
        {
            string relativeUri = $"{_httpClient.BaseAddress}/details/{Id}";

            var book = await JsonSerializer.DeserializeAsync<BookDetailViewModel>(
                await _httpClient.GetStreamAsync(relativeUri),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            var mappedBook = _mapper.Map<BookDetailViewModel>(book);

            return mappedBook;
        }

        public async Task<Guid> Create(BookDetailViewModel bookDetailViewModel)
        {
            await AddBearerToken();

            string relativeUri = $"{_httpClient.BaseAddress}";

            var mappedBook = _mapper.Map<BookDetailViewModel>(bookDetailViewModel);
            var bookJson = new StringContent(JsonSerializer.Serialize(mappedBook), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(relativeUri, bookJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Guid>(await response.Content.ReadAsStreamAsync());
            }
            return Guid.Empty;
        }


        public async Task Update(BookDetailViewModel bookDetailViewModel)
        {
            await AddBearerToken();
            string relativeUri = $"{_httpClient.BaseAddress}";

            var mappedBook = _mapper.Map<BookDetailViewModel>(bookDetailViewModel);
            var bookJson = new StringContent(JsonSerializer.Serialize(mappedBook), Encoding.UTF8, "application/json");
            await _httpClient.PutAsync(relativeUri, bookJson);
        }

        public async Task Delete(Guid Id)
        {
            await AddBearerToken();
            string relativeUri = $"{_httpClient.BaseAddress}/{Id}";
            await _httpClient.DeleteAsync(relativeUri);
        }
    }
}
