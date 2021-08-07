using System;

namespace Bookshelf.Application.Features.ShelfBooks.Queries.GetAllShelfBooks
{
    public class ShelfBookVm
    {
        public Guid Id { get; set; }
        public Guid ShelfId { get; set; }
        public Guid BookId { get; set; }
    }
}
