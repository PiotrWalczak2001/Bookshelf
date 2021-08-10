using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.App.ViewModels
{
    public class BooksListViewModel
    {
        public Guid Id { get; set; } 
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
