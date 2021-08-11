using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.Application.Features.Shelves.Commands.UpdateShelf
{
    public class UpdateShelfCommandHandler : IRequestHandler<UpdateShelfCommand>
    {
        private readonly IMapper _mapper;
        private readonly IShelfRepository _shelfRepository;
        public UpdateShelfCommandHandler(IShelfRepository shelfRepository, IMapper mapper)
        {
            _shelfRepository = shelfRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateShelfCommand request, CancellationToken cancellationToken)
        {
            var shelfToUpdate = await _shelfRepository.GetByIdAsync(request.Id);

            _mapper.Map(request, shelfToUpdate, typeof(UpdateShelfCommand), typeof(Shelf));

            await _shelfRepository.UpdateAsync(shelfToUpdate);

            return Unit.Value;
        }
    }
}
