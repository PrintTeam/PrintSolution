using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class SYS_ModuleMap : EntityTypeConfiguration<SYS_Module>
    {
        public SYS_ModuleMap()
        {
            // Primary Key
            this.HasKey(t => t.ModuleId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Icon)
                .HasMaxLength(200);

            this.Property(t => t.DefaultPage)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("SYS_Module");
            this.Property(t => t.ModuleId).HasColumnName("ModuleId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
            this.Property(t => t.Icon).HasColumnName("Icon");
            this.Property(t => t.DefaultPage).HasColumnName("DefaultPage");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");
        }
    }
}
