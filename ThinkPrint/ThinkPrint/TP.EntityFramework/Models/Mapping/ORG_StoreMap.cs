using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class ORG_StoreMap : EntityTypeConfiguration<ORG_Store>
    {
        public ORG_StoreMap()
        {
            // Primary Key
            this.HasKey(t => t.StoreId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UniqueCode)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .IsRequired()
                .HasMaxLength(225);

            this.Property(t => t.Telephone)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.ResponsiblePerson)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(225);

            // Table & Column Mappings
            this.ToTable("ORG_Store");
            this.Property(t => t.StoreId).HasColumnName("StoreId");
            this.Property(t => t.CompanyId).HasColumnName("CompanyId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.UniqueCode).HasColumnName("UniqueCode");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Telephone).HasColumnName("Telephone");
            this.Property(t => t.ResponsiblePerson).HasColumnName("ResponsiblePerson");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");

            // Relationships
            this.HasRequired(t => t.ORG_Company)
                .WithMany(t => t.ORG_Store)
                .HasForeignKey(d => d.CompanyId);

        }
    }
}
