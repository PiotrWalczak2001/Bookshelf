using System;

namespace Bookshelf.Application.Features.Shelves.Queries.GetAllBooksFromShelf
{
    public class ShelfBookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string CoverImageUrl { get; set; }
        public Guid BookId { get; set; }
        public Guid ShelfId { get; set; }
    }
}
