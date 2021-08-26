using Bookshelf.App.Contracts;
using Bookshelf.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bookshelf.App.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        public AuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> AuthenticateUser(UserAuthenticateViewModel userLogin)
        {
            var userToAuthenticate = new StringContent(JsonSerializer.Serialize(userLogin), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("account/authenticate", userToAuthenticate);
            
            if(response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> RegisterUser(UserRegisterViewModel userRegister)
        {
            var userToRegisterJson = new StringContent(JsonSerializer.Serialize(userRegister), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("account/register", userToRegisterJson);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
