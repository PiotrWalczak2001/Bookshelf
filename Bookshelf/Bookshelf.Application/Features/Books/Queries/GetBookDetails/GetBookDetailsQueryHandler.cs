using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.Application.Features.Books.Queries.GetBookDetails
{
    public class GetBookDetailsQueryHandler : IRequestHandler<GetBookDetailsQuery, BookDetailsVm>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;
        public GetBookDetailsQueryHandler(IMapper mapper, IBookRepository bookRepository, ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<BookDetailsVm> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
        {
            var bookDetails = await _bookRepository.GetByIdAsync(request.Id);
            var bookDetailsDto = _mapper.Map<BookDetailsVm>(bookDetails);
            var category = await _categoryRepository.GetByIdAsync(bookDetails.CategoryId);


            bookDetailsDto.Category = _mapper.Map<CategoryDto>(category);

            return bookDetailsDto;
        }
    }
}
