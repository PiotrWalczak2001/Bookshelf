using Bookshelf.Application.Features.ShelfBooks.Queries.GetAllShelfBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Api.Controllers
{
    [ApiController]
    [Route("shelfbook")]
    public class ShelfBookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShelfBookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<ShelfBookVm>>> GetAllShelfBooks()
        {
            var dtos = await _mediator.Send(new GetAllShelfBooksQuery());
            return Ok(dtos);
        }
    }
}
