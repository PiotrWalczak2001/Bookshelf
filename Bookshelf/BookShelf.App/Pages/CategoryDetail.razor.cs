using BookShelf.App.Contracts;
using BookShelf.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.App.Pages
{
    public partial class CategoryDetail
    {
        [Parameter]
        public string CategoryId { get; set; }
        public CategoryViewModel Category { get; set; } = new();
        [Inject]
        public ICategoryService CategoryService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Category = await CategoryService.GetById(Guid.Parse(CategoryId));
        }
        protected async Task DeleteCategory()
        {
            await CategoryService.Delete(Category.Id);
        }
    }
}
