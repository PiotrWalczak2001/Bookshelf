using BookShelf.App.Contracts;
using BookShelf.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.App.Pages
{
    public partial class CategoryOverview
    {
        public ICollection<CategoryViewModel> Categories { get; set; }
        [Inject]
        public ICategoryService CategoryService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Categories = (await CategoryService.GetAll()).ToList();
        }
    }
}
