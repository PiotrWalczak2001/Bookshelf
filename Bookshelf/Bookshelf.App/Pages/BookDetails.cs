﻿using Bookshelf.App.Services;
using Bookshelf.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.App.Pages
{
    public partial class BookDetails
    {
        [Parameter]
        public string BookId { get; set; }
        public BookDetailsViewModel Book { get; set; } = new();
        [Inject]
        public IBookDataService BookDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Book = await BookDataService.GetBookDetails(Guid.Parse(BookId));
        }
    }
}
