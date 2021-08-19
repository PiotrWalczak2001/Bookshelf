using Bookshelf.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookshelf.App.Contracts
{
    public interface ICategoryDataService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllCategories();
        Task<CategoryViewModel> GetCategoryDetails(Guid categoryId);
        Task<Guid> AddCategory(CategoryViewModel newCategory);
        Task DeleteCategory(Guid categoryId);
    }
}
