using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class AUT_UserRoleMap : EntityTypeConfiguration<AUT_UserRole>
    {
        public AUT_UserRoleMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserId, t.RoleId });

            // Properties
            this.Property(t => t.UserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.RoleId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Description)
                .HasMaxLength(225);

            // Table & Column Mappings
            this.ToTable("AUT_UserRole");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.RoleId).HasColumnName("RoleId");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.AUT_Role)
                .WithMany(t => t.AUT_UserRole)
                .HasForeignKey(d => d.RoleId);
            this.HasRequired(t => t.AUT_User)
                .WithMany(t => t.AUT_UserRole)
                .HasForeignKey(d => d.UserId);

        }
    }
}
