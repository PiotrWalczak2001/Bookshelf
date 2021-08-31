using Bookshelf.Application.Contracts.Persistence;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.Application.Features.Shelves.Commands.AddShelf
{
    public class AddShelfCommandValidator : AbstractValidator<AddShelfCommand>
    {
        private readonly IShelfRepository _shelfRepository;
        public AddShelfCommandValidator(IShelfRepository shelfRepository)
        {
            _shelfRepository = shelfRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(c => c)
                .MustAsync(IsShelfUnique)
                .WithMessage("Shelf with that name already exists.");
        }
        private async Task<bool> IsShelfUnique(AddShelfCommand c, CancellationToken token)
        {
            return !(await _shelfRepository.IsShelfUnique(c.Name, c.UserId));
        }
    }
}
