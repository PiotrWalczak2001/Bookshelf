using Bookshelf.Domain.Common;
using System;

namespace Bookshelf.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CoverImageUrl { get; set; }
        public Guid CategoryId { get; set; }
    }
}
