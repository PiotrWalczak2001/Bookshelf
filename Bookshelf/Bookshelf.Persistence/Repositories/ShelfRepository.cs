using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Persistence.Repositories
{
    public class ShelfRepository : BaseRepository<Shelf>, IShelfRepository
    {
        public ShelfRepository(BookshelfDbContext dbContext) : base(dbContext)
        {
        }


        public async Task<IEnumerable<ShelfBook>> GetAllBooksFromShelf(Guid ShelfId)
        {
            var booksFromShelf = await _dbContext.ShelfBooks.Where(sb => sb.ShelfId == ShelfId).ToListAsync();

            return booksFromShelf;
        }
        public async Task RemoveAllShelfBooks(Guid ShelfId)
        {
            var booksFromShelfToDelete = _dbContext.ShelfBooks.Where(sb => sb.ShelfId == ShelfId);
            foreach (var book in booksFromShelfToDelete)
            {
                _dbContext.ShelfBooks.Remove(book);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddBookToShelf(ShelfBook shelfBook)
        {
            shelfBook.Title = (await _dbContext.Books.FindAsync(shelfBook.BookId)).Title;
            shelfBook.Author = (await _dbContext.Books.FindAsync(shelfBook.BookId)).Author;
            shelfBook.CoverImageUrl = (await _dbContext.Books.FindAsync(shelfBook.BookId)).CoverImageUrl;
            await _dbContext.ShelfBooks.AddAsync(shelfBook);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveBookFromShelf(Guid ShelfBookId)
        {
            _dbContext.ShelfBooks.Remove((await _dbContext.ShelfBooks.FindAsync(ShelfBookId)));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Shelf>> GetAllUserShelves(Guid UserId)
        {
            var userShelves = await _dbContext.Shelves.Where(p => p.UserId == UserId).ToListAsync();
            return userShelves;
        }
    }
}
