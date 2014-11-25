using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class BOM_PaperSizeMap : EntityTypeConfiguration<BOM_PaperSize>
    {
        public BOM_PaperSizeMap()
        {
            // Primary Key
            this.HasKey(t => t.PaperSizeId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UniqueCode)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(225);

            // Table & Column Mappings
            this.ToTable("BOM_PaperSize");
            this.Property(t => t.PaperSizeId).HasColumnName("PaperSizeId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.UniqueCode).HasColumnName("UniqueCode");
            this.Property(t => t.Height).HasColumnName("Height");
            this.Property(t => t.Width).HasColumnName("Width");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");
        }
    }
}
