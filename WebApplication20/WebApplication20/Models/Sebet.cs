using System;
using System.Collections.Generic;

namespace WebApplication20.Models;

public partial class Sebet
{
    public int SebetId { get; set; }

    public int? SebetMehsulCount { get; set; }

    public int? SebetMehsulId { get; set; }

    public int? SebetUserId { get; set; }

    public virtual Mehsul? SebetMehsul { get; set; }

    public virtual User? SebetUser { get; set; }
}
