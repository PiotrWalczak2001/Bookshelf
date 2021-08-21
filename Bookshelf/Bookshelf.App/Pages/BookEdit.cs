﻿using Bookshelf.App.Contracts;
using Bookshelf.App.Services;
using Bookshelf.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.App.Pages
{
    public partial class BookEdit
    {
        [Inject]
        public IBookDataService BookDataService { get; set; }
        [Inject]
        public ICategoryDataService CategoryDataService { get; set; }

        [Parameter]
        public string BookId { get; set; }
        public BookDetailsViewModel Book { get; set; } = new();
        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();

        protected Guid CategoryId = Guid.Empty;

        protected override async Task OnInitializedAsync()
        {
            Categories = (await CategoryDataService.GetAllCategories()).ToList();

            if(string.IsNullOrEmpty(BookId))
            {
                Book = new BookDetailsViewModel { ReleaseDate = DateTime.Now, CoverImageUrl = "https://cdn.pixabay.com/photo/2017/05/03/21/16/book-2282152_960_720.png" };
            }
            else
            {
                Book = await BookDataService.GetBookDetails(Guid.Parse(BookId));
            }

            CategoryId = Book.CategoryId;
        }

        protected async Task HandleValidSubmit()
        {
            Book.CategoryId = CategoryId;
            if(Book.Id == Guid.Empty)
            {
                Book.Id = Guid.NewGuid();
                await BookDataService.AddBook(Book);
            }
            else
            {
                await BookDataService.UpdateBook(Book);
            }
                
        }

        protected async Task DeleteBook()
        {
            await BookDataService.DeleteBook(Book.Id);
        }
    }
}