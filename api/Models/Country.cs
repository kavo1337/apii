using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string IsoCode { get; set; } = null!;

    public virtual ICollection<VendingMachine> VendingMachines { get; set; } = new List<VendingMachine>();
}
