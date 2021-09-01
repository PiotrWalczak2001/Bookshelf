using Bookshelf.Application.Contracts.Persistence.Identity;
using Bookshelf.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bookshelf.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateUserAsync(AuthenticationRequest request)
        {
            return Ok(await _authenticationService.AuthenticateUserAsync(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponse>> RegisterUserAsync(RegisterRequest request)
        {
            return Ok(await _authenticationService.RegisterUserAsync(request));
        }
    }
}
