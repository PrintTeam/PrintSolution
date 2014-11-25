using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class PMW_MachineCategoryMap : EntityTypeConfiguration<PMW_MachineCategory>
    {
        public PMW_MachineCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.MachineCategoryId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PMW_MachineCategory");
            this.Property(t => t.MachineCategoryId).HasColumnName("MachineCategoryId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");
        }
    }
}
