using MediatR;
using System.Collections.Generic;

namespace Bookshelf.Application.Features.Books.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<List<BookVm>>
    {
    }
}
