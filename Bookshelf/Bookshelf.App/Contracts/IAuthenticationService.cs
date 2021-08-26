using Bookshelf.App.ViewModels;
using System.Threading.Tasks;

namespace Bookshelf.App.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateUser(UserAuthenticateViewModel userLogin);
        Task<bool> RegisterUser(UserRegisterViewModel userRegister);
    }
}
