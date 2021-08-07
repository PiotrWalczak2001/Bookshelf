using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.Application.Features.ShelfBooks.Queries.GetAllShelfBooks
{
    public class GetAllShelfBooksQueryHandler : IRequestHandler<GetAllShelfBooksQuery, List<ShelfBookVm>>
    {
        private readonly IMapper _mapper;
        private readonly IShelfBookRepository _shelfBookRepository;

        public GetAllShelfBooksQueryHandler(IMapper mapper, IShelfBookRepository shelfBookRepository)
        {
            _shelfBookRepository = shelfBookRepository;
            _mapper = mapper;
        }
        public async Task<List<ShelfBookVm>> Handle(GetAllShelfBooksQuery request, CancellationToken cancellationToken)
        {
            var allShelfBooks = (await _shelfBookRepository.ListAllAsync()).OrderBy(sb => sb.ShelfId);
            return _mapper.Map<List<ShelfBookVm>>(allShelfBooks);
        }
    }
}
