using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class CRM__PostRegisterCardMap : EntityTypeConfiguration<CRM__PostRegisterCard>
    {
        public CRM__PostRegisterCardMap()
        {
            // Primary Key
            this.HasKey(t => t.PostRegisterCardId);

            // Properties
            this.Property(t => t.QuondamCardNumber)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.OperatorStoresCode)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.OperatorPerson)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CRM_ PostRegisterCard");
            this.Property(t => t.PostRegisterCardId).HasColumnName("PostRegisterCardId");
            this.Property(t => t.MembershipCardId).HasColumnName("MembershipCardId");
            this.Property(t => t.QuondamCardNumber).HasColumnName("QuondamCardNumber");
            this.Property(t => t.Charge).HasColumnName("Charge");
            this.Property(t => t.OperatorStoresCode).HasColumnName("OperatorStoresCode");
            this.Property(t => t.OperatorPerson).HasColumnName("OperatorPerson");
            this.Property(t => t.HandleDate).HasColumnName("HandleDate");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.CRM_MembershipCard)
                .WithMany(t => t.CRM__PostRegisterCard)
                .HasForeignKey(d => d.MembershipCardId);

        }
    }
}
