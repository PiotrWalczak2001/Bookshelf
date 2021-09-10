using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Application.Features.Books.Queries.GetBookToRead
{
    public class BookToReadVm
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public byte[] BookBytes { get; set; }
    }
}
