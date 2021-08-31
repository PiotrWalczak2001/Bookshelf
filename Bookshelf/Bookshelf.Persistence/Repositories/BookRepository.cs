using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Persistence.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(BookshelfDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsBookUnique(string title, string author, DateTime releaseDate)
        {
            var matchingBooks = _dbContext.Books.Any(b => b.Title.Equals(title) && b.Author.Equals(author) && b.ReleaseDate.Date.Equals(releaseDate.Date));
            return Task.FromResult(matchingBooks);
        }
    }
}
