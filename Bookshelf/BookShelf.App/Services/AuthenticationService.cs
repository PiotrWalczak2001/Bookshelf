using Blazored.LocalStorage;
using Bookshelf.Shared;
using BookShelf.App.Auth;
using BookShelf.App.Contracts;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookShelf.App.Services
{
    public class AuthenticationService : DataService, IAuthenticationService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        public AuthenticationService(HttpClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider) : base(httpClient, localStorage)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            string relativeUri = $"{_httpClient.BaseAddress}/authenticate";
            try
            {
                AuthenticationRequest authenticationRequest = new() { Email = email, Password = password };
                var serializedAuthenticationRequest = new StringContent(JsonSerializer.Serialize(authenticationRequest), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(relativeUri, serializedAuthenticationRequest);
                var authenticationResponse = await JsonSerializer.DeserializeAsync<AuthenticationResponse>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                if (!string.IsNullOrEmpty(authenticationResponse.Token))
                {

                    await _localStorage.SetItemAsync("token", authenticationResponse.Token);
                    ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserAuthenticated(email);
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", authenticationResponse.Token);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Register(string firstName, string lastName, string userName, string email, string password)
        {
            string relativeUri = $"{_httpClient.BaseAddress}/register";

            RegisterRequest registerRequest = new() { FirstName = firstName, LastName = lastName, Email = email, UserName = userName, Password = password };
            var serializedRegisterRequest = new StringContent(JsonSerializer.Serialize(registerRequest), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(relativeUri, serializedRegisterRequest);
            var registerResponse = await JsonSerializer.DeserializeAsync<RegisterResponse>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            if (!string.IsNullOrEmpty(registerResponse.UserId))
            {
                return true;
            }
            return false;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("token");
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
