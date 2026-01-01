using System;
using System.Collections.Generic;

namespace api.Models;

public partial class TimeZoneId
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public short UtsOffsetMinutes { get; set; }

    public virtual ICollection<VendingMachine> VendingMachines { get; set; } = new List<VendingMachine>();
}
