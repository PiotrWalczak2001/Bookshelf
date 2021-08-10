using Bookshelf.Domain.Common;
using System;

namespace Bookshelf.Domain.Entities
{
    public class Shelf : BaseEntity
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
}
