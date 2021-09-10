using BookShelf.App.Contracts;
using BookShelf.App.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.App.Pages
{
    public partial class BookEdit
    {
        [Inject]
        public IBookService BookService { get; set; }
        [Inject]
        public ICategoryService CategoryService { get; set; }

        [Parameter]
        public string BookId { get; set; }
        public BookDetailViewModel Book { get; set; } = new();
        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();

        protected Guid CategoryId = Guid.Empty;

        protected override async Task OnInitializedAsync()
        {
            Categories = (await CategoryService.GetAll()).ToList();

            if (string.IsNullOrEmpty(BookId))
            {
                Book = new BookDetailViewModel { ReleaseDate = DateTime.Now, CoverImageUrl = "https://cdn.pixabay.com/photo/2017/05/03/21/16/book-2282152_960_720.png" };
            }
            else
            {
                Book = await BookService.GetById(Guid.Parse(BookId));
            }

            CategoryId = Book.CategoryId;
        }
        private IReadOnlyList<IBrowserFile> selectedFiles;
        private void OnInputFileChange(InputFileChangeEventArgs e)
        {
            selectedFiles = e.GetMultipleFiles();
            StateHasChanged();
        }
        protected async Task SendEdit()
        {
            Book.CategoryId = CategoryId;
            Book.Category = await CategoryService.GetById(Book.CategoryId);
            if (Book.Id == Guid.Empty)
            {
                if (selectedFiles != null)
                {
                    var file = selectedFiles[0];
                    Stream stream = file.OpenReadStream();
                    MemoryStream ms = new();
                    await stream.CopyToAsync(ms);
                    stream.Close();

                    Book.BookBytes = ms.ToArray();
                }
                Book.Id = Guid.NewGuid();
                await BookService.Create(Book);
            }
            else
            {
                if (selectedFiles != null)
                {
                    var file = selectedFiles[0];
                    Stream stream = file.OpenReadStream();
                    MemoryStream ms = new();
                    await stream.CopyToAsync(ms);
                    stream.Close();

                    Book.BookBytes = ms.ToArray();
                }
                await BookService.Update(Book);
            }

        }

        protected async Task DeleteBook()
        {
            await BookService.Delete(Book.Id);
        }
    }
}
