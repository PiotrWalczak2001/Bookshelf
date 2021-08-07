using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Domain.Entities;

namespace Bookshelf.Persistence.Repositories
{
    public class ShelfBookRepository : BaseRepository<ShelfBook>, IShelfBookRepository
    {
        public ShelfBookRepository(BookshelfDbContext dbContext) : base(dbContext)
        {
        }
    }
}
