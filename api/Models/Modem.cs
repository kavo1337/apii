using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Modem
{
    public int Id { get; set; }

    public string ModemNumber { get; set; } = null!;

    public string Imei { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public int ProviderId { get; set; }

    public int ConnectedTypeId { get; set; }

    public string Description { get; set; } = null!;

    public DateTime CreateAt { get; set; }

    public virtual ConnectedType ConnectedType { get; set; } = null!;

    public virtual Provider Provider { get; set; } = null!;

    public virtual ICollection<VendingMachine> VendingMachines { get; set; } = new List<VendingMachine>();
}
