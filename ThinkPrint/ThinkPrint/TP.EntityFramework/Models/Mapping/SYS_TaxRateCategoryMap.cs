using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class SYS_TaxRateCategoryMap : EntityTypeConfiguration<SYS_TaxRateCategory>
    {
        public SYS_TaxRateCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.TaxRateCategoryId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(225);

            // Table & Column Mappings
            this.ToTable("SYS_TaxRateCategory");
            this.Property(t => t.TaxRateCategoryId).HasColumnName("TaxRateCategoryId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.TaxRate).HasColumnName("TaxRate");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");
        }
    }
}
