using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.Application.Features.Shelves.Commands.AddBookToShelf
{
    public class AddBookToShelfCommandHandler : IRequestHandler<AddBookToShelfCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IShelfRepository _shelfRepository;
        public AddBookToShelfCommandHandler(IMapper mapper, IShelfRepository shelfRepository)
        {
            _shelfRepository = shelfRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(AddBookToShelfCommand request, CancellationToken cancellationToken)
        {
            var bookToAdd = _mapper.Map<ShelfBook>(request);
            await _shelfRepository.AddBookToShelf(bookToAdd);
            return bookToAdd.Id;
        }
    }
}
