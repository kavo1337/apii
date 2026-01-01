using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Maintenance
{
    public int Id { get; set; }

    public int VendingMachineId { get; set; }

    public DateOnly MaintenanceDate { get; set; }

    public string Description { get; set; } = null!;

    public string Problems { get; set; } = null!;

    public int ExecutorUserId { get; set; }

    public int CreateAt { get; set; }

    public virtual UserAccount ExecutorUser { get; set; } = null!;

    public virtual VendingMachine VendingMachine { get; set; } = null!;
}
