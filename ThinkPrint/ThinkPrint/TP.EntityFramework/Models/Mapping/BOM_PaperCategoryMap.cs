using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class BOM_PaperCategoryMap : EntityTypeConfiguration<BOM_PaperCategory>
    {
        public BOM_PaperCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.PaperCategoryId);

            // Properties
            this.Property(t => t.UniqueCode)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(225);

            // Table & Column Mappings
            this.ToTable("BOM_PaperCategory");
            this.Property(t => t.PaperCategoryId).HasColumnName("PaperCategoryId");
            this.Property(t => t.UniqueCode).HasColumnName("UniqueCode");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");
        }
    }
}
