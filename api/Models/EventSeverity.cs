using System;
using System.Collections.Generic;

namespace api.Models;

public partial class EventSeverity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int SortedOrder { get; set; }

    public virtual ICollection<EventType> EventTypes { get; set; } = new List<EventType>();
}
