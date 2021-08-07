using System;

namespace Bookshelf.Application.Features.Books.Queries.GetAllBooks
{
    public class BookVm
    {
        public Guid Id { get; set; } // only for testing
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
       // public DateTime ReleaseDate { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
