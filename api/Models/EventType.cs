using System;
using System.Collections.Generic;

namespace api.Models;

public partial class EventType
{
    public int Id { get; set; }

    public int EventSeverityId { get; set; }

    public string Name { get; set; } = null!;

    public virtual EventSeverity EventSeverity { get; set; } = null!;

    public virtual ICollection<VendingMachineEvent> VendingMachineEvents { get; set; } = new List<VendingMachineEvent>();
}
