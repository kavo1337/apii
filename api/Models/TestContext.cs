using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<ConnectedType> ConnectedTypes { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<CriticalValuesTemplate> CriticalValuesTemplates { get; set; }

    public virtual DbSet<EquipmentType> EquipmentTypes { get; set; }

    public virtual DbSet<EventSeverity> EventSeverities { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<Maintenance> Maintenances { get; set; }

    public virtual DbSet<Modem> Modems { get; set; }

    public virtual DbSet<NotificationTemplate> NotificationTemplates { get; set; }

    public virtual DbSet<PaymentSystem> PaymentSystems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductMatrix> ProductMatrices { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SalePaymentMethod> SalePaymentMethods { get; set; }

    public virtual DbSet<ServicePrioriry> ServicePrioriries { get; set; }

    public virtual DbSet<TimeZoneId> TimeZoneIds { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<VendingMachine> VendingMachines { get; set; }

    public virtual DbSet<VendingMachineEquipment> VendingMachineEquipments { get; set; }

    public virtual DbSet<VendingMachineEvent> VendingMachineEvents { get; set; }

    public virtual DbSet<VendingMachineManufacturer> VendingMachineManufacturers { get; set; }

    public virtual DbSet<VendingMachineModel> VendingMachineModels { get; set; }

    public virtual DbSet<VendingMachineProduct> VendingMachineProducts { get; set; }

    public virtual DbSet<VendingMachineStatus> VendingMachineStatuses { get; set; }

    public virtual DbSet<WorkMode> WorkModes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=zorales;Database=Test;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable("Company");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.CreateAt).HasPrecision(0);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(100);
        });

        modelBuilder.Entity<ConnectedType>(entity =>
        {
            entity.ToTable("ConnectedType");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IsoCode).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<CriticalValuesTemplate>(entity =>
        {
            entity.ToTable("CriticalValuesTemplate");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<EquipmentType>(entity =>
        {
            entity.ToTable("EquipmentType");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<EventSeverity>(entity =>
        {
            entity.ToTable("EventSeverity");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.ToTable("EventType");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.EventSeverityId).HasColumnName("EventSeverityID");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.EventSeverity).WithMany(p => p.EventTypes)
                .HasForeignKey(d => d.EventSeverityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventType_EventSeverity");
        });

        modelBuilder.Entity<Maintenance>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Maintenance");

            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.ExecutorUserId).HasColumnName("ExecutorUserID");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Problems).HasMaxLength(100);
            entity.Property(e => e.VendingMachineId).HasColumnName("VendingMachineID");

            entity.HasOne(d => d.ExecutorUser).WithMany()
                .HasForeignKey(d => d.ExecutorUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Maintenance_UserAccount");

            entity.HasOne(d => d.VendingMachine).WithMany()
                .HasForeignKey(d => d.VendingMachineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Maintenance_VendingMachine");
        });

        modelBuilder.Entity<Modem>(entity =>
        {
            entity.ToTable("Modem");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ConnectedTypeId).HasColumnName("ConnectedTypeID");
            entity.Property(e => e.CreateAt).HasPrecision(0);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Imei).HasMaxLength(100);
            entity.Property(e => e.ModemNumber).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(100);
            entity.Property(e => e.ProviderId).HasColumnName("ProviderID");

            entity.HasOne(d => d.ConnectedType).WithMany(p => p.Modems)
                .HasForeignKey(d => d.ConnectedTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Modem_ConnectedType");

            entity.HasOne(d => d.Provider).WithMany(p => p.Modems)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Modem_Provider");
        });

        modelBuilder.Entity<NotificationTemplate>(entity =>
        {
            entity.ToTable("NotificationTemplate");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<PaymentSystem>(entity =>
        {
            entity.ToTable("PaymentSystem");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 9)");
        });

        modelBuilder.Entity<ProductMatrix>(entity =>
        {
            entity.ToTable("ProductMatrix");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.ToTable("Provider");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.ToTable("Sale");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VendingMachineId).HasColumnName("VendingMachineID");

            entity.HasOne(d => d.Product).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sale_Product");

            entity.HasOne(d => d.SalePaymentMethod).WithMany(p => p.Sales)
                .HasForeignKey(d => d.SalePaymentMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sale_SalePaymentMethod");

            entity.HasOne(d => d.VendingMachine).WithMany(p => p.Sales)
                .HasForeignKey(d => d.VendingMachineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sale_VendingMachineEvent");
        });

        modelBuilder.Entity<SalePaymentMethod>(entity =>
        {
            entity.ToTable("SalePaymentMethod");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<ServicePrioriry>(entity =>
        {
            entity.ToTable("ServicePrioriry");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<TimeZoneId>(entity =>
        {
            entity.ToTable("TimeZoneID");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.ToTable("UserAccount");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateAt).HasPrecision(0);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(100);
            entity.Property(e => e.PasswordSalt).HasMaxLength(100);
            entity.Property(e => e.Patronymic).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(100);
            entity.Property(e => e.PhotoUrl).HasMaxLength(500);
            entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

            entity.HasOne(d => d.Company).WithMany(p => p.UserAccounts)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAccount_Company");

            entity.HasOne(d => d.UserRole).WithMany(p => p.UserAccounts)
                .HasForeignKey(d => d.UserRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAccount_UserRole");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.ToTable("UserRole");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<VendingMachine>(entity =>
        {
            entity.ToTable("VendingMachine");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateAt).HasPrecision(0);
            entity.Property(e => e.KitOnlineCashRegisterId).HasMaxLength(100);
            entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.ModemId).HasColumnName("ModemID");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Notes).HasMaxLength(100);
            entity.Property(e => e.Place).HasMaxLength(100);
            entity.Property(e => e.ProductMatrixId).HasColumnName("ProductMatrixID");
            entity.Property(e => e.TimeZoneId).HasColumnName("TimeZoneID");
            entity.Property(e => e.VendingMachineModelId).HasColumnName("VendingMachineModelID");
            entity.Property(e => e.VendingMachineStatusId).HasColumnName("VendingMachineStatusID");
            entity.Property(e => e.WorkModelId).HasColumnName("WorkModelID");
            entity.Property(e => e.WorkingTimeFrom).HasPrecision(0);
            entity.Property(e => e.WorkingTimeTo).HasPrecision(0);

            entity.HasOne(d => d.Company).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VendingMachine_Company");

            entity.HasOne(d => d.Country).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VendingMachine_Country");

            entity.HasOne(d => d.CriticalValuesTemplate).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.CriticalValuesTemplateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VendingMachine_CriticalValuesTemplate");

            entity.HasOne(d => d.EngineerUserAccount).WithMany(p => p.VendingMachineEngineerUserAccounts)
                .HasForeignKey(d => d.EngineerUserAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VendingMachine_UserAccount2");

            entity.HasOne(d => d.LastVerificationUserAccount).WithMany(p => p.VendingMachineLastVerificationUserAccounts)
                .HasForeignKey(d => d.LastVerificationUserAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VendingMachine_UserAccount");

            entity.HasOne(d => d.ManagerUserAccount).WithMany(p => p.VendingMachineManagerUserAccounts)
                .HasForeignKey(d => d.ManagerUserAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VendingMachine_UserAccount1");

            entity.HasOne(d => d.Modem).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.ModemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VendingMachine_Modem");

            entity.HasOne(d => d.NotificationTemplate).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.NotificationTemplateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VendingMachine_NotificationTemplate");

            entity.HasOne(d => d.ProductMatrix).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.ProductMatrixId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VendingMachine_ProductMatrix");

            entity.HasOne(d => d.ServicePriorityNavigation).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.ServicePriority)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VendingMachine_ServicePrioriry");

            entity.HasOne(d => d.TechnicianOperatorUserAccount).WithMany(p => p.VendingMachineTechnicianOperatorUserAccounts)
                .HasForeignKey(d => d.TechnicianOperatorUserAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VendingMachine_UserAccount3");

            entity.HasOne(d => d.TimeZone).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.TimeZoneId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VendingMachine_TimeZoneID");

            entity.HasOne(d => d.VendingMachineModel).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.VendingMachineModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VendingMachine_VendingMachineModel");

            entity.HasOne(d => d.VendingMachineStatus).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.VendingMachineStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VendingMachine_VendingMachineStatus");

            entity.HasOne(d => d.WorkModel).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.WorkModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VendingMachine_WorkMode");

            entity.HasMany(d => d.PaymentSystems).WithMany(p => p.VendingMachines)
                .UsingEntity<Dictionary<string, object>>(
                    "VendingMachinePayment",
                    r => r.HasOne<PaymentSystem>().WithMany()
                        .HasForeignKey("PaymentSystemId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_VendingMachinePayment_PaymentSystem"),
                    l => l.HasOne<VendingMachine>().WithMany()
                        .HasForeignKey("VendingMachineId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_VendingMachinePayment_VendingMachine"),
                    j =>
                    {
                        j.HasKey("VendingMachineId", "PaymentSystemId");
                        j.ToTable("VendingMachinePayment");
                        j.IndexerProperty<int>("VendingMachineId").HasColumnName("VendingMachineID");
                        j.IndexerProperty<int>("PaymentSystemId").HasColumnName("PaymentSystemID");
                    });
        });

        modelBuilder.Entity<VendingMachineEquipment>(entity =>
        {
            entity.ToTable("VendingMachineEquipment");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            entity.HasOne(d => d.EquipmentType).WithMany(p => p.VendingMachineEquipments)
                .HasForeignKey(d => d.EquipmentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VendingMachineEquipment_EquipmentType");
        });

        modelBuilder.Entity<VendingMachineEvent>(entity =>
        {
            entity.ToTable("VendingMachineEvent");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");
            entity.Property(e => e.VendingMachineId).HasColumnName("VendingMachineID");

            entity.HasOne(d => d.EventType).WithMany(p => p.VendingMachineEvents)
                .HasForeignKey(d => d.EventTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VendingMachineEvent_EventType");

            entity.HasOne(d => d.VendingMachine).WithMany(p => p.VendingMachineEvents)
                .HasForeignKey(d => d.VendingMachineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VendingMachineEvent_VendingMachine");
        });

        modelBuilder.Entity<VendingMachineManufacturer>(entity =>
        {
            entity.ToTable("VendingMachineManufacturer");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<VendingMachineModel>(entity =>
        {
            entity.ToTable("VendingMachineModel");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.VendingMachineManufacturer).WithMany(p => p.VendingMachineModels)
                .HasForeignKey(d => d.VendingMachineManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VendingMachineModel_VendingMachineManufacturer");
        });

        modelBuilder.Entity<VendingMachineProduct>(entity =>
        {
            entity.HasKey(e => new { e.VendingMachineId, e.ProductId });

            entity.ToTable("VendingMachineProduct");

            entity.Property(e => e.VendingMachineId).HasColumnName("VendingMachineID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Product).WithMany(p => p.VendingMachineProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VendingMachineProduct_Product");

            entity.HasOne(d => d.VendingMachine).WithMany(p => p.VendingMachineProducts)
                .HasForeignKey(d => d.VendingMachineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VendingMachineProduct_VendingMachineEvent");
        });

        modelBuilder.Entity<VendingMachineStatus>(entity =>
        {
            entity.ToTable("VendingMachineStatus");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<WorkMode>(entity =>
        {
            entity.ToTable("WorkMode");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
