using BookShelf.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShelf.App.Contracts
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAll();
        Task<CategoryViewModel> GetById(Guid Id);
        Task<Guid> Create(CategoryViewModel categoryViewModel);
        Task Delete(Guid Id);
    }
}
