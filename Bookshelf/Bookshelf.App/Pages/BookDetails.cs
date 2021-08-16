using Bookshelf.App.Services;
using Bookshelf.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.App.Pages
{
    public partial class BookDetails
    {
        [Parameter]
        public string BookId { get; set; }
        public BookDetailsViewModel bookDetails { get; set; } = new BookDetailsViewModel();
        [Inject]
        public IBookDataService BookDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            bookDetails = await BookDataService.GetBookDetails(Guid.Parse(BookId));
        }
    }
}
