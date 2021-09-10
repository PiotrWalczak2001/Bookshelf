using Bookshelf.Application.Features.Books.Commands.AddBook;
using Bookshelf.Application.Features.Books.Commands.DeleteBook;
using Bookshelf.Application.Features.Books.Commands.UpdateBook;
using Bookshelf.Application.Features.Books.Queries.GetAllBooks;
using Bookshelf.Application.Features.Books.Queries.GetBookDetails;
using Bookshelf.Application.Features.Books.Queries.GetBookToRead;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Bookshelf.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // Queries
        [HttpGet("all", Name ="GetAllBooks")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<BookVm>>> GetAllBooks()
        {
            var dtos = await _mediator.Send(new GetAllBooksQuery());
            return Ok(dtos);
        }

        [HttpGet("details/{id}", Name ="GetBookDetails")]
        [AllowAnonymous]
        public async Task<ActionResult<BookDetailsVm>> GetBookById(Guid id)
        {
            var query = new GetBookDetailsQuery() { Id = id };
            return Ok(await _mediator.Send(query));
        }

        // Commands

        [HttpPost(Name ="AddBook")]
        [Authorize]
        public async Task<ActionResult<Guid>> Add([FromBody] AddBookCommand addBookCommand)
        {
            var id = await _mediator.Send(addBookCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateBook")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateBookCommand updateBookCommand)
        {
            await _mediator.Send(updateBookCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name ="DeleteBook")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteBookCommand = new DeleteBookCommand() { Id = id };
            await _mediator.Send(deleteBookCommand);
            return NoContent();
        }

        [HttpGet]
        [Route("readbook")]
        public async Task<ActionResult> ReadBook(Guid bookId)
        {
            var query = new GetBookToReadQuery { Id = bookId };
            var response = await _mediator.Send(query);
            MemoryStream ms = new MemoryStream(response.BookBytes);
            return new FileStreamResult(ms, "application/pdf");
        }
    }
}
