using MediatR;
using System.Collections.Generic;

namespace Bookshelf.Application.Features.Shelves.Queries.GetAllShelves
{
    public class GetAllShelvesQuery : IRequest<List<ShelfVm>>
    {
    }
}
