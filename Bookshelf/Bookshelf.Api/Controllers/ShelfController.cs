using Bookshelf.Application.Features.Shelves.Commands.AddBookToShelf;
using Bookshelf.Application.Features.Shelves.Commands.AddShelf;
using Bookshelf.Application.Features.Shelves.Commands.DeleteShelf;
using Bookshelf.Application.Features.Shelves.Commands.RemoveBookFromShelf;
using Bookshelf.Application.Features.Shelves.Commands.UpdateShelf;
using Bookshelf.Application.Features.Shelves.Queries.GetAllShelves;
using Bookshelf.Application.Features.Shelves.Queries.GetShelf;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        // Queries

        [HttpGet("all/{userId}")]
        [Authorize]
        public async Task<ActionResult<List<ShelfVm>>> GetAllShelves(Guid userId)
        {
            var query = new GetAllShelvesQuery() { UserId = userId };
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{shelfId}")]
        [Authorize]
        public async Task<ActionResult<ShelfDetailsVm>> GetShelfDetails(Guid shelfId)
        {
            var query = new GetShelfQuery() { ShelfId = shelfId };
            return Ok(await _mediator.Send(query));
        }

        // Commands

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> Add([FromBody] AddShelfCommand addShelfCommand)
        {
            var id = await _mediator.Send(addShelfCommand);
            return Ok(id);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Update([FromBody] UpdateShelfCommand updateShelfCommand)
        {
            await _mediator.Send(updateShelfCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteShelfCommand = new DeleteShelfCommand() { Id = id };
            await _mediator.Send(deleteShelfCommand);
            return NoContent();
        }

        // shelfbooks
        [HttpPost("shelfbook/add")]
        [Authorize]
        public async Task<ActionResult<Guid>> Add([FromBody] AddBookToShelfCommand addBookShelfCommand)
        {
            var id = await _mediator.Send(addBookShelfCommand);
            return Ok(id);
        }

        [HttpDelete("shelfbook/{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteShelfBook(Guid id)
        {
            var deleteBookFromShelfCommand = new RemoveBookFromShelfCommand() { Id = id };
            await _mediator.Send(deleteBookFromShelfCommand);
            return NoContent();
        }

    }
}
