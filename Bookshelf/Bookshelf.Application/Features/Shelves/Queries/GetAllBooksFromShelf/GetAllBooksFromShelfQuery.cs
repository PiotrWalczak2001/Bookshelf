using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Application.Features.Shelves.Queries.GetAllBooksFromShelf
{
    public class GetAllBooksFromShelfQuery : IRequest<ShelfWithBooksVm>
    {
        public Guid Id { get; set; }
    }
}
