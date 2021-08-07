using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Domain.Entities;

namespace Bookshelf.Persistence.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(BookshelfDbContext dbContext) : base(dbContext)
        {
        }

    }
}
