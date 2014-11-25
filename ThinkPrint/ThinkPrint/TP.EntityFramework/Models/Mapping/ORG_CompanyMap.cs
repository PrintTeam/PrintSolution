using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class ORG_CompanyMap : EntityTypeConfiguration<ORG_Company>
    {
        public ORG_CompanyMap()
        {
            // Primary Key
            this.HasKey(t => t.CompanyId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ResponsiblePerson)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .IsRequired()
                .HasMaxLength(225);

            this.Property(t => t.FaxNumber)
                .HasMaxLength(50);

            this.Property(t => t.Telephone)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("ORG_Company");
            this.Property(t => t.CompanyId).HasColumnName("CompanyId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ResponsiblePerson).HasColumnName("ResponsiblePerson");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.FaxNumber).HasColumnName("FaxNumber");
            this.Property(t => t.Telephone).HasColumnName("Telephone");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");
        }
    }
}
