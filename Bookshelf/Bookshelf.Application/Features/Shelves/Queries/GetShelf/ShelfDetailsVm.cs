using System;
using System.Collections.Generic;

namespace Bookshelf.Application.Features.Shelves.Queries.GetShelf
{
    public class ShelfDetailsVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<ShelfBookDto> ShelfBooks { get; set; }
    }
}
