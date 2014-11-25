using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class PMW_PostpressPriceRangeListMap : EntityTypeConfiguration<PMW_PostpressPriceRangeList>
    {
        public PMW_PostpressPriceRangeListMap()
        {
            // Primary Key
            this.HasKey(t => t.PostpressPriceRangeId);

            // Properties
            this.Property(t => t.Description)
                .HasMaxLength(225);

            // Table & Column Mappings
            this.ToTable("PMW_PostpressPriceRangeList");
            this.Property(t => t.PostpressPriceRangeId).HasColumnName("PostpressPriceRangeId");
            this.Property(t => t.PostpressProcessId).HasColumnName("PostpressProcessId");
            this.Property(t => t.UnitId).HasColumnName("UnitId");
            this.Property(t => t.Form).HasColumnName("Form");
            this.Property(t => t.To).HasColumnName("To");
            this.Property(t => t.CostPrice).HasColumnName("CostPrice");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.Description).HasColumnName("Description");

            // Relationships
            this.HasRequired(t => t.PMW_PostpressProcess)
                .WithMany(t => t.PMW_PostpressPriceRangeList)
                .HasForeignKey(d => d.PostpressProcessId);
            this.HasRequired(t => t.SYS_Unit)
                .WithMany(t => t.PMW_PostpressPriceRangeList)
                .HasForeignKey(d => d.UnitId);

        }
    }
}
