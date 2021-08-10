using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.Application.Features.Books.Queries.GetBookDetails
{
    public class GetBookDetailsQueryHandler : IRequestHandler<GetBookDetailsQuery, BookDetailsVm>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        public GetBookDetailsQueryHandler(IMapper mapper, IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<BookDetailsVm> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
        {
            var bookDetails = await _bookRepository.GetByIdAsync(request.Id);
            return _mapper.Map<BookDetailsVm>(bookDetails);
        }
    }
}
