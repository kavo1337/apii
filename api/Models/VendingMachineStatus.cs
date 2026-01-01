using System;
using System.Collections.Generic;

namespace api.Models;

public partial class VendingMachineStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int SortOrder { get; set; }

    public virtual ICollection<VendingMachine> VendingMachines { get; set; } = new List<VendingMachine>();
}
