using Bookshelf.App.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bookshelf.App.Pages
{
    public partial class Test
    {
       public string PassedDataDto { get; set; }
        [Inject]
        public IGetTestDataService getTestDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            PassedDataDto = await getTestDataService.GetData();
        }
    }
}
