using MediatR;
using System;

namespace Bookshelf.Application.Features.Shelves.Commands.AddShelf
{
    public class AddShelfCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
}
