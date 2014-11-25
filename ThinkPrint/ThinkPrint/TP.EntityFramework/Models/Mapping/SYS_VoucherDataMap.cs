using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class SYS_VoucherDataMap : EntityTypeConfiguration<SYS_VoucherData>
    {
        public SYS_VoucherDataMap()
        {
            // Primary Key
            this.HasKey(t => t.VoucherDataId);

            // Properties
            this.Property(t => t.CurrentValue)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SYS_VoucherData");
            this.Property(t => t.VoucherDataId).HasColumnName("VoucherDataId");
            this.Property(t => t.VoucherEncodingRuleId).HasColumnName("VoucherEncodingRuleId");
            this.Property(t => t.CurrentValue).HasColumnName("CurrentValue");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.SYS_VoucherEncodingRule)
                .WithMany(t => t.SYS_VoucherData)
                .HasForeignKey(d => d.VoucherEncodingRuleId);

        }
    }
}
