using System;
using System.Collections.Generic;

namespace WebApplication20.Models;

public partial class Mehsul
{
    public int MehsulId { get; set; }

    public string? MehsulAd { get; set; }

    public string? MehsulSekil { get; set; }

    public int? MehsulQiymeti { get; set; }

    public string? MehsulunKodu { get; set; }

    public int? MehsulCategoryId { get; set; }

    public string? MehsulStatus { get; set; }

    public string? MehsulFlower { get; set; }

    public int? MehsulSubCategoryId { get; set; }

    public string? MehsulLove { get; set; }

    public virtual ICollection<Lofe> Loves { get; set; } = new List<Lofe>();

    public virtual Category? MehsulCategory { get; set; }

    public virtual SubCategory? MehsulSubCategory { get; set; }

    public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();

    public virtual ICollection<Sebet> Sebets { get; set; } = new List<Sebet>();
}
