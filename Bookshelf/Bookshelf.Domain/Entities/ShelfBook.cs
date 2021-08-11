using Bookshelf.Domain.Common;
using System;

namespace Bookshelf.Domain.Entities
{
    public class ShelfBook : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string CoverImageUrl { get; set; }
        public Guid ShelfId { get; set; }
        public Guid BookId { get; set; }
    }
}
