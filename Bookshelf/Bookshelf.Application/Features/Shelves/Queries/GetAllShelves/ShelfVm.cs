using System;

namespace Bookshelf.Application.Features.Shelves.Queries.GetAllShelves
{
    public class ShelfVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public string NumberOfShelfBooks { get; set; }
    }
}
