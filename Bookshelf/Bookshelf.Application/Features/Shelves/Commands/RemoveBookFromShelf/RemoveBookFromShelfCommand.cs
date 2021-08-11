using MediatR;
using System;

namespace Bookshelf.Application.Features.Shelves.Commands.RemoveBookFromShelf
{
    public class RemoveBookFromShelfCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
