using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class AUT_RoleModuleMap : EntityTypeConfiguration<AUT_RoleModule>
    {
        public AUT_RoleModuleMap()
        {
            // Primary Key
            this.HasKey(t => t.RoleModuleId);

            // Properties
            this.Property(t => t.AuthorizedPerson)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("AUT_RoleModule");
            this.Property(t => t.RoleModuleId).HasColumnName("RoleModuleId");
            this.Property(t => t.RoleId).HasColumnName("RoleId");
            this.Property(t => t.ModuleId).HasColumnName("ModuleId");
            this.Property(t => t.AuthorizedPerson).HasColumnName("AuthorizedPerson");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.AUT_Role)
                .WithMany(t => t.AUT_RoleModule)
                .HasForeignKey(d => d.RoleId);
            this.HasRequired(t => t.SYS_Module)
                .WithMany(t => t.AUT_RoleModule)
                .HasForeignKey(d => d.ModuleId);

        }
    }
}
