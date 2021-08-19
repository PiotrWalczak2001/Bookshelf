using Bookshelf.Application.Features.Categories.Commands.AddCategory;
using Bookshelf.Application.Features.Categories.Commands.DeleteCategory;
using Bookshelf.Application.Features.Categories.Queries.GetAllCategories;
using Bookshelf.Application.Features.Categories.Queries.GetCategoryById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Api.Controllers
{
    [ApiController]
    [Route("category")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<CategoryVm>>> GetAllCategories()
        {
            var dtos = await _mediator.Send(new GetAllCategoriesQuery());
            return Ok(dtos);
        }

        [HttpGet("details/{id}")]
        public async Task<ActionResult<CategoryDetailsVm>> GetCategoryById(Guid id)
        {
            var query = new GetCategoryDetailsQuery() { Id = id };
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Add([FromBody] AddCategoryCommand addCategoryCommand)
        {
            var id = await _mediator.Send(addCategoryCommand);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteCategoryCommand = new DeleteCategoryCommand() { Id = id };
            await _mediator.Send(deleteCategoryCommand);
            return NoContent();
        }
    }
}
