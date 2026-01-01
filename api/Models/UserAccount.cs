using System;
using System.Collections.Generic;

namespace api.Models;

public partial class UserAccount
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public string PasswordHash { get; set; } = null!;

    public string PasswordSalt { get; set; } = null!;

    public string PhotoUrl { get; set; } = null!;

    public int CompanyId { get; set; }

    public int UserRoleId { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual UserRole UserRole { get; set; } = null!;

    public virtual ICollection<VendingMachine> VendingMachineEngineerUserAccounts { get; set; } = new List<VendingMachine>();

    public virtual ICollection<VendingMachine> VendingMachineLastVerificationUserAccounts { get; set; } = new List<VendingMachine>();

    public virtual ICollection<VendingMachine> VendingMachineManagerUserAccounts { get; set; } = new List<VendingMachine>();

    public virtual ICollection<VendingMachine> VendingMachineTechnicianOperatorUserAccounts { get; set; } = new List<VendingMachine>();
}
