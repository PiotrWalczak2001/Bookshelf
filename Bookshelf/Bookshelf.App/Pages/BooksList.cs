using Bookshelf.App.Services;
using Bookshelf.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.App.Pages
{
    public partial class BooksList
    {
        public IEnumerable<BooksListViewModel> Books { get; set; }

        [Inject]
        public IBookDataService BookDataService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Books = (await BookDataService.GetAllBooks()).ToList();
            
        }
    }
}
