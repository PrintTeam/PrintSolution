using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class CRM_CardDictionaryMap : EntityTypeConfiguration<CRM_CardDictionary>
    {
        public CRM_CardDictionaryMap()
        {
            // Primary Key
            this.HasKey(t => t.RowGuid);

            // Properties
            this.Property(t => t.CardNumber)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CardIMEI)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("CRM_CardDictionary");
            this.Property(t => t.RowGuid).HasColumnName("RowGuid");
            this.Property(t => t.CardNumber).HasColumnName("CardNumber");
            this.Property(t => t.CardIMEI).HasColumnName("CardIMEI");
            this.Property(t => t.IsEnabled).HasColumnName("IsEnabled");
            this.Property(t => t.IsAbandoned).HasColumnName("IsAbandoned");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
        }
    }
}
