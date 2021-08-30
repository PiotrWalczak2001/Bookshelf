using System;

namespace Bookshelf.App.ViewModels
{
    public class BooksListViewModel
    {
        public Guid Id { get; set; } 
        public string Title { get; set; }
        public string Author { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
