using System;
using System.Collections.Generic;

namespace api.Models;

public partial class SalePaymentMethod
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
