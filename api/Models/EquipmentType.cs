using System;
using System.Collections.Generic;

namespace api.Models;

public partial class EquipmentType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<VendingMachineEquipment> VendingMachineEquipments { get; set; } = new List<VendingMachineEquipment>();
}
