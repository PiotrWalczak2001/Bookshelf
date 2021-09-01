using Bookshelf.Domain.Entities;
using System.Threading.Tasks;

namespace Bookshelf.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<bool> IsCategoryUnique(string name);
    }
}
