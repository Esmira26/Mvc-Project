using System;
using System.Collections.Generic;

namespace WebApplication20.Models;

public partial class Photo
{
    public int PhotoId { get; set; }

    public string? PhotoUrl { get; set; }

    public int? PhotoMehsulId { get; set; }

    public virtual Mehsul? PhotoMehsul { get; set; }
}
