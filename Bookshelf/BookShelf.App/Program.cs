using Blazored.LocalStorage;
using BookShelf.App.Auth;
using BookShelf.App.Contracts;
using BookShelf.App.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookShelf.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

            var host = new Uri("https://localhost:44307");

            builder.Services.AddHttpClient<IBookService, BookService>(client => client.BaseAddress = new Uri(host, "api/book"));
            builder.Services.AddHttpClient<ICategoryService, CategoryService>(client => client.BaseAddress = new Uri(host, "api/category"));
            builder.Services.AddHttpClient<IShelfService, ShelfService>(client => client.BaseAddress = new Uri(host, "api/shelf"));
            builder.Services.AddHttpClient<IAuthenticationService, AuthenticationService>(client => client.BaseAddress = new Uri(host, "api/account"));

            await builder.Build().RunAsync();
        }
    }
}
