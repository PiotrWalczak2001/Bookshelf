using BookShelf.App.Contracts;
using BookShelf.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.App.Pages
{
    public partial class CategoryCreate
    {
            [Inject]
            public ICategoryService CategoryService { get; set; }
            public CategoryViewModel Category { get; set; }

            protected override async Task OnInitializedAsync()
            {
                Category = new CategoryViewModel();
             }
            protected async Task SendCreateRequest()
            {
                 Category.Id = Guid.NewGuid();
                 await CategoryService.Create(Category);
            }  
    }
}
