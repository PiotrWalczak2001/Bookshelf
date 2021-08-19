using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Persistence.Identity;
using Bookshelf.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
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
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<BookshelfDbContext>();

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IShelfRepository, ShelfRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
