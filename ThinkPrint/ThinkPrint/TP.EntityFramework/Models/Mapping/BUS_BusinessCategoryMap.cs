using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class BUS_BusinessCategoryMap : EntityTypeConfiguration<BUS_BusinessCategory>
    {
        public BUS_BusinessCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.BusinessCategoryId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.BusinessType)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.MnemonicCode)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(225);

            // Table & Column Mappings
            this.ToTable("BUS_BusinessCategory");
            this.Property(t => t.BusinessCategoryId).HasColumnName("BusinessCategoryId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
            this.Property(t => t.BusinessType).HasColumnName("BusinessType");
            this.Property(t => t.MnemonicCode).HasColumnName("MnemonicCode");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");
        }
    }
}
