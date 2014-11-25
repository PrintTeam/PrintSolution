using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class PMW_PostpressProcessMap : EntityTypeConfiguration<PMW_PostpressProcess>
    {
        public PMW_PostpressProcessMap()
        {
            // Primary Key
            this.HasKey(t => t.PostpressProcessId);

            // Properties
            this.Property(t => t.ProcessType)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UniqueCode)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ShortName)
                .HasMaxLength(50);

            this.Property(t => t.MnemonicCode)
                .HasMaxLength(50);

            this.Property(t => t.SideProperty)
                .IsFixedLength()
                .HasMaxLength(2);

            // Table & Column Mappings
            this.ToTable("PMW_PostpressProcess");
            this.Property(t => t.PostpressProcessId).HasColumnName("PostpressProcessId");
            this.Property(t => t.MachineId).HasColumnName("MachineId");
            this.Property(t => t.ProcessType).HasColumnName("ProcessType");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.UniqueCode).HasColumnName("UniqueCode");
            this.Property(t => t.ShortName).HasColumnName("ShortName");
            this.Property(t => t.MnemonicCode).HasColumnName("MnemonicCode");
            this.Property(t => t.SideProperty).HasColumnName("SideProperty");
            this.Property(t => t.PricingModels).HasColumnName("PricingModels");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");

            // Relationships
            this.HasRequired(t => t.PMW_Machine)
                .WithMany(t => t.PMW_PostpressProcess)
                .HasForeignKey(d => d.MachineId);

        }
    }
}
