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
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        public BookService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
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

            var book = await JsonSerializer.DeserializeAsync<CategoryViewModel>(
                await _httpClient.GetStreamAsync(relativeUri),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            var mappedBook = _mapper.Map<BookDetailViewModel>(book);

            return mappedBook;
        }

        public Task<Guid> Create(BookDetailViewModel bookDetailViewModel)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task Update(BookDetailViewModel bookDetailViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
