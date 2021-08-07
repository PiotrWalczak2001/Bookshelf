using AutoMapper;
using Bookshelf.Application.Features.Books.Queries.GetAllBooks;
using Bookshelf.Application.Features.ShelfBooks.Queries.GetAllShelfBooks;
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

            //shelfBooks
            CreateMap<ShelfBook, ShelfBookVm>().ReverseMap();

            //shelves
            CreateMap<Shelf, ShelfVm>().ReverseMap();
        }
    }
}
