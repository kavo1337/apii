using System;
using System.Collections.Generic;

namespace api.Models;

public partial class VendingMachineModel
{
    public int Id { get; set; }

    public int VendingMachineManufacturerId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual VendingMachineManufacturer VendingMachineManufacturer { get; set; } = null!;

    public virtual ICollection<VendingMachine> VendingMachines { get; set; } = new List<VendingMachine>();
}
