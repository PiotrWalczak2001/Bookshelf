using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.Application.Features.Books.Queries.GetBookToRead
{
    public class GetBookToReadQueryHandler : IRequestHandler<GetBookToReadQuery, BookToReadVm>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public GetBookToReadQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookToReadVm> Handle(GetBookToReadQuery request, CancellationToken cancellationToken)
        {
            var bookToRead = await _bookRepository.GetByIdAsync(request.Id);
            return _mapper.Map<BookToReadVm>(bookToRead);
        }
    }
}
