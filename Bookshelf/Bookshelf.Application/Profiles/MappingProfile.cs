﻿using AutoMapper;
using Bookshelf.Application.Features.Books.Commands.AddBook;
using Bookshelf.Application.Features.Books.Commands.UpdateBook;
using Bookshelf.Application.Features.Books.Queries.GetAllBooks;
using Bookshelf.Application.Features.Books.Queries.GetBookDetails;
using Bookshelf.Application.Features.Shelves.Commands.AddBookToShelf;
using Bookshelf.Application.Features.Shelves.Commands.AddShelf;
using Bookshelf.Application.Features.Shelves.Commands.UpdateShelf;
using Bookshelf.Application.Features.Shelves.Queries.GetAllBooksFromShelf;
using Bookshelf.Application.Features.Shelves.Queries.GetAllShelves;
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

            //shelves
            CreateMap<Shelf, ShelfVm>().ReverseMap();
            CreateMap<Shelf, ShelfWithBooksVm>().ReverseMap();
            CreateMap<ShelfBookDto, ShelfBook>().ReverseMap();

            CreateMap<Shelf, AddShelfCommand>().ReverseMap();
            CreateMap<Shelf, UpdateShelfCommand>().ReverseMap();


            CreateMap<ShelfBook, AddBookToShelfCommand>().ReverseMap();

        }
    }
}
