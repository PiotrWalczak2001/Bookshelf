using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Shared
{
    public class Shelf
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<ShelfBook> ShelfBooks { get; set; }
    }
}
