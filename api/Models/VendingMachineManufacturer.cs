using System;
using System.Collections.Generic;

namespace api.Models;

public partial class VendingMachineManufacturer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<VendingMachineModel> VendingMachineModels { get; set; } = new List<VendingMachineModel>();
}
