using MediatR;
using System;

namespace Bookshelf.Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryDetailsQuery : IRequest<CategoryDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
