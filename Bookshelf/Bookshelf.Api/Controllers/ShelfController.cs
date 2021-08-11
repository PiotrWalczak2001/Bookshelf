using Bookshelf.Application.Features.Shelves.Queries.GetAllBooksFromShelf;
using Bookshelf.Application.Features.Shelves.Queries.GetAllShelves;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Api.Controllers
{
    [ApiController]
    [Route("shelf")]
    public class ShelfController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShelfController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<ShelfVm>>> GetAllShelves()
        {
            var dtos = await _mediator.Send(new GetAllShelvesQuery());
            return Ok(dtos);
        }

        // getting books from shelf
        [HttpGet("booksfromshelf/{id}")]
        public async Task<ActionResult<ShelfWithBooksVm>> GetAllBooksFromShelf(Guid id)
        {
            var query = new GetAllBooksFromShelfQuery() { Id = id };
            return Ok(await _mediator.Send(query));
        }

    }
}
