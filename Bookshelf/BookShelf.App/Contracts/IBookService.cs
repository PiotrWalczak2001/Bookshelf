using BookShelf.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShelf.App.Contracts
{
    public interface IBookService
    {
        Task<List<BookListViewModel>> GetAll();
        Task<BookDetailViewModel> GetById(Guid Id);
        Task<Guid> Create(BookDetailViewModel bookDetailViewModel);
        Task Update(BookDetailViewModel bookDetailViewModel);
        Task Delete(Guid Id);
    }
}
