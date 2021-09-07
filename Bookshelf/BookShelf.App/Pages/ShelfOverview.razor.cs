using BookShelf.App.Contracts;
using BookShelf.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.App.Pages
{
    public partial class ShelfOverview
    {
        public ICollection<ShelfListViewModel> Shelves { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IShelfService ShelfService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Shelves = (await ShelfService.GetAll()).ToList();
            if(Shelves.Count < 1)
            {
                NavigationManager.NavigateTo("/shelfedit");
            }
        }
    }
}
