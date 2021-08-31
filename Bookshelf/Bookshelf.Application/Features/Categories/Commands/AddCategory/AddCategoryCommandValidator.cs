using Bookshelf.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.Application.Features.Categories.Commands.AddCategory
{
    public class AddCategoryCommandValidator : AbstractValidator<AddCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        public AddCategoryCommandValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(c => c)
                .MustAsync(IsCategoryUnique)
                .WithMessage("This category already exists.");
        }

        private async Task<bool> IsCategoryUnique(AddCategoryCommand c, CancellationToken token)
        {
            return !(await _categoryRepository.IsCategoryUnique(c.Name));
        }
    }
}
