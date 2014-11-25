using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class PMW_PrintingProcessMap : EntityTypeConfiguration<PMW_PrintingProcess>
    {
        public PMW_PrintingProcessMap()
        {
            // Primary Key
            this.HasKey(t => t.PrintingProcessId);

            // Properties
            this.Property(t => t.ProcessType)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ShortName)
                .HasMaxLength(50);

            this.Property(t => t.MnemonicCode)
                .HasMaxLength(50);

            this.Property(t => t.PartsAttributeCode)
                .IsRequired()
                .HasMaxLength(225);

            this.Property(t => t.SideProperty)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.ColorType)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            // Table & Column Mappings
            this.ToTable("PMW_PrintingProcess");
            this.Property(t => t.PrintingProcessId).HasColumnName("PrintingProcessId");
            this.Property(t => t.MachineId).HasColumnName("MachineId");
            this.Property(t => t.ProcessType).HasColumnName("ProcessType");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ShortName).HasColumnName("ShortName");
            this.Property(t => t.MnemonicCode).HasColumnName("MnemonicCode");
            this.Property(t => t.PartsAttributeCode).HasColumnName("PartsAttributeCode");
            this.Property(t => t.SideProperty).HasColumnName("SideProperty");
            this.Property(t => t.ColorType).HasColumnName("ColorType");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");

            // Relationships
            this.HasRequired(t => t.PMW_Machine)
                .WithMany(t => t.PMW_PrintingProcess)
                .HasForeignKey(d => d.MachineId);

        }
    }
}
