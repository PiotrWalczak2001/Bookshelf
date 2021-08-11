using System;

namespace Bookshelf.App.ViewModels
{
    public class BookDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CoverImageUrl { get; set; }
        public string Category { get; set; }
    }
}
