using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class PMW_PostpressMembershipPriceListMap : EntityTypeConfiguration<PMW_PostpressMembershipPriceList>
    {
        public PMW_PostpressMembershipPriceListMap()
        {
            // Primary Key
            this.HasKey(t => t.PostpressMembershipPriceId);

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
            this.ToTable("PMW_PostpressMembershipPriceList");
            this.Property(t => t.PostpressMembershipPriceId).HasColumnName("PostpressMembershipPriceId");
            this.Property(t => t.PostpressPriceRangeId).HasColumnName("PostpressPriceRangeId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.SalePrice).HasColumnName("SalePrice");
            this.Property(t => t.OperatorPerson).HasColumnName("OperatorPerson");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.IsEnabled).HasColumnName("IsEnabled");

            // Relationships
            this.HasRequired(t => t.PMW_PostpressPriceRangeList)
                .WithMany(t => t.PMW_PostpressMembershipPriceList)
                .HasForeignKey(d => d.PostpressPriceRangeId);

        }
    }
}
