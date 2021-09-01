using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(BookshelfDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsCategoryUnique(string name)
        {
            var matchingCategories = _dbContext.Categories.Any(c => c.Name.Equals(name));
            return Task.FromResult(matchingCategories);
        }
    }
}
