using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(BookshelfDbContext dbContext) : base(dbContext)
        {
        }
    }
}
