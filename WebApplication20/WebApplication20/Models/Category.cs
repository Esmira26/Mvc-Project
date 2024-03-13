using System;
using System.Collections.Generic;

namespace WebApplication20.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Mehsul> Mehsuls { get; set; } = new List<Mehsul>();

    public virtual ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
}
