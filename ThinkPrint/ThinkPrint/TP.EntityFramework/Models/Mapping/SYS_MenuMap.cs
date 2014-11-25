using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class SYS_MenuMap : EntityTypeConfiguration<SYS_Menu>
    {
        public SYS_MenuMap()
        {
            // Primary Key
            this.HasKey(t => t.MenuId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Target)
                .HasMaxLength(225);

            this.Property(t => t.Icon)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("SYS_Menu");
            this.Property(t => t.MenuId).HasColumnName("MenuId");
            this.Property(t => t.ParentId).HasColumnName("ParentId");
            this.Property(t => t.ModuleId).HasColumnName("ModuleId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
            this.Property(t => t.Target).HasColumnName("Target");
            this.Property(t => t.MenuType).HasColumnName("MenuType");
            this.Property(t => t.Icon).HasColumnName("Icon");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");

            // Relationships
            this.HasOptional(t => t.SYS_Menu2)
                .WithMany(t => t.SYS_Menu1)
                .HasForeignKey(d => d.ParentId);
            this.HasRequired(t => t.SYS_Module)
                .WithMany(t => t.SYS_Menu)
                .HasForeignKey(d => d.ModuleId);

        }
    }
}
