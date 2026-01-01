using System;
using System.Collections.Generic;

namespace api.Models;

public partial class CriticalValuesTemplate
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<VendingMachine> VendingMachines { get; set; } = new List<VendingMachine>();
}
