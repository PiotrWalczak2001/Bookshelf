using BookShelf.App.Contracts;
using BookShelf.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.App.Pages
{
    public partial class BookDetail
    {
        [Parameter]
        public string BookId { get; set; }
        public BookDetailViewModel Book { get; set; } = new();
        public CategoryViewModel Category { get; set; } = new();
        [Inject]
        public IBookService BookService { get; set; }
        [Inject]
        public ICategoryService CategoryService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Book = await BookService.GetById(Guid.Parse(BookId));
            Category = await CategoryService.GetById(Book.CategoryId);
        }
    }
}
