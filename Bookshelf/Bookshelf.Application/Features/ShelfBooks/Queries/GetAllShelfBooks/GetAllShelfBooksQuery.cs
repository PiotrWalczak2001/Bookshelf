using MediatR;
using System.Collections.Generic;

namespace Bookshelf.Application.Features.ShelfBooks.Queries.GetAllShelfBooks
{
    public class GetAllShelfBooksQuery : IRequest<List<ShelfBookVm>>
    {
    }
}
