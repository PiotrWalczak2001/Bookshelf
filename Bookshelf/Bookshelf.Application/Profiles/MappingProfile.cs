using AutoMapper;
using Bookshelf.Application.Features.Books.Queries.GetAllBooks;
using Bookshelf.Application.Features.Books.Queries.GetBookDetails;
using Bookshelf.Application.Features.Shelves.Queries.GetAllBooksFromShelf;
using Bookshelf.Application.Features.Shelves.Queries.GetAllShelves;
using Bookshelf.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //books
            CreateMap<Book, BookVm>().ReverseMap();
            CreateMap<Book, BookDetailsVm>().ReverseMap();

            //shelves
            CreateMap<Shelf, ShelfVm>().ReverseMap();
            CreateMap<Shelf, ShelfWithBooksVm>().ReverseMap();
            CreateMap<ShelfBookDto, ShelfBook>().ReverseMap();
            
        }
    }
}
