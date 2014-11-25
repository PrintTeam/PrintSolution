using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class BPM_PrintingPriceRangeListMap : EntityTypeConfiguration<BPM_PrintingPriceRangeList>
    {
        public BPM_PrintingPriceRangeListMap()
        {
            // Primary Key
            this.HasKey(t => t.PrintingPriceRangeId);

            // Properties
            this.Property(t => t.Description)
                .HasMaxLength(225);

            // Table & Column Mappings
            this.ToTable("BPM_PrintingPriceRangeList");
            this.Property(t => t.PrintingPriceRangeId).HasColumnName("PrintingPriceRangeId");
            this.Property(t => t.PrintingProcessId).HasColumnName("PrintingProcessId");
            this.Property(t => t.UnitId).HasColumnName("UnitId");
            this.Property(t => t.Form).HasColumnName("Form");
            this.Property(t => t.To).HasColumnName("To");
            this.Property(t => t.CostPrice).HasColumnName("CostPrice");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.PMW_PrintingProcess)
                .WithMany(t => t.BPM_PrintingPriceRangeList)
                .HasForeignKey(d => d.PrintingProcessId);
            this.HasRequired(t => t.SYS_Unit)
                .WithMany(t => t.BPM_PrintingPriceRangeList)
                .HasForeignKey(d => d.UnitId);

        }
    }
}
