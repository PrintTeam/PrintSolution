using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class SYS_OrderRemindSettingMap : EntityTypeConfiguration<SYS_OrderRemindSetting>
    {
        public SYS_OrderRemindSettingMap()
        {
            // Primary Key
            this.HasKey(t => t.OrderRemindId);

            // Properties
            this.Property(t => t.OrderRemindId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ReminderType)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.ReminderColor)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.OvertimeColor)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.WarningMessages)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("SYS_OrderRemindSetting");
            this.Property(t => t.OrderRemindId).HasColumnName("OrderRemindId");
            this.Property(t => t.ReminderType).HasColumnName("ReminderType");
            this.Property(t => t.ReminderCycle).HasColumnName("ReminderCycle");
            this.Property(t => t.ReminderColor).HasColumnName("ReminderColor");
            this.Property(t => t.OvertimeCycle).HasColumnName("OvertimeCycle");
            this.Property(t => t.OvertimeColor).HasColumnName("OvertimeColor");
            this.Property(t => t.EnabledWarning).HasColumnName("EnabledWarning");
            this.Property(t => t.WarningMessages).HasColumnName("WarningMessages");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");
        }
    }
}
