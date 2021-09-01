using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.Application.Features.Shelves.Queries.GetAllShelves
{
    public class GetAllShelvesQueryHandler : IRequestHandler<GetAllShelvesQuery, List<ShelfVm>>
    {
        private readonly IShelfRepository _shelfRepository;
        private readonly IMapper _mapper;
        public GetAllShelvesQueryHandler(IMapper mapper, IShelfRepository shelfRepository)
        {
            _shelfRepository = shelfRepository;
            _mapper = mapper;
        }
        public async Task<List<ShelfVm>> Handle(GetAllShelvesQuery request, CancellationToken cancellationToken)
        {
            var allShelves = await _shelfRepository.GetAllUserShelves(request.UserId);
            return _mapper.Map<List<ShelfVm>>(allShelves);
        }
    }
}
