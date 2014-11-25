using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class SAL_OrderMap : EntityTypeConfiguration<SAL_Order>
    {
        public SAL_OrderMap()
        {
            // Primary Key
            this.HasKey(t => t.OrderId);

            // Properties
            this.Property(t => t.OrderNumber)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.OrderType)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.CustomerName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.MembershipCode)
                .HasMaxLength(50);

            this.Property(t => t.Cardholder)
                .HasMaxLength(50);

            this.Property(t => t.CardNumber)
                .HasMaxLength(100);

            this.Property(t => t.Contact)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.MobilePhone)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Telephone)
                .HasMaxLength(20);

            this.Property(t => t.Address)
                .IsRequired()
                .HasMaxLength(225);

            this.Property(t => t.ResponsiblePerson)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.InvoiceHead)
                .HasMaxLength(225);

            this.Property(t => t.PaymentType)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.StoredMedium)
                .HasMaxLength(100);

            this.Property(t => t.RevocatoryPersonnel)
                .HasMaxLength(100);

            this.Property(t => t.MakePersonnel)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.OrderStatus)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.Description)
                .HasMaxLength(225);

            // Table & Column Mappings
            this.ToTable("SAL_Order");
            this.Property(t => t.OrderId).HasColumnName("OrderId");
            this.Property(t => t.CustomerId).HasColumnName("CustomerId");
            this.Property(t => t.OrderNumber).HasColumnName("OrderNumber");
            this.Property(t => t.OrderType).HasColumnName("OrderType");
            this.Property(t => t.OnlineOrderFlag).HasColumnName("OnlineOrderFlag");
            this.Property(t => t.CustomerName).HasColumnName("CustomerName");
            this.Property(t => t.MembershipCode).HasColumnName("MembershipCode");
            this.Property(t => t.Cardholder).HasColumnName("Cardholder");
            this.Property(t => t.CardNumber).HasColumnName("CardNumber");
            this.Property(t => t.Contact).HasColumnName("Contact");
            this.Property(t => t.MobilePhone).HasColumnName("MobilePhone");
            this.Property(t => t.Telephone).HasColumnName("Telephone");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.ResponsiblePerson).HasColumnName("ResponsiblePerson");
            this.Property(t => t.IsInvoice).HasColumnName("IsInvoice");
            this.Property(t => t.InvoiceHead).HasColumnName("InvoiceHead");
            this.Property(t => t.InvoiceAmount).HasColumnName("InvoiceAmount");
            this.Property(t => t.OrderTaxRate).HasColumnName("OrderTaxRate");
            this.Property(t => t.TotalAmount).HasColumnName("TotalAmount");
            this.Property(t => t.PaymentType).HasColumnName("PaymentType");
            this.Property(t => t.PaymentDate).HasColumnName("PaymentDate");
            this.Property(t => t.IsAdvancesReceived).HasColumnName("IsAdvancesReceived");
            this.Property(t => t.PrepaymentsAmount).HasColumnName("PrepaymentsAmount");
            this.Property(t => t.IsPickup).HasColumnName("IsPickup");
            this.Property(t => t.IsCashIn).HasColumnName("IsCashIn");
            this.Property(t => t.IsDebt).HasColumnName("IsDebt");
            this.Property(t => t.DebtAmount).HasColumnName("DebtAmount");
            this.Property(t => t.CloseAccountsDate).HasColumnName("CloseAccountsDate");
            this.Property(t => t.IsDelivery).HasColumnName("IsDelivery");
            this.Property(t => t.DeliveryTtime).HasColumnName("DeliveryTtime");
            this.Property(t => t.UrgencyLevel).HasColumnName("UrgencyLevel");
            this.Property(t => t.IsSample).HasColumnName("IsSample");
            this.Property(t => t.StoredMedium).HasColumnName("StoredMedium");
            this.Property(t => t.MediumNumber).HasColumnName("MediumNumber");
            this.Property(t => t.RevocatoryPersonnel).HasColumnName("RevocatoryPersonnel");
            this.Property(t => t.RevocatoryDate).HasColumnName("RevocatoryDate");
            this.Property(t => t.MakePersonnel).HasColumnName("MakePersonnel");
            this.Property(t => t.MakeOrderDate).HasColumnName("MakeOrderDate");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.OrderStatus).HasColumnName("OrderStatus");
            this.Property(t => t.Description).HasColumnName("Description");

            // Relationships
            this.HasRequired(t => t.SAL_Customer)
                .WithMany(t => t.SAL_Order)
                .HasForeignKey(d => d.CustomerId);

        }
    }
}
