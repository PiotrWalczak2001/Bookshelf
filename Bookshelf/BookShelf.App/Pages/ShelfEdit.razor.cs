using BookShelf.App.Contracts;
using BookShelf.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.App.Pages
{
    public partial class ShelfEdit
    {
        [Inject]
        public IShelfService ShelfService { get; set; }

        [Parameter]
        public string ShelfId { get; set; }
        public ShelfDetailViewModel Shelf { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            if (string.IsNullOrEmpty(ShelfId))
            {
                Shelf = new ShelfDetailViewModel();
            }
            else
            {
                Shelf = await ShelfService.GetById(Guid.Parse(ShelfId));
            }
        }

        protected async Task SendEdit()
        {
            if (Shelf.Id == Guid.Empty)
            {
                Shelf.Id = Guid.NewGuid();
                await ShelfService.Create(Shelf);
            }
            else
            {
                await ShelfService.Update(Shelf);
            }

        }
    }
}
