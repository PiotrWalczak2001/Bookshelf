using Bookshelf.App.Contracts;
using Bookshelf.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.App.Pages
{
    public partial class Register
    {
        public UserRegisterViewModel UserRegisterViewModel { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Message { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        protected override void OnInitialized()
        {
            UserRegisterViewModel = new();
        }

        protected async void HandleValidSubmit()
        {
            var result = await AuthenticationService.RegisterUser(UserRegisterViewModel);
            if(result)
            {
                NavigationManager.NavigateTo("bookslist");
            }
            Message = "Nah! Something went wrong :(";
        }
    }
}
