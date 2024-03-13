using System;
using System.Collections.Generic;

namespace WebApplication20.Models;

public partial class Telefon
{
    public int TelefonId { get; set; }

    public int? TelefonHead { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
