using Bookshelf.Domain.Common;

namespace Bookshelf.Domain.Entities
{
    public class Shelf : BaseEntity
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public string NumberOfShelfBooks { get; set; }
    }
}
