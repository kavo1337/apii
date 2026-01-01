using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<VendingMachineProduct> VendingMachineProducts { get; set; } = new List<VendingMachineProduct>();
}
