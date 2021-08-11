using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.Application.Features.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        public UpdateBookCommandHandler(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var bookToUpdate = await _bookRepository.GetByIdAsync(request.Id);

            _mapper.Map(request, bookToUpdate, typeof(UpdateBookCommand), typeof(Book));

            await _bookRepository.UpdateAsync(bookToUpdate);

            return Unit.Value;
        }
    }
}
