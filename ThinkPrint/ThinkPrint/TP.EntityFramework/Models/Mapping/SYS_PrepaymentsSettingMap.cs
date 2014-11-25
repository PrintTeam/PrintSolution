using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class SYS_PrepaymentsSettingMap : EntityTypeConfiguration<SYS_PrepaymentsSetting>
    {
        public SYS_PrepaymentsSettingMap()
        {
            // Primary Key
            this.HasKey(t => t.PrepaymentsSettingId);

            // Properties
            this.Property(t => t.Description)
                .HasMaxLength(225);

            // Table & Column Mappings
            this.ToTable("SYS_PrepaymentsSetting");
            this.Property(t => t.PrepaymentsSettingId).HasColumnName("PrepaymentsSettingId");
            this.Property(t => t.OrderMinAmount).HasColumnName("OrderMinAmount");
            this.Property(t => t.OrderMaxAmount).HasColumnName("OrderMaxAmount");
            this.Property(t => t.PrepaymentsAmount).HasColumnName("PrepaymentsAmount");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");
        }
    }
}
