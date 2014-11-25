using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class SAL_CustomerMap : EntityTypeConfiguration<SAL_Customer>
    {
        public SAL_CustomerMap()
        {
            // Primary Key
            this.HasKey(t => t.CustomerId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.MembershipCode)
                .HasMaxLength(50);

            this.Property(t => t.Cardholder)
                .HasMaxLength(50);

            this.Property(t => t.CardNumber)
                .HasMaxLength(100);

            this.Property(t => t.CustomerType)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.UniqueCode)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.MnemonicCode)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.MobilePhone)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Telephone)
                .HasMaxLength(20);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            this.Property(t => t.ZipCode)
                .HasMaxLength(20);

            this.Property(t => t.Address)
                .HasMaxLength(225);

            this.Property(t => t.SalePriceType)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.Description)
                .HasMaxLength(225);

            // Table & Column Mappings
            this.ToTable("SAL_Customer");
            this.Property(t => t.CustomerId).HasColumnName("CustomerId");
            this.Property(t => t.IndustryId).HasColumnName("IndustryId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.MembershipCode).HasColumnName("MembershipCode");
            this.Property(t => t.Cardholder).HasColumnName("Cardholder");
            this.Property(t => t.CardNumber).HasColumnName("CardNumber");
            this.Property(t => t.CustomerType).HasColumnName("CustomerType");
            this.Property(t => t.UniqueCode).HasColumnName("UniqueCode");
            this.Property(t => t.MnemonicCode).HasColumnName("MnemonicCode");
            this.Property(t => t.Sex).HasColumnName("Sex");
            this.Property(t => t.MobilePhone).HasColumnName("MobilePhone");
            this.Property(t => t.Telephone).HasColumnName("Telephone");
            this.Property(t => t.Birthday).HasColumnName("Birthday");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.QQ).HasColumnName("QQ");
            this.Property(t => t.ZipCode).HasColumnName("ZipCode");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.CreditRating).HasColumnName("CreditRating");
            this.Property(t => t.IsCreditCard).HasColumnName("IsCreditCard");
            this.Property(t => t.MaximumAmount).HasColumnName("MaximumAmount");
            this.Property(t => t.SalePriceType).HasColumnName("SalePriceType");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");

            // Relationships
            this.HasRequired(t => t.SYS_Industry)
                .WithMany(t => t.SAL_Customer)
                .HasForeignKey(d => d.IndustryId);

        }
    }
}
