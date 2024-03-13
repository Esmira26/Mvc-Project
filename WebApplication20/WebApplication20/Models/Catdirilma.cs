using System;
using System.Collections.Generic;

namespace WebApplication20.Models;

public partial class Catdirilma
{
    public int CatdirilmaId { get; set; }

    public string? CatdirilmaAd { get; set; }

    public virtual ICollection<Musteri> Musteris { get; set; } = new List<Musteri>();
}
