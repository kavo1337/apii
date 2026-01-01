using System;
using System.Collections.Generic;

namespace api.Models;

public partial class VendingMachineEvent
{
    public int Id { get; set; }

    public int VendingMachineId { get; set; }

    public int EventTypeId { get; set; }

    public DateTime CreateAt { get; set; }

    public string Description { get; set; } = null!;

    public virtual EventType EventType { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual VendingMachine VendingMachine { get; set; } = null!;

    public virtual ICollection<VendingMachineProduct> VendingMachineProducts { get; set; } = new List<VendingMachineProduct>();
}
