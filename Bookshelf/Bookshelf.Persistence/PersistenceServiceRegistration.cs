using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bookshelf.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookshelfDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("BookshelfConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IShelfRepository, ShelfRepository>();
            services.AddScoped<IShelfBookRepository, ShelfBookRepository>();

            return services;
        }
    }
}
