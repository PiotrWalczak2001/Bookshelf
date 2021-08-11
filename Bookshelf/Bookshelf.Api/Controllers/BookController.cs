using Bookshelf.Application.Features.Books.Commands.AddBook;
using Bookshelf.Application.Features.Books.Commands.DeleteBook;
using Bookshelf.Application.Features.Books.Commands.UpdateBook;
using Bookshelf.Application.Features.Books.Queries.GetAllBooks;
using Bookshelf.Application.Features.Books.Queries.GetBookDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookshelf.Api.Controllers
{
    [ApiController]
    [Route("book")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // Queries
        [HttpGet("all")]
        public async Task<ActionResult<List<BookVm>>> GetAllBooks()
        {
            var dtos = await _mediator.Send(new GetAllBooksQuery());
            return Ok(dtos);
        }

        [HttpGet("details/{id}")]
        public async Task<ActionResult<BookDetailsVm>> GetBookById(Guid id)
        {
            var query = new GetBookDetailsQuery() { Id = id };
            return Ok(await _mediator.Send(query));
        }

        // Commands

        [HttpPost(Name = "AddBook")]
        public async Task<ActionResult<Guid>> Create([FromBody] AddBookCommand addBookCommand)
        {
            var id = await _mediator.Send(addBookCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateBook")]
        public async Task<ActionResult> Update([FromBody] UpdateBookCommand updateBookCommand)
        {
            await _mediator.Send(updateBookCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteBook")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteBookCommand = new DeleteBookCommand() { Id = id };
            await _mediator.Send(deleteBookCommand);
            return NoContent();
        }
    }
}
