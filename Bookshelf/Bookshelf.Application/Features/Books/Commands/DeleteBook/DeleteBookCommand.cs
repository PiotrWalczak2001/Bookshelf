using MediatR;
using System;

namespace Bookshelf.Application.Features.Books.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
