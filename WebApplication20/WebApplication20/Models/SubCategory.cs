using System;
using System.Collections.Generic;

namespace WebApplication20.Models;

public partial class SubCategory
{
    public int SubCategoryId { get; set; }

    public string? SubCategoryName { get; set; }

    public int? SubCategoryCategoryId { get; set; }

    public virtual ICollection<Mehsul> Mehsuls { get; set; } = new List<Mehsul>();

    public virtual Category? SubCategoryCategory { get; set; }
}
