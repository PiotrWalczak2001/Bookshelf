using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.Application.Features.Shelves.Commands.AddShelf
{
    public class AddShelfCommandHandler : IRequestHandler<AddShelfCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IShelfRepository _shelfRepository;
        public AddShelfCommandHandler(IMapper mapper, IShelfRepository shelfRepository)
        {
            _shelfRepository = shelfRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AddShelfCommand request, CancellationToken cancellationToken)
        {
            var shelf = _mapper.Map<Shelf>(request);
            await _shelfRepository.AddAsync(shelf);
            return shelf.Id;
        }
    }
}
