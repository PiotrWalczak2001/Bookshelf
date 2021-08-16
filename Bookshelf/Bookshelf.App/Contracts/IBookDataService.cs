using Bookshelf.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookshelf.App.Services
{
    public interface IBookDataService
    {
        Task<IEnumerable<BooksListViewModel>> GetAllBooks();
        Task<BookDetailsViewModel> GetBookDetails(Guid bookId);
        Task<Guid> AddBook(BookDetailsViewModel newBook);
        Task UpdateBook(BookDetailsViewModel bookToUpdate);
        Task DeleteBook(Guid bookId);
    }
}
