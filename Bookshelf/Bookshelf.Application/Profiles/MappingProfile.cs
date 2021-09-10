using AutoMapper;
using Bookshelf.Application.Features.Books.Commands.AddBook;
using Bookshelf.Application.Features.Books.Commands.UpdateBook;
using Bookshelf.Application.Features.Books.Queries.GetAllBooks;
using Bookshelf.Application.Features.Books.Queries.GetBookDetails;
using Bookshelf.Application.Features.Books.Queries.GetBookToRead;
using Bookshelf.Application.Features.Categories.Commands.AddCategory;
using Bookshelf.Application.Features.Categories.Queries.GetAllCategories;
using Bookshelf.Application.Features.Categories.Queries.GetCategoryById;
using Bookshelf.Application.Features.Shelves.Commands.AddBookToShelf;
using Bookshelf.Application.Features.Shelves.Commands.AddShelf;
using Bookshelf.Application.Features.Shelves.Commands.UpdateShelf;
using Bookshelf.Application.Features.Shelves.Queries.GetAllShelves;
using Bookshelf.Application.Features.Shelves.Queries.GetShelf;
using Bookshelf.Domain.Entities;

namespace Bookshelf.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //books
            CreateMap<Book, BookVm>().ReverseMap();
            CreateMap<Book, BookDetailsVm>().ReverseMap();

            CreateMap<Book, AddBookCommand>().ReverseMap();
            CreateMap<Book, UpdateBookCommand>().ReverseMap();

            CreateMap<Book, BookToReadVm>().ReverseMap();

            //shelves
            CreateMap<Shelf, ShelfVm>().ReverseMap();
            CreateMap<ShelfBookDto, ShelfBook>().ReverseMap();
            CreateMap<Shelf, ShelfDetailsVm>().ReverseMap();

            CreateMap<Shelf, AddShelfCommand>().ReverseMap();
            CreateMap<Shelf, UpdateShelfCommand>().ReverseMap();

            // categories
            CreateMap<Category, CategoryVm>().ReverseMap();
            CreateMap<Category, CategoryDetailsVm>().ReverseMap();
            CreateMap<Category, CategoryDto>();

            CreateMap<Category, AddCategoryCommand>().ReverseMap();

            //shelfbook
            CreateMap<ShelfBook, AddBookToShelfCommand>().ReverseMap();

        }
    }
}
