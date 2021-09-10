using BookShelf.App.Contracts;
using BookShelf.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.App.Pages
{
    public partial class BookReader
    {
        [Parameter]
        public string BookId { get; set; }
        public BookDetailViewModel Book { get; set; } = new();
        public string relativeUri { get; set; }
        [Inject]
        public IBookService BookService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Book = await BookService.GetById(Guid.Parse(BookId));
            relativeUri = $"https://localhost:44307/api/Book/readbook/?bookId={Book.Id}";
        }
    }
}
