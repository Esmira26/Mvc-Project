using System;
using System.Collections.Generic;

namespace WebApplication20.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public int? UserPhone { get; set; }

    public string? UserEmail { get; set; }

    public string? UserPassword { get; set; }

    public int? UserTelefonId { get; set; }

    public int? UserStatusId { get; set; }

    public virtual ICollection<Lofe> Loves { get; set; } = new List<Lofe>();

    public virtual ICollection<Sebet> Sebets { get; set; } = new List<Sebet>();

    public virtual Status? UserStatus { get; set; }

    public virtual Telefon? UserTelefon { get; set; }
}
