using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Application.Features.Shelves.Queries.GetShelf
{
    public class GetShelfQuery : IRequest<ShelfDetailsVm>
    {
        public Guid ShelfId { get; set; }
    }
}
