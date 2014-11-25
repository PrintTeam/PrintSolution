using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class BUS_BusinessComponentMap : EntityTypeConfiguration<BUS_BusinessComponent>
    {
        public BUS_BusinessComponentMap()
        {
            // Primary Key
            this.HasKey(t => t.BusinessComponentId);

            // Properties
            this.Property(t => t.Description)
                .HasMaxLength(225);

            // Table & Column Mappings
            this.ToTable("BUS_BusinessComponent");
            this.Property(t => t.BusinessComponentId).HasColumnName("BusinessComponentId");
            this.Property(t => t.BusinessCategoryId).HasColumnName("BusinessCategoryId");
            this.Property(t => t.PrintingProcessId).HasColumnName("PrintingProcessId");
            this.Property(t => t.PostpressProcessId).HasColumnName("PostpressProcessId");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.Description).HasColumnName("Description");

            // Relationships
            this.HasRequired(t => t.BUS_BusinessCategory)
                .WithMany(t => t.BUS_BusinessComponent)
                .HasForeignKey(d => d.BusinessCategoryId);
            this.HasOptional(t => t.PMW_PostpressProcess)
                .WithMany(t => t.BUS_BusinessComponent)
                .HasForeignKey(d => d.PostpressProcessId);
            this.HasOptional(t => t.PMW_PrintingProcess)
                .WithMany(t => t.BUS_BusinessComponent)
                .HasForeignKey(d => d.PrintingProcessId);

        }
    }
}
