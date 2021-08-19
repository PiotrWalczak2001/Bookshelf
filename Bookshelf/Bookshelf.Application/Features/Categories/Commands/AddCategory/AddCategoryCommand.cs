using MediatR;
using System;

namespace Bookshelf.Application.Features.Categories.Commands.AddCategory
{
    public class AddCategoryCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
