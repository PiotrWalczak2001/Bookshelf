using BookShelf.App.Contracts;
using BookShelf.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.App.Pages
{
    public partial class BookOverview
    {
        public ICollection<BookListViewModel> Books { get; set; }
        [Inject]
        public IBookService BookService { get; set; }
        [Inject]
        public ICategoryService CategoryService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Books = (await BookService.GetAll()).ToList();
            foreach (var book in Books)
            {
                book.Category = await CategoryService.GetById(book.CategoryId);
            }
        }
    }
}
