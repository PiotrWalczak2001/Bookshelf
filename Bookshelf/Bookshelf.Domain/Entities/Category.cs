﻿using Bookshelf.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
    }
}
