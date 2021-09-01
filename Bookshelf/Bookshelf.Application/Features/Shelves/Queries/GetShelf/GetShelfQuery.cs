using MediatR;
using System;

namespace Bookshelf.Application.Features.Shelves.Queries.GetShelf
{
    public class GetShelfQuery : IRequest<ShelfDetailsVm>
    {
        public Guid ShelfId { get; set; }
    }
}
