using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class SYS_SysSettingMap : EntityTypeConfiguration<SYS_SysSetting>
    {
        public SYS_SysSettingMap()
        {
            // Primary Key
            this.HasKey(t => t.RowGuid);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.TitleCode)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UniqueCode)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ParamValue)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .HasMaxLength(225);

            // Table & Column Mappings
            this.ToTable("SYS_SysSetting");
            this.Property(t => t.RowGuid).HasColumnName("RowGuid");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.TitleCode).HasColumnName("TitleCode");
            this.Property(t => t.UniqueCode).HasColumnName("UniqueCode");
            this.Property(t => t.ParamValue).HasColumnName("ParamValue");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
