using Bookshelf.Application.Features.Shelves.Commands.AddBookToShelf;
using Bookshelf.Application.Features.Shelves.Commands.RemoveBookFromShelf;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bookshelf.Api.Controllers
{
    [ApiController]
    [Route("shelfBook")]
    public class ShelfBookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShelfBookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Add([FromBody] AddBookToShelfCommand addBookShelfCommand)
        {
            var id = await _mediator.Send(addBookShelfCommand);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteBookFromShelfCommand = new RemoveBookFromShelfCommand() { Id = id };
            await _mediator.Send(deleteBookFromShelfCommand);
            return NoContent();
        }
    }
}
