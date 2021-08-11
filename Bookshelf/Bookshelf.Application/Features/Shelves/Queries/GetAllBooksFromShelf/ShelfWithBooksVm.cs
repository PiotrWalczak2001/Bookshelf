using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Application.Features.Shelves.Queries.GetAllBooksFromShelf
{
    public class ShelfWithBooksVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<ShelfBookDto> ShelfBooks { get; set; }
        
    }
}
