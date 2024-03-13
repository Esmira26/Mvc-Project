using System;
using System.Collections.Generic;

namespace WebApplication20.Models;

public partial class Lofe
{
    public int LoveId { get; set; }

    public int? LoveMehsulId { get; set; }

    public int? LoveUserId { get; set; }

    public virtual Mehsul? LoveMehsul { get; set; }

    public virtual User? LoveUser { get; set; }
}
