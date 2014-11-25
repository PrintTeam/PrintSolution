using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class CRM_CardConsumptionMap : EntityTypeConfiguration<CRM_CardConsumption>
    {
        public CRM_CardConsumptionMap()
        {
            // Primary Key
            this.HasKey(t => t.CardConsumptionId);

            // Properties
            this.Property(t => t.OrderNumber)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.OperatorStoresCode)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.OperatorPerson)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(225);

            // Table & Column Mappings
            this.ToTable("CRM_CardConsumption");
            this.Property(t => t.CardConsumptionId).HasColumnName("CardConsumptionId");
            this.Property(t => t.MembershipCardId).HasColumnName("MembershipCardId");
            this.Property(t => t.OrderNumber).HasColumnName("OrderNumber");
            this.Property(t => t.ConsumptionAmount).HasColumnName("ConsumptionAmount");
            this.Property(t => t.OperatorStoresCode).HasColumnName("OperatorStoresCode");
            this.Property(t => t.OperatorPerson).HasColumnName("OperatorPerson");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.CRM_MembershipCard)
                .WithMany(t => t.CRM_CardConsumption)
                .HasForeignKey(d => d.MembershipCardId);

        }
    }
}
