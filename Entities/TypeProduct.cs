using System;
using System.Collections.Generic;

namespace Entities;

    public partial class TypeProduct
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public virtual ICollection<Product> Products { get; } = new List<Product>();
    }
