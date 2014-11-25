using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class CRM_CardRechargeMap : EntityTypeConfiguration<CRM_CardRecharge>
    {
        public CRM_CardRechargeMap()
        {
            // Primary Key
            this.HasKey(t => t.CardRechargeId);

            // Properties
            this.Property(t => t.OperatorStoresCode)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Payee)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.PresenterReason)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("CRM_CardRecharge");
            this.Property(t => t.CardRechargeId).HasColumnName("CardRechargeId");
            this.Property(t => t.MembershipCardId).HasColumnName("MembershipCardId");
            this.Property(t => t.CreditsAmount).HasColumnName("CreditsAmount");
            this.Property(t => t.OperatorStoresCode).HasColumnName("OperatorStoresCode");
            this.Property(t => t.Payee).HasColumnName("Payee");
            this.Property(t => t.PresenterAmount).HasColumnName("PresenterAmount");
            this.Property(t => t.PresenterReason).HasColumnName("PresenterReason");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.CRM_MembershipCard)
                .WithMany(t => t.CRM_CardRecharge)
                .HasForeignKey(d => d.MembershipCardId);

        }
    }
}
