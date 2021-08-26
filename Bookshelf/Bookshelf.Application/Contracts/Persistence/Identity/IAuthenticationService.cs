using Bookshelf.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Application.Contracts.Persistence.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateUserAsync(AuthenticationRequest request);
        Task<RegisterResponse> RegisterUserAsync(RegisterRequest request);
    }
}
