using System;
using System.Collections.Generic;

namespace api.Models;

public partial class VendingMachine
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int VendingMachineModelId { get; set; }

    public int WorkModelId { get; set; }

    public int TimeZoneId { get; set; }

    public int VendingMachineStatusId { get; set; }

    public int ServicePriority { get; set; }

    public int ProductMatrixId { get; set; }

    public int CompanyId { get; set; }

    public int ModemId { get; set; }

    public string Address { get; set; } = null!;

    public string Place { get; set; } = null!;

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public int InventoryNumber { get; set; }

    public int SerialNumber { get; set; }

    public DateOnly ManufactureDate { get; set; }

    public DateOnly CommissioningDate { get; set; }

    public DateOnly LastVerificationDate { get; set; }

    public int VerificationIntervalMonths { get; set; }

    public DateOnly NextVerificationDate { get; set; }

    public int ResourceHours { get; set; }

    public DateOnly NextServiceDate { get; set; }

    public int ServiceDurationHours { get; set; }

    public DateOnly InventoryDate { get; set; }

    public int CountryId { get; set; }

    public int LastVerificationUserAccountId { get; set; }

    public TimeOnly WorkingTimeFrom { get; set; }

    public TimeOnly WorkingTimeTo { get; set; }

    public int CriticalValuesTemplateId { get; set; }

    public int NotificationTemplateId { get; set; }

    public int ManagerUserAccountId { get; set; }

    public int EngineerUserAccountId { get; set; }

    public int TechnicianOperatorUserAccountId { get; set; }

    public string KitOnlineCashRegisterId { get; set; } = null!;

    public string Notes { get; set; } = null!;

    public DateTime CreateAt { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual Country Country { get; set; } = null!;

    public virtual CriticalValuesTemplate CriticalValuesTemplate { get; set; } = null!;

    public virtual UserAccount EngineerUserAccount { get; set; } = null!;

    public virtual UserAccount LastVerificationUserAccount { get; set; } = null!;

    public virtual UserAccount ManagerUserAccount { get; set; } = null!;

    public virtual Modem Modem { get; set; } = null!;

    public virtual NotificationTemplate NotificationTemplate { get; set; } = null!;

    public virtual ProductMatrix ProductMatrix { get; set; } = null!;

    public virtual ServicePrioriry ServicePriorityNavigation { get; set; } = null!;

    public virtual UserAccount TechnicianOperatorUserAccount { get; set; } = null!;

    public virtual TimeZoneId TimeZone { get; set; } = null!;

    public virtual ICollection<VendingMachineEvent> VendingMachineEvents { get; set; } = new List<VendingMachineEvent>();

    public virtual VendingMachineModel VendingMachineModel { get; set; } = null!;

    public virtual VendingMachineStatus VendingMachineStatus { get; set; } = null!;

    public virtual WorkMode WorkModel { get; set; } = null!;

    public virtual ICollection<PaymentSystem> PaymentSystems { get; set; } = new List<PaymentSystem>();
}
