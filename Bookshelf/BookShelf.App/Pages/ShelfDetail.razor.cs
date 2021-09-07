using BookShelf.App.Contracts;
using BookShelf.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.App.Pages
{
    public partial class ShelfDetail
    {
        [Parameter]
        public string ShelfId { get; set; }
        public string NoBooksMessage { get; set; }
        [Inject]
        public IShelfService ShelfService { get; set; }
        public ICollection<ShelfBookViewModel> ShelfBooks { get; set; }
        public ShelfDetailViewModel Shelf { get; set; } = new();

        protected async override Task OnInitializedAsync()
        {
            Shelf = await ShelfService.GetById(Guid.Parse(ShelfId));
            ShelfBooks = Shelf.ShelfBooks;
        }
    }
}
