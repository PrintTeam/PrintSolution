using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class ORG_DepartmentMap : EntityTypeConfiguration<ORG_Department>
    {
        public ORG_DepartmentMap()
        {
            // Primary Key
            this.HasKey(t => t.DepartmentId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ShortName)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(225);

            // Table & Column Mappings
            this.ToTable("ORG_Department");
            this.Property(t => t.DepartmentId).HasColumnName("DepartmentId");
            this.Property(t => t.CompanyId).HasColumnName("CompanyId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ShortName).HasColumnName("ShortName");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");

            // Relationships
            this.HasOptional(t => t.ORG_Company)
                .WithMany(t => t.ORG_Department)
                .HasForeignKey(d => d.CompanyId);

        }
    }
}
