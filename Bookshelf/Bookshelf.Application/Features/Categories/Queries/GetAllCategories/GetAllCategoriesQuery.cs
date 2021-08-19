using MediatR;
using System.Collections.Generic;

namespace Bookshelf.Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<List<CategoryVm>>
    {
    }
}
