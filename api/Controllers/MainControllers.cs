using api.DTO;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;

namespace api.Controller;

[Controller]
[Route("/api")]
public class MainControllers : ControllerBase
{
    private readonly TestContext _dbContext;
    public MainControllers(TestContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("payment-system")]
    public async Task<IActionResult> GetPaymentSystems(CancellationToken cancellationToken)
    {
        var items = await _dbContext.PaymentSystems
            .AsNoTracking()
            .OrderBy(item => item.Id)
            .ToListAsync(cancellationToken);

        return Ok(items);
    }
    [HttpPost("vending-machine")]
    public async Task<IActionResult> CreateVendingMachine(VendingMachineDTO input, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(input.Name))
            return BadRequest("Name is required");
        if (string.IsNullOrWhiteSpace(input.Address))
            return BadRequest("Address is required");
        if (string.IsNullOrWhiteSpace(input.Place))
            return BadRequest("Place is required");
        if (string.IsNullOrWhiteSpace(input.KitOnlineCashRegisterId))
            return BadRequest("KitOnlineCashRegisterId is required");
        if (string.IsNullOrWhiteSpace(input.Notes))
            return BadRequest("Notes is required");
            
        var vendingMachineModel = await _dbContext.VendingMachineModels
            .AnyAsync(x => x.Id == input.VendingMachineModelID, cancellationToken);
        if (!vendingMachineModel)
            return BadRequest($"VendingMachineModel with ID {input.VendingMachineModelID} not found");

        var workMode = await _dbContext.WorkModes
            .AnyAsync(x => x.Id == input.WorkModelID, cancellationToken);
        if (!workMode)
            return BadRequest($"WorkMode with ID {input.WorkModelID} not found");

        var timeZone = await _dbContext.TimeZoneIds
            .AnyAsync(x => x.Id == input.TimeZoneID, cancellationToken);
        if (!timeZone)
            return BadRequest($"TimeZoneId with ID {input.TimeZoneID} not found");

        var status = await _dbContext.VendingMachineStatuses
            .AnyAsync(x => x.Id == input.VendingMachineStatusID, cancellationToken);
        if (!status)
            return BadRequest($"VendingMachineStatus with ID {input.VendingMachineStatusID} not found");

        var company = await _dbContext.Companies
            .AnyAsync(x => x.Id == input.CompanyID, cancellationToken);
        if (!company)
            return BadRequest($"Company with ID {input.CompanyID} not found");

        var modem = await _dbContext.Modems
            .AnyAsync(x => x.Id == input.ModemID, cancellationToken);
        if (!modem)
            return BadRequest($"Modem with ID {input.ModemID} not found");

        var productMatrix = await _dbContext.ProductMatrices
            .AnyAsync(x => x.Id == input.ProductMatrixID, cancellationToken);
        if (!productMatrix)
            return BadRequest($"ProductMatrix with ID {input.ProductMatrixID} not found");

        var country = await _dbContext.Countries
            .AnyAsync(x => x.Id == input.CountryId, cancellationToken);
        if (!country)
            return BadRequest($"Country with ID {input.CountryId} not found");

        var entity = new VendingMachine
        {
            Name = input.Name,
            VendingMachineModelId = input.VendingMachineModelID,
            WorkModelId = input.WorkModelID,
            TimeZoneId = input.TimeZoneID,
            VendingMachineStatusId = input.VendingMachineStatusID,
            ServicePriority = input.ServicePriority,
            ProductMatrixId = input.ProductMatrixID,
            CompanyId = input.CompanyID,
            ModemId = input.ModemID,
            Address = input.Address,
            Place = input.Place,
            Latitude = input.Latitude,
            Longitude = input.Longitude,
            InventoryNumber = input.InventoryNumber,
            SerialNumber = input.SerialNumber,
            ManufactureDate = input.ManufactureDate,
            CommissioningDate = input.CommissioningDate,
            LastVerificationDate = input.LastVerificationDate,
            VerificationIntervalMonths = input.VerificationIntervalMonths,
            NextVerificationDate = input.NextVerificationDate,
            ResourceHours = input.ResourceHours,
            NextServiceDate = input.NextServiceDate,
            ServiceDurationHours = input.ServiceDurationHours,
            InventoryDate = input.InventoryDate,
            CountryId = input.CountryId,
            LastVerificationUserAccountId = input.LastVerificationUserAccountId,
            WorkingTimeFrom = input.WorkingTimeFrom,
            WorkingTimeTo = input.WorkingTimeTo,
            CriticalValuesTemplateId = input.CriticalValuesTemplateId,
            NotificationTemplateId = input.NotificationTemplateId,
            ManagerUserAccountId = input.ManagerUserAccountId,
            EngineerUserAccountId = input.EngineerUserAccountId,
            TechnicianOperatorUserAccountId = input.TechnicianOperatorUserAccountId,
            KitOnlineCashRegisterId = input.KitOnlineCashRegisterId,
            Notes = input.Notes,
            CreateAt = DateTime.UtcNow
        };

        _dbContext.VendingMachines.Add(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Ok(entity);
    }

    [HttpGet("vending-machine/{id}")]
    public async Task<IActionResult> GetVendingMachine(int id, CancellationToken cancellationToken)
    {
        var item = await _dbContext.VendingMachines
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (item == null)
            return NotFound();

        return Ok(item);
    }

    [HttpPut("vending-machine/{id}")]
    public async Task<IActionResult> UpdateVendingMachine(int id, VendingMachineDTO input, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.VendingMachines
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
            return NotFound();

        entity.Name = input.Name;
        entity.VendingMachineModelId = input.VendingMachineModelID;
        entity.WorkModelId = input.WorkModelID;
        entity.TimeZoneId = input.TimeZoneID;
        entity.VendingMachineStatusId = input.VendingMachineStatusID;
        entity.ServicePriority = input.ServicePriority;
        entity.ProductMatrixId = input.ProductMatrixID;
        entity.CompanyId = input.CompanyID;
        entity.ModemId = input.ModemID;
        entity.Address = input.Address;
        entity.Place = input.Place;
        entity.Latitude = input.Latitude;
        entity.Longitude = input.Longitude;
        entity.InventoryNumber = input.InventoryNumber;
        entity.SerialNumber = input.SerialNumber;
        entity.ManufactureDate = input.ManufactureDate;
        entity.CommissioningDate = input.CommissioningDate;
        entity.LastVerificationDate = input.LastVerificationDate;
        entity.VerificationIntervalMonths = input.VerificationIntervalMonths;
        entity.NextVerificationDate = input.NextVerificationDate;
        entity.ResourceHours = input.ResourceHours;
        entity.NextServiceDate = input.NextServiceDate;
        entity.ServiceDurationHours = input.ServiceDurationHours;
        entity.InventoryDate = input.InventoryDate;
        entity.CountryId = input.CountryId;
        entity.LastVerificationUserAccountId = input.LastVerificationUserAccountId;
        entity.WorkingTimeFrom = input.WorkingTimeFrom;
        entity.WorkingTimeTo = input.WorkingTimeTo;
        entity.CriticalValuesTemplateId = input.CriticalValuesTemplateId;
        entity.NotificationTemplateId = input.NotificationTemplateId;
        entity.ManagerUserAccountId = input.ManagerUserAccountId;
        entity.EngineerUserAccountId = input.EngineerUserAccountId;
        entity.TechnicianOperatorUserAccountId = input.TechnicianOperatorUserAccountId;
        entity.KitOnlineCashRegisterId = input.KitOnlineCashRegisterId;
        entity.Notes = input.Notes;

        await _dbContext.SaveChangesAsync(cancellationToken);
        return Ok(entity);
    }

    [HttpDelete("vending-machine/{id}")]
    public async Task<IActionResult> DeleteVendingMachine(int id, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.VendingMachines
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
            return NotFound();

        _dbContext.VendingMachines.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return NoContent();
    }
    [HttpPost("payment-system")]
    public async Task<IActionResult> CreatePaymentSystem(PaymentSystemDTO input, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(input.Name))
            return BadRequest("Name is required");

        var entity = new PaymentSystem
        {
            Name = input.Name
        };

        _dbContext.PaymentSystems.Add(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Ok(entity);
    }

    [HttpPut("payment-system/{id}")]
    public async Task<IActionResult> UpdatePaymentSystem(int id, PaymentSystemDTO input, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.PaymentSystems
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
            return NotFound();

        if (string.IsNullOrWhiteSpace(input.Name))
            return BadRequest("Name is required");

        entity.Name = input.Name;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Ok(entity);
    }

    [HttpDelete("payment-system/{id}")]
    public async Task<IActionResult> DeletePaymentSystem(int id, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.PaymentSystems
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
            return NotFound();

        _dbContext.PaymentSystems.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    [HttpGet("product")]
    public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
    {
        var items = await _dbContext.Products
            .AsNoTracking()
            .OrderBy(item => item.Id)
            .ToListAsync(cancellationToken);

        return Ok(items);
    }

    [HttpGet("product/{id}")]
    public async Task<IActionResult> GetProduct(int id, CancellationToken cancellationToken)
    {
        var item = await _dbContext.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (item == null)
            return NotFound();

        return Ok(item);
    }

    [HttpPost("product")]
    public async Task<IActionResult> CreateProduct(ProductDTO input, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(input.Name))
            return BadRequest("Name is required");
        if (string.IsNullOrWhiteSpace(input.Description))
            return BadRequest("Description is required");

        var entity = new Product
        {
            Name = input.Name,
            Description = input.Description,
            Price = input.Price,
            CreateAt = DateTime.UtcNow
        };

        _dbContext.Products.Add(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Ok(entity);
    }

    [HttpPut("product/{id}")]
    public async Task<IActionResult> UpdateProduct(int id, ProductDTO input, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Products
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
            return NotFound();

        if (string.IsNullOrWhiteSpace(input.Name))
            return BadRequest("Name is required");
        if (string.IsNullOrWhiteSpace(input.Description))
            return BadRequest("Description is required");

        entity.Name = input.Name;
        entity.Description = input.Description;
        entity.Price = input.Price;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Ok(entity);
    }

    [HttpDelete("product/{id}")]
    public async Task<IActionResult> DeleteProduct(int id, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Products
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
            return NotFound();

        _dbContext.Products.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    [HttpGet("company")]
    public async Task<IActionResult> GetCompanies(CancellationToken cancellationToken)
    {
        var items = await _dbContext.Companies
            .AsNoTracking()
            .OrderBy(item => item.Id)
            .ToListAsync(cancellationToken);

        return Ok(items);
    }

    [HttpGet("company/{id}")]
    public async Task<IActionResult> GetCompany(int id, CancellationToken cancellationToken)
    {
        var item = await _dbContext.Companies
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (item == null)
            return NotFound();

        return Ok(item);
    }

    [HttpPost("company")]
    public async Task<IActionResult> CreateCompany(CompanyDTO input, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(input.Name))
            return BadRequest("Name is required");
        if (string.IsNullOrWhiteSpace(input.Phone))
            return BadRequest("Phone is required");
        if (string.IsNullOrWhiteSpace(input.Address))
            return BadRequest("Address is required");

        var entity = new Company
        {
            Name = input.Name,
            Phone = input.Phone,
            Email = input.Email,
            Address = input.Address,
            CreateAt = DateTime.UtcNow
        };

        _dbContext.Companies.Add(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Ok(entity);
    }

    [HttpPut("company/{id}")]
    public async Task<IActionResult> UpdateCompany(int id, CompanyDTO input, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Companies
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
            return NotFound();

        if (string.IsNullOrWhiteSpace(input.Name))
            return BadRequest("Name is required");
        if (string.IsNullOrWhiteSpace(input.Phone))
            return BadRequest("Phone is required");
        if (string.IsNullOrWhiteSpace(input.Address))
            return BadRequest("Address is required");

        entity.Name = input.Name;
        entity.Phone = input.Phone;
        entity.Email = input.Email;
        entity.Address = input.Address;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Ok(entity);
    }

    [HttpDelete("company/{id}")]
    public async Task<IActionResult> DeleteCompany(int id, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Companies
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
            return NotFound();

        _dbContext.Companies.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return NoContent();
    }
    
}