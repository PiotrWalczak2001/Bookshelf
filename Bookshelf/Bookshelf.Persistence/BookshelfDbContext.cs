using Bookshelf.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Persistence
{
    public class BookshelfDbContext : IdentityDbContext
    {
        public BookshelfDbContext(DbContextOptions<BookshelfDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<ShelfBook> ShelfBooks { get; set; }
        
    }
}
