using MediatR;
using System;

namespace Bookshelf.Application.Features.Books.Queries.GetBookDetails
{
    public class GetBookDetailsQuery : IRequest<BookDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
