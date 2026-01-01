using System;
using System.Collections.Generic;

namespace api.Models;

public partial class UserRole
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<UserAccount> UserAccounts { get; set; } = new List<UserAccount>();
}
