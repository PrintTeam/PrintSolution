using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class CRM_MembershipCardCategoryMap : EntityTypeConfiguration<CRM_MembershipCardCategory>
    {
        public CRM_MembershipCardCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.MembershipCardCategoryId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CRM_MembershipCardCategory");
            this.Property(t => t.MembershipCardCategoryId).HasColumnName("MembershipCardCategoryId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");
        }
    }
}
