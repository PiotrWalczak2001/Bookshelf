using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.Application.Features.Shelves.Queries.GetShelf
{
    public class GetShelfQueryHandler : IRequestHandler<GetShelfQuery, ShelfDetailsVm>
    {
        private readonly IShelfRepository _shelfRepository;
        private readonly IMapper _mapper;
        public GetShelfQueryHandler(IMapper mapper, IShelfRepository shelfRepository)
        {
            _shelfRepository = shelfRepository;
            _mapper = mapper;
        }

        public async Task<ShelfDetailsVm> Handle(GetShelfQuery request, CancellationToken cancellationToken)
        {
            var booksFromShelf = (await _shelfRepository.GetAllBooksFromShelf(request.ShelfId)).ToList();

            foreach (var book in booksFromShelf)
            {
                _mapper.Map<ShelfBookDto>(book);
            }

            var shelf = await _shelfRepository.GetByIdAsync(request.ShelfId);
            shelf.ShelfBooks = booksFromShelf;

            return _mapper.Map<ShelfDetailsVm>(shelf);
        }
    }
}
