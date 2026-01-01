namespace api.DTO;


public class VendingMachineDTO
{
    public string Name { get; set; }
    public string Location { get; set; }
    public int VendingMachineModelID { get; set; }
    public int WorkModelID { get; set; }
    public int TimeZoneID { get; set; }
    public int VendingMachineStatusID { get; set; }
    public int ServicePriority { get; set; }
    public int ProductMatrixID { get; set; }
    public int CompanyID { get; set; }
    public int ModemID { get; set; }
    public string Address { get; set; }
    public string Place { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public int InventoryNumber { get; set; }
    public int SerialNumber { get; set; }
    public DateOnly ManufactureDate { get; set; }
    public DateOnly CommissioningDate { get; set; }
    public DateOnly LastVerificationDate { get; set; }
    public int VerificationIntervalMonths { get; set; }
    public DateOnly NextVerificationDate { get; set; }
    public int ResourceHours {  get; set; }
    public DateOnly NextServiceDate { get; set; }
    public int ServiceDurationHours { get; set; }
    public DateOnly InventoryDate {  get; set; }
    public int CountryId { get; set; }
    public int LastVerificationUserAccountId { get; set; }
    public TimeOnly WorkingTimeFrom { get; set; }
    public TimeOnly WorkingTimeTo { get; set; }
    public int CriticalValuesTemplateId { get; set; }
    public int NotificationTemplateId { get; set; }
    public int ManagerUserAccountId { get; set; }
    public int EngineerUserAccountId { get; set; }
    public int TechnicianOperatorUserAccountId { get; set; }
    public string KitOnlineCashRegisterId { get; set; }
    public string Notes { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}