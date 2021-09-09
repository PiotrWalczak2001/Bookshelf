using BookShelf.App.Contracts;
using BookShelf.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.App.Pages
{
    public partial class AddBookToShelf
    {
        [Parameter]
        public string BookId { get; set; }
        public ShelfBookViewModel ShelfBook { get; set; } = new();
        public BookDetailViewModel Book { get; set; } = new();
        public List<ShelfListViewModel> Shelves { get; set; } = new List<ShelfListViewModel>();
        [Inject]
        public IShelfService ShelfService { get; set; }
        [Inject]
        public IBookService BookService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Book = await BookService.GetById(Guid.Parse(BookId));
            Shelves = (await ShelfService.GetAll()).ToList();
            ShelfBook.BookId = Book.Id;
        }

        protected async Task AddBookToShelfSubmit()
        {
            ShelfBook.Id = Guid.NewGuid();
            await ShelfService.AddBookToShelf(ShelfBook);
        }
    }
}
