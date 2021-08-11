using MediatR;
using System;

namespace Bookshelf.Application.Features.Shelves.Queries.GetAllBooksFromShelf
{
    public class GetAllBooksFromShelfQuery : IRequest<ShelfWithBooksVm>
    {
        public Guid Id { get; set; }
    }
}
