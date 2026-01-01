using System;
using System.Collections.Generic;

namespace api.Models;

public partial class ConnectedType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Modem> Modems { get; set; } = new List<Modem>();
}
