using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class BPM_PrintingMembershipPriceListMap : EntityTypeConfiguration<BPM_PrintingMembershipPriceList>
    {
        public BPM_PrintingMembershipPriceListMap()
        {
            // Primary Key
            this.HasKey(t => t.PrintingMembershipPriceId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.OperatorPerson)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(225);

            // Table & Column Mappings
            this.ToTable("BPM_PrintingMembershipPriceList");
            this.Property(t => t.PrintingMembershipPriceId).HasColumnName("PrintingMembershipPriceId");
            this.Property(t => t.PrintingPriceRangeId).HasColumnName("PrintingPriceRangeId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.SalePrice).HasColumnName("SalePrice");
            this.Property(t => t.OperatorPerson).HasColumnName("OperatorPerson");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.IsEnabled).HasColumnName("IsEnabled");

            // Relationships
            this.HasRequired(t => t.BPM_PrintingPriceRangeList)
                .WithMany(t => t.BPM_PrintingMembershipPriceList)
                .HasForeignKey(d => d.PrintingPriceRangeId);

        }
    }
}
