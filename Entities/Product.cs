using System;
using System.Collections.Generic;

namespace Entities;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public int? TypeProductId { get; set; }

    public virtual TypeProduct? TypeProduct { get; set; }
}
