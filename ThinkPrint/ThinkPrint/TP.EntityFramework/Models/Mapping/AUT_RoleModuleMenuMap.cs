using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class AUT_RoleModuleMenuMap : EntityTypeConfiguration<AUT_RoleModuleMenu>
    {
        public AUT_RoleModuleMenuMap()
        {
            // Primary Key
            this.HasKey(t => t.RoleModuleMenuId);

            // Properties
            this.Property(t => t.RoleModuleMenuId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AuthorizedPerson)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("AUT_RoleModuleMenu");
            this.Property(t => t.RoleModuleMenuId).HasColumnName("RoleModuleMenuId");
            this.Property(t => t.RoleModuleId).HasColumnName("RoleModuleId");
            this.Property(t => t.MenuId).HasColumnName("MenuId");
            this.Property(t => t.AuthorizedPerson).HasColumnName("AuthorizedPerson");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasOptional(t => t.AUT_RoleModule)
                .WithMany(t => t.AUT_RoleModuleMenu)
                .HasForeignKey(d => d.RoleModuleId);
            this.HasRequired(t => t.SYS_Menu)
                .WithMany(t => t.AUT_RoleModuleMenu)
                .HasForeignKey(d => d.MenuId);

        }
    }
}
