using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.Application.Features.Shelves.Queries.GetAllBooksFromShelf
{
    public class GetAllBooksFromShelfQueryHandler : IRequestHandler<GetAllBooksFromShelfQuery, ShelfWithBooksVm>
    {
        private readonly IMapper _mapper;
        private readonly IShelfRepository _shelfRepository;

        public GetAllBooksFromShelfQueryHandler(IMapper mapper, IShelfRepository shelfRepository)
        {
            _shelfRepository = shelfRepository;
            _mapper = mapper;
        }
        public async Task<ShelfWithBooksVm> Handle(GetAllBooksFromShelfQuery request, CancellationToken cancellationToken)
        {
            var booksFromShelf = (await _shelfRepository.GetAllBooksFromShelf(request.Id)).ToList();

            foreach (var book in booksFromShelf)
            {
                _mapper.Map<ShelfBookDto>(book);               
            }

            var shelf = await _shelfRepository.GetByIdAsync(request.Id);
            shelf.ShelfBooks = booksFromShelf;


            return _mapper.Map<ShelfWithBooksVm>(shelf);
        }
    }
}
