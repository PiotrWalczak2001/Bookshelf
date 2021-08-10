using AutoMapper;
using Bookshelf.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
            return await _httpClient.GetFromJsonAsync<IEnumerable<BooksListViewModel>>($"book/all");   
        }

        public Task<BookDetailsViewModel> GetBookDetails(Guid bookId)
        {
            throw new NotImplementedException();
        }



        public Task<BookDetailsViewModel> AddBook(BookDetailsViewModel newBook)
        {
            throw new NotImplementedException();
        }
        public Task UpdateBook(BookDetailsViewModel bookToUpdate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBook(Guid bookId)
        {
            throw new NotImplementedException();
        }


    }
}
