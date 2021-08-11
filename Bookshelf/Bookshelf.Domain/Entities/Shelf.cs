using Bookshelf.Domain.Common;
using System;
using System.Collections.Generic;

namespace Bookshelf.Domain.Entities
{
    public class Shelf : BaseEntity
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<ShelfBook> ShelfBooks { get; set; }
    }
}
