using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class AUT_RoleMenuFunctionMap : EntityTypeConfiguration<AUT_RoleMenuFunction>
    {
        public AUT_RoleMenuFunctionMap()
        {
            // Primary Key
            this.HasKey(t => t.RoleMenuFunctionId);

            // Properties
            this.Property(t => t.RoleMenuFunctionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("AUT_RoleMenuFunction");
            this.Property(t => t.RoleMenuFunctionId).HasColumnName("RoleMenuFunctionId");
            this.Property(t => t.MenuFunctionId).HasColumnName("MenuFunctionId");
            this.Property(t => t.RoleModuleMenuId).HasColumnName("RoleModuleMenuId");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.AUT_RoleModuleMenu)
                .WithMany(t => t.AUT_RoleMenuFunction)
                .HasForeignKey(d => d.RoleModuleMenuId);
            this.HasRequired(t => t.SYS_MenuFunction)
                .WithMany(t => t.AUT_RoleMenuFunction)
                .HasForeignKey(d => d.MenuFunctionId);

        }
    }
}
