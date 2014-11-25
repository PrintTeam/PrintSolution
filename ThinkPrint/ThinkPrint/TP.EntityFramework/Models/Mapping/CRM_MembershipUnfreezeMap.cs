using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class CRM_MembershipUnfreezeMap : EntityTypeConfiguration<CRM_MembershipUnfreeze>
    {
        public CRM_MembershipUnfreezeMap()
        {
            // Primary Key
            this.HasKey(t => t.MembershipUnfreezeId);

            // Properties
            this.Property(t => t.UnfreezeReason)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.OperatorStoresCode)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.OperatorPerson)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ApprovedPerson)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CRM_MembershipUnfreeze");
            this.Property(t => t.MembershipUnfreezeId).HasColumnName("MembershipUnfreezeId");
            this.Property(t => t.MembershipCardId).HasColumnName("MembershipCardId");
            this.Property(t => t.UnfreezeReason).HasColumnName("UnfreezeReason");
            this.Property(t => t.OperatorStoresCode).HasColumnName("OperatorStoresCode");
            this.Property(t => t.OperatorPerson).HasColumnName("OperatorPerson");
            this.Property(t => t.ApprovedPerson).HasColumnName("ApprovedPerson");
            this.Property(t => t.ApprovedDate).HasColumnName("ApprovedDate");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.CRM_MembershipCard)
                .WithMany(t => t.CRM_MembershipUnfreeze)
                .HasForeignKey(d => d.MembershipCardId);

        }
    }
}
