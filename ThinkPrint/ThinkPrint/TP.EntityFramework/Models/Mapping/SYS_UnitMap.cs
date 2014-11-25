using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class SYS_UnitMap : EntityTypeConfiguration<SYS_Unit>
    {
        public SYS_UnitMap()
        {
            // Primary Key
            this.HasKey(t => t.UnitId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UnitType)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.Description)
                .HasMaxLength(225);

            // Table & Column Mappings
            this.ToTable("SYS_Unit");
            this.Property(t => t.UnitId).HasColumnName("UnitId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.UnitType).HasColumnName("UnitType");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");
        }
    }
}
