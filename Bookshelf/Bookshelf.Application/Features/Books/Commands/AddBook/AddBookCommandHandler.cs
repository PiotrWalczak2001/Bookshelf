using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.Application.Features.Books.Commands.AddBook
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        public AddBookCommandHandler(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task<Guid> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);
            book = await _bookRepository.AddAsync(book);

            return book.Id;
        }
    }
}
