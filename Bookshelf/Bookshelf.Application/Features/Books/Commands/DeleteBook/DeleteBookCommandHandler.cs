using Bookshelf.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.Application.Features.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IBookRepository _bookRepository;
        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var bookToDelete = await _bookRepository.GetByIdAsync(request.Id);
            await _bookRepository.DeleteAsync(bookToDelete);

            return Unit.Value;
        }
    }
}
