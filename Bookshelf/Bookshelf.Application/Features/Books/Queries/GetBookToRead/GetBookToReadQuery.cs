using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Application.Features.Books.Queries.GetBookToRead
{
    public class GetBookToReadQuery : IRequest<BookToReadVm>
    {
        public Guid Id { get; set; }
    }
}
