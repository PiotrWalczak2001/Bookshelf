using System;

namespace Bookshelf.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime Modified { get; set; }
    }
}
