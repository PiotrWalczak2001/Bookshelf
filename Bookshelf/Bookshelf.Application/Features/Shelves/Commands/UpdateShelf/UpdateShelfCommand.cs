using MediatR;
using System;

namespace Bookshelf.Application.Features.Shelves.Commands.UpdateShelf
{
    public class UpdateShelfCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
}
