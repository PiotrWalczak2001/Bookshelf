using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Persistence.Repositories
{
    public class ShelfRepository : BaseRepository<Shelf>, IShelfRepository
    {
        public ShelfRepository(BookshelfDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ShelfBook>> GetAllBooksFromShelf(Guid ShelfId)
        {
            var booksFromShelf = _dbContext.ShelfBooks.Where(sb => sb.ShelfId == ShelfId);

            return booksFromShelf;
        }
    }
}
