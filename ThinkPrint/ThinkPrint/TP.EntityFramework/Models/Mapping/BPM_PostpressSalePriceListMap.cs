using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class BPM_PostpressSalePriceListMap : EntityTypeConfiguration<BPM_PostpressSalePriceList>
    {
        public BPM_PostpressSalePriceListMap()
        {
            // Primary Key
            this.HasKey(t => t.PostpressSalePriceId);

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
            this.ToTable("BPM_PostpressSalePriceList");
            this.Property(t => t.PostpressSalePriceId).HasColumnName("PostpressSalePriceId");
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
                .WithMany(t => t.BPM_PostpressSalePriceList)
                .HasForeignKey(d => d.PostpressPriceRangeId);

        }
    }
}
