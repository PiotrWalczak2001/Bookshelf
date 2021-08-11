using Bookshelf.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookshelf.Application.Contracts.Persistence
{
    public interface IShelfRepository : IAsyncRepository<Shelf>
    {
        Task<IEnumerable<ShelfBook>> GetAllBooksFromShelf(Guid ShelfId);

    }
}
