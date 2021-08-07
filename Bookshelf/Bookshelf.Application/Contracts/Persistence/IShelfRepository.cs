using Bookshelf.Domain.Entities;

namespace Bookshelf.Application.Contracts.Persistence
{
    public interface IShelfRepository : IAsyncRepository<Shelf>
    {
    }
}
