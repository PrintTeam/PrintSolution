using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class CRM_MembershipFreezeMap : EntityTypeConfiguration<CRM_MembershipFreeze>
    {
        public CRM_MembershipFreezeMap()
        {
            // Primary Key
            this.HasKey(t => t.MembershipFreezeId);

            // Properties
            this.Property(t => t.FreezeReason)
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
            this.ToTable("CRM_MembershipFreeze");
            this.Property(t => t.MembershipFreezeId).HasColumnName("MembershipFreezeId");
            this.Property(t => t.MembershipCardId).HasColumnName("MembershipCardId");
            this.Property(t => t.FreezeAmount).HasColumnName("FreezeAmount");
            this.Property(t => t.FreezeReason).HasColumnName("FreezeReason");
            this.Property(t => t.OperatorStoresCode).HasColumnName("OperatorStoresCode");
            this.Property(t => t.OperatorPerson).HasColumnName("OperatorPerson");
            this.Property(t => t.ApprovedPerson).HasColumnName("ApprovedPerson");
            this.Property(t => t.ApprovedDate).HasColumnName("ApprovedDate");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.CRM_MembershipCard)
                .WithMany(t => t.CRM_MembershipFreeze)
                .HasForeignKey(d => d.MembershipCardId);

        }
    }
}
