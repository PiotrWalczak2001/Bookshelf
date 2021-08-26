using Bookshelf.App.Contracts;
using Bookshelf.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.App.Pages
{
    public partial class Login
    {
        public UserAuthenticateViewModel UserAuthenticateViewModel { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Message { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        protected override void OnInitialized()
        {
            UserAuthenticateViewModel = new();
        }

        protected async void HandleValidSubmit()
        {
            if(await AuthenticationService.AuthenticateUser(UserAuthenticateViewModel))
            {
                NavigationManager.NavigateTo("bookslist");
            }
            Message = "Nah! Something went wrong :(";
            //
        }
    }
}
