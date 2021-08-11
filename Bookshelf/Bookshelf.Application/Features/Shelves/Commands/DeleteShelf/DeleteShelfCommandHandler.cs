using Bookshelf.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.Application.Features.Shelves.Commands.DeleteShelf
{
    public class DeleteShelfCommandHandler : IRequestHandler<DeleteShelfCommand>
    {
        private readonly IShelfRepository _shelfRepository;
        public DeleteShelfCommandHandler(IShelfRepository shelfRepository)
        {
            _shelfRepository = shelfRepository;
        }
        public async Task<Unit> Handle(DeleteShelfCommand request, CancellationToken cancellationToken)
        {
            var shelfToDelete = await _shelfRepository.GetByIdAsync(request.Id);
            await _shelfRepository.RemoveAllShelfBooks(request.Id);
            await _shelfRepository.DeleteAsync(shelfToDelete);
            return Unit.Value;
        }
    }
}
