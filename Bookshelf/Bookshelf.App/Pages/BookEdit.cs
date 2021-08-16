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
        [Parameter]
        public string BookId { get; set; }
        public BookDetailsViewModel bookDetails { get; set; } = new BookDetailsViewModel();

        protected override async Task OnInitializedAsync()
        {
            if(string.IsNullOrEmpty(BookId))
            {
                bookDetails = new BookDetailsViewModel { ReleaseDate = DateTime.Now, CoverImageUrl = "https://cdn.pixabay.com/photo/2017/05/03/21/16/book-2282152_960_720.png" };
            }
            else
            {
                bookDetails = await BookDataService.GetBookDetails(Guid.Parse(BookId));
            }
        }

        protected async Task HandleValidSubmit()
        {
            if(bookDetails.Id == Guid.Empty)
            {
                bookDetails.Id = Guid.NewGuid();
                await BookDataService.AddBook(bookDetails);
            }
            else
            {
                await BookDataService.UpdateBook(bookDetails);
            }
                
        }
    }
}
