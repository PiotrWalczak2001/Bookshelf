using Bookshelf.Application.Contracts.Persistence;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.Application.Features.Shelves.Commands.AddBookToShelf
{
    public class AddBookToShelfCommandValidator : AbstractValidator<AddBookToShelfCommand>
    {
        private readonly IShelfRepository _shelfRepository;
        public AddBookToShelfCommandValidator(IShelfRepository shelfRepository)
        {
            _shelfRepository = shelfRepository;

            RuleFor(sb => sb)
                .MustAsync(IsShelfBookUnique)
                .WithMessage("This book is already added to this shelf.");
        }

        private async Task<bool> IsShelfBookUnique(AddBookToShelfCommand sb, CancellationToken token)
        {
            return await _shelfRepository.IsShelfBookUnique(sb.Id, sb.ShelfId);
        }
    }
}
    