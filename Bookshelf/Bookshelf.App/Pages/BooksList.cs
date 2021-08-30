using Bookshelf.App.Contracts;
using Bookshelf.App.Services;
using Bookshelf.App.ViewModels;
using Microsoft.AspNetCore.Components;
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
        [Inject]
        public ICategoryDataService CategoryDataService {get; set;}

        protected async override Task OnInitializedAsync()
        {
            Books = (await BookDataService.GetAllBooks()).ToList();
            foreach (var book in Books)
            {
                book.Category = await CategoryDataService.GetCategoryDetails(book.CategoryId);
            }
                
        }
    }
}
