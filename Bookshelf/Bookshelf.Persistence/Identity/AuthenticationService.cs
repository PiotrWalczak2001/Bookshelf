using Bookshelf.Application.Contracts.Persistence.Identity;
using Bookshelf.Application.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Bookshelf.Persistence.Identity
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthenticationService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<AuthenticationResponse> AuthenticateUserAsync(AuthenticationRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if(user == null)
            {
                throw new Exception("User not found.");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            if(!result.Succeeded)
            {
                throw new Exception("Something went wrong");
            }

            AuthenticationResponse response = new() 
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName
            };

            return response;
        }

        public async Task<RegisterResponse> RegisterUserAsync(RegisterRequest request)
        {
            var alreadyExistingUser = await _userManager.FindByNameAsync(request.UserName);
            var alreadyExistingEmail = await _userManager.FindByEmailAsync(request.Email);

            if(alreadyExistingUser != null)
            {
                throw new Exception("This username is already taken.");
            }
            var user = new ApplicationUser
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                EmailConfirmed = true
            };

            if(alreadyExistingEmail != null)
            {
                throw new Exception("This email is already taken.");
            }
            else
            {
                var result = await _userManager.CreateAsync(user, request.Password);
                if(result.Succeeded)
                {
                    return new RegisterResponse() { UserId = user.Id };
                }
                else
                {
                    throw new Exception($"{result.Errors}");
                }
            }
        }
    }
}
