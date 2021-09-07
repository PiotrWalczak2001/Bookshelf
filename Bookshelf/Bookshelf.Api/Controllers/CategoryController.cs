using Bookshelf.Application.Features.Categories.Commands.AddCategory;
using Bookshelf.Application.Features.Categories.Commands.DeleteCategory;
using Bookshelf.Application.Features.Categories.Queries.GetAllCategories;
using Bookshelf.Application.Features.Categories.Queries.GetCategoryById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookshelf.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name ="GetAllCategories")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<CategoryVm>>> GetAllCategories()
        {
            var dtos = await _mediator.Send(new GetAllCategoriesQuery());
            return Ok(dtos);
        }

        [HttpGet("details/{id}", Name ="GetCategoryDetails")]
        [AllowAnonymous]
        public async Task<ActionResult<CategoryDetailsVm>> GetCategoryById(Guid id)
        {
            var query = new GetCategoryDetailsQuery() { Id = id };
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(Name ="AddCategory")]
        [Authorize]
        public async Task<ActionResult<Guid>> Add([FromBody] AddCategoryCommand addCategoryCommand)
        {
            var id = await _mediator.Send(addCategoryCommand);
            return Ok(id);
        }

        [HttpDelete("{id}", Name ="DeleteCategory")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteCategoryCommand = new DeleteCategoryCommand() { Id = id };
            await _mediator.Send(deleteCategoryCommand);
            return NoContent();
        }
    }
}
