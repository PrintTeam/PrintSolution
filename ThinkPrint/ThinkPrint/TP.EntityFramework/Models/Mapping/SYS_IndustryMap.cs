using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class SYS_IndustryMap : EntityTypeConfiguration<SYS_Industry>
    {
        public SYS_IndustryMap()
        {
            // Primary Key
            this.HasKey(t => t.IndustryId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(225);

            // Table & Column Mappings
            this.ToTable("SYS_Industry");
            this.Property(t => t.IndustryId).HasColumnName("IndustryId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
