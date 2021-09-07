using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.App.ViewModels
{
    public class ShelfDetailViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public ICollection<ShelfBookViewModel> ShelfBooks { get; set; }
    }
}
