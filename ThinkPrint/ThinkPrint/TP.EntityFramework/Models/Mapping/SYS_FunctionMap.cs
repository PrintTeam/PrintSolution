using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class SYS_FunctionMap : EntityTypeConfiguration<SYS_Function>
    {
        public SYS_FunctionMap()
        {
            // Primary Key
            this.HasKey(t => t.FunctionId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ControlCode)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ActionEvent)
                .HasMaxLength(50);

            this.Property(t => t.Tooltips)
                .HasMaxLength(100);

            this.Property(t => t.Icon)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("SYS_Function");
            this.Property(t => t.FunctionId).HasColumnName("FunctionId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ControlCode).HasColumnName("ControlCode");
            this.Property(t => t.ActionEvent).HasColumnName("ActionEvent");
            this.Property(t => t.Tooltips).HasColumnName("Tooltips");
            this.Property(t => t.Icon).HasColumnName("Icon");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");
        }
    }
}
