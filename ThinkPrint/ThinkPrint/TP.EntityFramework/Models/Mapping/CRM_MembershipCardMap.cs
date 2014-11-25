using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class CRM_MembershipCardMap : EntityTypeConfiguration<CRM_MembershipCard>
    {
        public CRM_MembershipCardMap()
        {
            // Primary Key
            this.HasKey(t => t.MembershipCardId);

            // Properties
            this.Property(t => t.UniqueCode)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CardNumber)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Cardholder)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.MobilePhone)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Telephone)
                .HasMaxLength(20);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            this.Property(t => t.Address)
                .IsRequired()
                .HasMaxLength(225);

            this.Property(t => t.CardPassword)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CredentialsType)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.CredentialsNum)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.OperatorPerson)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CardStatus)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.Description)
                .HasMaxLength(225);

            // Table & Column Mappings
            this.ToTable("CRM_MembershipCard");
            this.Property(t => t.MembershipCardId).HasColumnName("MembershipCardId");
            this.Property(t => t.MembershipCardCategoryId).HasColumnName("MembershipCardCategoryId");
            this.Property(t => t.StoreId).HasColumnName("StoreId");
            this.Property(t => t.UniqueCode).HasColumnName("UniqueCode");
            this.Property(t => t.CardNumber).HasColumnName("CardNumber");
            this.Property(t => t.CreditRating).HasColumnName("CreditRating");
            this.Property(t => t.Cardholder).HasColumnName("Cardholder");
            this.Property(t => t.Sex).HasColumnName("Sex");
            this.Property(t => t.MobilePhone).HasColumnName("MobilePhone");
            this.Property(t => t.Telephone).HasColumnName("Telephone");
            this.Property(t => t.Birthday).HasColumnName("Birthday");
            this.Property(t => t.QQ).HasColumnName("QQ");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.CardPassword).HasColumnName("CardPassword");
            this.Property(t => t.CredentialsType).HasColumnName("CredentialsType");
            this.Property(t => t.CredentialsNum).HasColumnName("CredentialsNum");
            this.Property(t => t.AccountBalance).HasColumnName("AccountBalance");
            this.Property(t => t.PresenterAmount).HasColumnName("PresenterAmount");
            this.Property(t => t.Deposit).HasColumnName("Deposit");
            this.Property(t => t.EffectiveDate).HasColumnName("EffectiveDate");
            this.Property(t => t.OperatorPerson).HasColumnName("OperatorPerson");
            this.Property(t => t.CardStatus).HasColumnName("CardStatus");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.CRM_MembershipCardCategory)
                .WithMany(t => t.CRM_MembershipCard)
                .HasForeignKey(d => d.MembershipCardCategoryId);
            this.HasRequired(t => t.ORG_Store)
                .WithMany(t => t.CRM_MembershipCard)
                .HasForeignKey(d => d.StoreId);

        }
    }
}
