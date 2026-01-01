using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Sale
{
    public int Id { get; set; }

    public int VendingMachineId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime SoldAt { get; set; }

    public int SalePaymentMethodId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual SalePaymentMethod SalePaymentMethod { get; set; } = null!;

    public virtual VendingMachineEvent VendingMachine { get; set; } = null!;
}
