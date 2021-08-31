using Bookshelf.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Bookshelf.Application.Contracts.Persistence
{
    public interface IBookRepository : IAsyncRepository<Book>
    {
        Task<bool> IsBookUnique(string title, string author, DateTime releaseDate);
    }
}
