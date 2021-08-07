﻿using Bookshelf.Domain.Entities;

namespace Bookshelf.Application.Contracts.Persistence
{
    public interface IBookRepository : IAsyncRepository<Book>
    {
    }
}
