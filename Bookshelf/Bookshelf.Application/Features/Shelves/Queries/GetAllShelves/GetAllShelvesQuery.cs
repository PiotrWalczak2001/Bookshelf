using MediatR;
using System;
using System.Collections.Generic;

namespace Bookshelf.Application.Features.Shelves.Queries.GetAllShelves
{
    public class GetAllShelvesQuery : IRequest<List<ShelfVm>>
    {
        public Guid UserId { get; set; }
    }
}
