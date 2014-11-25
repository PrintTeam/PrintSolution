using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class ORG_ShiftMap : EntityTypeConfiguration<ORG_Shift>
    {
        public ORG_ShiftMap()
        {
            // Primary Key
            this.HasKey(t => t.ShiftId);

            // Properties
            this.Property(t => t.ShiftId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ORG_Shift");
            this.Property(t => t.ShiftId).HasColumnName("ShiftId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
        }
    }
}
