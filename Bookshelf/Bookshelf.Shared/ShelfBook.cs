﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Shared
{
    class ShelfBook
    {
        public Guid Id { get; set; }
        public Guid ShelfId { get; set; }
        public Guid BookId { get; set; }
    }
}
