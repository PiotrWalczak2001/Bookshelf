using MediatR;
using System;

namespace Bookshelf.Application.Features.Shelves.Commands.AddBookToShelf
{
    public class AddBookToShelfCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid ShelfId { get; set; }
    }
}
