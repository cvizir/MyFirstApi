using System;
using System.Collections.Generic;

namespace MyFirstApi.Models;

public partial class Product1
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }
}
