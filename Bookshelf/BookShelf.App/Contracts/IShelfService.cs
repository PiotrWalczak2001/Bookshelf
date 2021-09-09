using BookShelf.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.App.Contracts
{
    public interface IShelfService
    {
        Task<List<ShelfListViewModel>> GetAll();
        Task<ShelfDetailViewModel> GetById(Guid Id);
        Task<Guid> Create(ShelfDetailViewModel shelfDetailViewModel);
        Task Update(ShelfDetailViewModel shelfDetailViewModel);
        Task Delete(Guid Id);
        Task<Guid> AddBookToShelf(ShelfBookViewModel shelfBookViewModel);
        Task RemoveBookFromShelf(Guid shelfBookId);
    }
}
