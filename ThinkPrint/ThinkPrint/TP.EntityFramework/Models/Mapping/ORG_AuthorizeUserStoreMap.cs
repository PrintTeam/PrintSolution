using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class ORG_AuthorizeUserStoreMap : EntityTypeConfiguration<ORG_AuthorizeUserStore>
    {
        public ORG_AuthorizeUserStoreMap()
        {
            // Primary Key
            this.HasKey(t => new { t.StoreId, t.UserId });

            // Properties
            this.Property(t => t.StoreId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AuthorizedPerson)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(225);

            // Table & Column Mappings
            this.ToTable("ORG_AuthorizeUserStore");
            this.Property(t => t.StoreId).HasColumnName("StoreId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.AuthorizedPerson).HasColumnName("AuthorizedPerson");
            this.Property(t => t.IsStoreManager).HasColumnName("IsStoreManager");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.Description).HasColumnName("Description");

            // Relationships
            this.HasRequired(t => t.AUT_User)
                .WithMany(t => t.ORG_AuthorizeUserStore)
                .HasForeignKey(d => d.UserId);
            this.HasRequired(t => t.ORG_Store)
                .WithMany(t => t.ORG_AuthorizeUserStore)
                .HasForeignKey(d => d.StoreId);

        }
    }
}
