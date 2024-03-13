using System;
using System.Collections.Generic;

namespace WebApplication20.Models;

public partial class Musteri
{
    public int MusteriId { get; set; }

    public string? MusteriAd { get; set; }

    public string? MusteriTel { get; set; }

    public string? MusteriQeyd { get; set; }

    public string? MusteriKarti { get; set; }

    public string? MusteriKartTarixi { get; set; }

    public int? MusteriKartKodu { get; set; }

    public int? MusteriCatdirilmaId { get; set; }

    public virtual Catdirilma? MusteriCatdirilma { get; set; }
}
