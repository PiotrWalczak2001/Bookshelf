using Bookshelf.Domain.Entities;
using Bookshelf.Persistence.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bookshelf.Persistence
{
    public class BookshelfDbContext : IdentityDbContext<ApplicationUser>
    {
        public BookshelfDbContext(DbContextOptions<BookshelfDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<ShelfBook> ShelfBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookshelfDbContext).Assembly);

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = Guid.Parse("{BB76804E-2E80-4A1B-9015-D22B0AB7AA13}"),
                Title = "The Last Wish",
                Author = "Andrzej Sapkowski",
                Description = "The Last Wish - is the first (in its fictional chronology; published second in original Polish) of the two collections of short stories (the other being Sword of Destiny) preceding the main Witcher Saga, written by Polish fantasy writer Andrzej Sapkowski.",
                CoverImageUrl = "https://cdn.pixabay.com/photo/2017/05/03/21/16/book-2282152_960_720.png",
                Category = "Fantasy"
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = Guid.Parse("{B014368A-98EF-42C9-95F9-1DFE50501085}"),
                Title = "Sword of Destiny",
                Author = "Andrzej Sapkowski",
                Description = "is the second (in its fictional chronology; first in Polish print) of the two collections of short stories (the other being The Last Wish), both preceding the main Witcher Saga. The stories were written by Polish fantasy author Andrzej Sapkowski.",
                CoverImageUrl = "https://cdn.pixabay.com/photo/2017/05/03/21/16/book-2282152_960_720.png",
                Category = "Fantasy"
            });

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "925433D2-557E-45EE-8D84-017918A2D760",
                FirstName = "Jan",
                LastName = "Testowy",
                UserName = "testuser",
                Email = "jan@testowy.com",
                EmailConfirmed = true,
            });

            modelBuilder.Entity<Shelf>().HasData(new Shelf
            {
               Id = Guid.Parse("{D7A45328-D6F1-4998-A93A-4785CDD415D2}"),
               UserId = Guid.Parse("{925433D2-557E-45EE-8D84-017918A2D760}"),
               Name = "Favorite"
            });

            modelBuilder.Entity<Shelf>().HasData(new Shelf
            {
                Id = Guid.Parse("{7022434D-0913-42E5-98AD-1DB0F1A45DD4}"),
                UserId = Guid.Parse("{925433D2-557E-45EE-8D84-017918A2D760}"),
                Name = "To read"
            });

            modelBuilder.Entity<ShelfBook>().HasData(new ShelfBook
            {
                Id = Guid.Parse("{CF909B3A-01CE-4C9F-A3E9-5740A298378D}"),
                ShelfId = Guid.Parse("{D7A45328-D6F1-4998-A93A-4785CDD415D2}"),
                BookId = Guid.Parse("{BB76804E-2E80-4A1B-9015-D22B0AB7AA13}")
            });

            modelBuilder.Entity<ShelfBook>().HasData(new ShelfBook
            {
                Id = Guid.Parse("{77871A16-60A9-495F-AB45-A5A1DE113418}"),
                ShelfId = Guid.Parse("{7022434D-0913-42E5-98AD-1DB0F1A45DD4}"),
                BookId = Guid.Parse("{B014368A-98EF-42C9-95F9-1DFE50501085}")
            });


        }

    }
}
