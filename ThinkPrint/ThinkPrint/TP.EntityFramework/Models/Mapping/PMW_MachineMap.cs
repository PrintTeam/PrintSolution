using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class PMW_MachineMap : EntityTypeConfiguration<PMW_Machine>
    {
        public PMW_MachineMap()
        {
            // Primary Key
            this.HasKey(t => t.MachineId);

            // Properties
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

            this.Property(t => t.MachineType)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.ColorType)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            // Table & Column Mappings
            this.ToTable("PMW_Machine");
            this.Property(t => t.MachineId).HasColumnName("MachineId");
            this.Property(t => t.MachineCategoryId).HasColumnName("MachineCategoryId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.UniqueCode).HasColumnName("UniqueCode");
            this.Property(t => t.ShortName).HasColumnName("ShortName");
            this.Property(t => t.MnemonicCode).HasColumnName("MnemonicCode");
            this.Property(t => t.MachineType).HasColumnName("MachineType");
            this.Property(t => t.ColorType).HasColumnName("ColorType");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");

            // Relationships
            this.HasRequired(t => t.PMW_MachineCategory)
                .WithMany(t => t.PMW_Machine)
                .HasForeignKey(d => d.MachineCategoryId);

        }
    }
}
