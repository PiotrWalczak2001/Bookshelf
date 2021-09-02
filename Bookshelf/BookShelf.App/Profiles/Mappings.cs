using AutoMapper;
using Bookshelf.Shared;
using BookShelf.App.ViewModels;

namespace BookShelf.App.Profiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Book, BookListViewModel>().ReverseMap();
            CreateMap<Book, BookDetailViewModel>().ReverseMap();

            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}
