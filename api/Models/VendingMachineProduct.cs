using System;
using System.Collections.Generic;

namespace api.Models;

public partial class VendingMachineProduct
{
    public int VendingMachineId { get; set; }

    public int ProductId { get; set; }

    public int QuantityOnHand { get; set; }

    public int MinimumStock { get; set; }

    public int AverageDailySales { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual VendingMachineEvent VendingMachine { get; set; } = null!;
}
