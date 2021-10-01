using Bookshelf.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookshelf.Application.Contracts.Persistence
{
    public interface IShelfRepository : IAsyncRepository<Shelf>
    {
        Task<IEnumerable<Shelf>> GetAllUserShelves(Guid UserId);
        Task<IEnumerable<ShelfBook>> GetAllBooksFromShelf(Guid ShelfId);
        Task RemoveAllShelfBooks(Guid ShelfId);
        Task AddBookToShelf(ShelfBook ShelfBook);
        Task RemoveBookFromShelf(Guid ShelfBookId);
        Task<bool> IsShelfUnique(string name, Guid userId);
        Task<bool> IsShelfBookUnique(Guid shelfBookId, Guid shelfId);
    }
}
