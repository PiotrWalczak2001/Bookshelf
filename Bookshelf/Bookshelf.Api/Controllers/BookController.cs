using Bookshelf.Application.Features.Books.Queries.GetAllBooks;
using Bookshelf.Application.Features.Books.Queries.GetBookDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet("test")]
        public IActionResult Test()
        {
            var dto = "Hejka naklejka";
            return Ok(dto);
        }

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
    }
}
