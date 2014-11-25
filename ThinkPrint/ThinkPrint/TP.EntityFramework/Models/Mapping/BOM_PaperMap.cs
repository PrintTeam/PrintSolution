using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class BOM_PaperMap : EntityTypeConfiguration<BOM_Paper>
    {
        public BOM_PaperMap()
        {
            // Primary Key
            this.HasKey(t => t.PaperId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.PartsAttributeCode)
                .IsRequired()
                .HasMaxLength(225);

            this.Property(t => t.MnemonicCode)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(225);

            // Table & Column Mappings
            this.ToTable("BOM_Paper");
            this.Property(t => t.PaperId).HasColumnName("PaperId");
            this.Property(t => t.PaperCategoryId).HasColumnName("PaperCategoryId");
            this.Property(t => t.PaperSizeId).HasColumnName("PaperSizeId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.PartsAttributeCode).HasColumnName("PartsAttributeCode");
            this.Property(t => t.MnemonicCode).HasColumnName("MnemonicCode");
            this.Property(t => t.Weight).HasColumnName("Weight");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");

            // Relationships
            this.HasRequired(t => t.BOM_PaperSize)
                .WithMany(t => t.BOM_Paper)
                .HasForeignKey(d => d.PaperSizeId);
            this.HasRequired(t => t.BOM_PaperCategory)
                .WithMany(t => t.BOM_Paper)
                .HasForeignKey(d => d.PaperCategoryId);

        }
    }
}
