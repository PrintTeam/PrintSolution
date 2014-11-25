using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class ORG_EmployeeMap : EntityTypeConfiguration<ORG_Employee>
    {
        public ORG_EmployeeMap()
        {
            // Primary Key
            this.HasKey(t => t.EmployeeId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.JobNumber)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CredentialsNum)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            this.Property(t => t.MobilePhone)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Status)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(2);

            // Table & Column Mappings
            this.ToTable("ORG_Employee");
            this.Property(t => t.EmployeeId).HasColumnName("EmployeeId");
            this.Property(t => t.DepartmentId).HasColumnName("DepartmentId");
            this.Property(t => t.StoreId).HasColumnName("StoreId");
            this.Property(t => t.ManagerId).HasColumnName("ManagerId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.JobNumber).HasColumnName("JobNumber");
            this.Property(t => t.CredentialsNum).HasColumnName("CredentialsNum");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Sex).HasColumnName("Sex");
            this.Property(t => t.Age).HasColumnName("Age");
            this.Property(t => t.MobilePhone).HasColumnName("MobilePhone");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.EntryDate).HasColumnName("EntryDate");
            this.Property(t => t.LeaveDate).HasColumnName("LeaveDate");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.ORG_Department)
                .WithMany(t => t.ORG_Employee)
                .HasForeignKey(d => d.DepartmentId);
            this.HasOptional(t => t.ORG_Employee2)
                .WithMany(t => t.ORG_Employee1)
                .HasForeignKey(d => d.ManagerId);
            this.HasOptional(t => t.ORG_Store)
                .WithMany(t => t.ORG_Employee)
                .HasForeignKey(d => d.StoreId);

        }
    }
}
