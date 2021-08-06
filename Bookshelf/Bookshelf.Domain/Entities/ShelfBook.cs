using Bookshelf.Domain.Common;
using System;

namespace Bookshelf.Domain.Entities
{
    public class ShelfBook : BaseEntity
    {
        public Guid ShelfId { get; set; }
        public Guid BookId { get; set; }
    }
}
