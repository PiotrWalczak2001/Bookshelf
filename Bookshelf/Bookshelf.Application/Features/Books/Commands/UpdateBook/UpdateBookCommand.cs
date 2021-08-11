using MediatR;
using System;

namespace Bookshelf.Application.Features.Books.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string CoverImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Category { get; set; }
    }
}
