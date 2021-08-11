using MediatR;
using System;

namespace Bookshelf.Application.Features.Shelves.Commands.DeleteShelf
{
    public class DeleteShelfCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
