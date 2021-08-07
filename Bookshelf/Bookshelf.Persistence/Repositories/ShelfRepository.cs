using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Domain.Entities;

namespace Bookshelf.Persistence.Repositories
{
    public class ShelfRepository : BaseRepository<Shelf>, IShelfRepository
    {
        public ShelfRepository(BookshelfDbContext dbContext) : base(dbContext)
        {
        }

    }
}
