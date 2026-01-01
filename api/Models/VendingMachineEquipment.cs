using System;
using System.Collections.Generic;

namespace api.Models;

public partial class VendingMachineEquipment
{
    public int Id { get; set; }

    public int EquipmentTypeId { get; set; }

    public bool IsOperational { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual EquipmentType EquipmentType { get; set; } = null!;
}
