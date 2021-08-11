using Bookshelf.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.Application.Features.Shelves.Commands.RemoveBookFromShelf
{
    public class RemoveBookFromShelfCommandHandler : IRequestHandler<RemoveBookFromShelfCommand>
    {
        private readonly IShelfRepository _shelfRepository;
        public RemoveBookFromShelfCommandHandler(IShelfRepository shelfRepository)
        {
            _shelfRepository = shelfRepository;
        }
        public async Task<Unit> Handle(RemoveBookFromShelfCommand request, CancellationToken cancellationToken)
        {
            await _shelfRepository.RemoveBookFromShelf(request.Id);
            return Unit.Value;
        }
    }
}
