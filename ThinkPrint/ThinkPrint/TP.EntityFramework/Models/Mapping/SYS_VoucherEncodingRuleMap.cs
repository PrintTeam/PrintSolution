using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class SYS_VoucherEncodingRuleMap : EntityTypeConfiguration<SYS_VoucherEncodingRule>
    {
        public SYS_VoucherEncodingRuleMap()
        {
            // Primary Key
            this.HasKey(t => t.VoucherEncodingRuleId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.BillType)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.Prefix)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CodeModeType)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.Description)
                .HasMaxLength(225);

            // Table & Column Mappings
            this.ToTable("SYS_VoucherEncodingRule");
            this.Property(t => t.VoucherEncodingRuleId).HasColumnName("VoucherEncodingRuleId");
            this.Property(t => t.StoreId).HasColumnName("StoreId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.BillType).HasColumnName("BillType");
            this.Property(t => t.Prefix).HasColumnName("Prefix");
            this.Property(t => t.SequenceNumberLength).HasColumnName("SequenceNumberLength");
            this.Property(t => t.SequenceNumberStartValue).HasColumnName("SequenceNumberStartValue");
            this.Property(t => t.CodeModeType).HasColumnName("CodeModeType");
            this.Property(t => t.YearLength).HasColumnName("YearLength");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");
            this.Property(t => t.Description).HasColumnName("Description");

            // Relationships
            this.HasRequired(t => t.ORG_Store)
                .WithMany(t => t.SYS_VoucherEncodingRule)
                .HasForeignKey(d => d.StoreId);

        }
    }
}
