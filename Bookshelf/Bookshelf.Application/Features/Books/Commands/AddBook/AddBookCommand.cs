using MediatR;
using System;

namespace Bookshelf.Application.Features.Books.Commands.AddBook
{
    public class AddBookCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string CoverImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Guid CategoryId { get; set; }
        public byte[] BookBytes { get; set; }
    }
}
