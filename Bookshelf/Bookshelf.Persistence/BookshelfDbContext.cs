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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<ShelfBook> ShelfBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookshelfDbContext).Assembly);

            modelBuilder.Entity<Category>().HasData(new Category {
                Id = Guid.Parse("10EB0FDB-75B4-4C33-AE6A-D07721164738"),
                Name = "Fantasy"
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = Guid.Parse("B86DC9BD-460D-4B39-B9F1-7E7DB294D89C"),
                Name = "Crime"
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = Guid.Parse("C3F33488-8D6C-4323-918E-257818F73FD8"),
                Name = "Biography"
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = Guid.Parse("CAC47B25-478E-451B-A921-02A8F1E2D3D0"),
                Name = "Romance"
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = Guid.Parse("{BB76804E-2E80-4A1B-9015-D22B0AB7AA13}"),
                Title = "The Last Wish",
                Author = "Andrzej Sapkowski",
                Description = "The Last Wish - is the first (in its fictional chronology; published second in original Polish) of the two collections of short stories (the other being Sword of Destiny) preceding the main Witcher Saga, written by Polish fantasy writer Andrzej Sapkowski.",
                CoverImageUrl = "https://cdn.pixabay.com/photo/2017/05/03/21/16/book-2282152_960_720.png",
                CategoryId = Guid.Parse("10EB0FDB-75B4-4C33-AE6A-D07721164738")
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = Guid.Parse("{B014368A-98EF-42C9-95F9-1DFE50501085}"),
                Title = "Sword of Destiny",
                Author = "Andrzej Sapkowski",
                Description = "is the second (in its fictional chronology; first in Polish print) of the two collections of short stories (the other being The Last Wish), both preceding the main Witcher Saga. The stories were written by Polish fantasy author Andrzej Sapkowski.",
                CoverImageUrl = "https://cdn.pixabay.com/photo/2017/05/03/21/16/book-2282152_960_720.png",
                CategoryId = Guid.Parse("10EB0FDB-75B4-4C33-AE6A-D07721164738")
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = Guid.Parse("{DC0D3909-1D27-4E1C-AB08-67FEE5985F65}"),
                Title = "Book1",
                Author = "Author1",
                Description = "Description1",
                CoverImageUrl = "https://cdn.pixabay.com/photo/2017/05/03/21/16/book-2282152_960_720.png",
                CategoryId = Guid.Parse("B86DC9BD-460D-4B39-B9F1-7E7DB294D89C")
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = Guid.Parse("{4873F223-2F4A-4A47-BE34-16F9E997B247}"),
                Title = "Book2",
                Author = "Author1",
                Description = "Description2",
                CoverImageUrl = "https://cdn.pixabay.com/photo/2017/05/03/21/16/book-2282152_960_720.png",
                CategoryId = Guid.Parse("C3F33488-8D6C-4323-918E-257818F73FD8")
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = Guid.Parse("{CCCFCA1C-016C-4D3E-BA83-A1621E42CEA0}"),
                Title = "Book3",
                Author = "Author2",
                Description = "Description3",
                CoverImageUrl = "https://cdn.pixabay.com/photo/2017/05/03/21/16/book-2282152_960_720.png",
                CategoryId = Guid.Parse("CAC47B25-478E-451B-A921-02A8F1E2D3D0")
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
                BookId = Guid.Parse("{BB76804E-2E80-4A1B-9015-D22B0AB7AA13}"),
                Title = "The Last Wish",
                Author = "Andrzej Sapkowski",
                CoverImageUrl = "https://cdn.pixabay.com/photo/2017/05/03/21/16/book-2282152_960_720.png"
            });

            modelBuilder.Entity<ShelfBook>().HasData(new ShelfBook
            {
                Id = Guid.Parse("{77871A16-60A9-495F-AB45-A5A1DE113418}"),
                ShelfId = Guid.Parse("{7022434D-0913-42E5-98AD-1DB0F1A45DD4}"),
                BookId = Guid.Parse("{B014368A-98EF-42C9-95F9-1DFE50501085}"),
                Title = "Sword of Destiny",
                Author = "Andrzej Sapkowski",
                CoverImageUrl = "https://cdn.pixabay.com/photo/2017/05/03/21/16/book-2282152_960_720.png"
            });



            modelBuilder.Entity<ShelfBook>().HasData(new ShelfBook
            {
                Id = Guid.Parse("{8AAD8E9A-3982-4EDA-8257-084E5216C02F}"),
                ShelfId = Guid.Parse("{D7A45328-D6F1-4998-A93A-4785CDD415D2}"),
                BookId = Guid.Parse("{DC0D3909-1D27-4E1C-AB08-67FEE5985F65}"),
                Title = "Book1",
                Author = "Author1",
                CoverImageUrl = "https://cdn.pixabay.com/photo/2017/05/03/21/16/book-2282152_960_720.png"
            });

            modelBuilder.Entity<ShelfBook>().HasData(new ShelfBook
            {
                Id = Guid.Parse("{EE38899D-A6F4-49FC-835E-BC1D0F0A7997}"),
                ShelfId = Guid.Parse("{D7A45328-D6F1-4998-A93A-4785CDD415D2}"),
                BookId = Guid.Parse("{4873F223-2F4A-4A47-BE34-16F9E997B247}"),
                Title = "Book2",
                Author = "Author1",
                CoverImageUrl = "https://cdn.pixabay.com/photo/2017/05/03/21/16/book-2282152_960_720.png"
            });

            modelBuilder.Entity<ShelfBook>().HasData(new ShelfBook
            {
                Id = Guid.Parse("{AFBFC8D5-FE04-4E7A-A339-E0F43144321F}"),
                ShelfId = Guid.Parse("{7022434D-0913-42E5-98AD-1DB0F1A45DD4}"),
                BookId = Guid.Parse("{DC0D3909-1D27-4E1C-AB08-67FEE5985F65}"),
                Title = "Book1",
                Author = "Author1",
                CoverImageUrl = "https://cdn.pixabay.com/photo/2017/05/03/21/16/book-2282152_960_720.png"
            });
            modelBuilder.Entity<ShelfBook>().HasData(new ShelfBook
            {
                Id = Guid.Parse("{4D5D90DA-9D71-4145-B7DE-BA95CD078915}"),
                ShelfId = Guid.Parse("{7022434D-0913-42E5-98AD-1DB0F1A45DD4}"),
                BookId = Guid.Parse("{CCCFCA1C-016C-4D3E-BA83-A1621E42CEA0}"),
                Title = "Book3",
                Author = "Author2",
                CoverImageUrl = "https://cdn.pixabay.com/photo/2017/05/03/21/16/book-2282152_960_720.png"
            });


        }

    }
}
