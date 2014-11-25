using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class ORG_EmployeeDepartmentHistoryMap : EntityTypeConfiguration<ORG_EmployeeDepartmentHistory>
    {
        public ORG_EmployeeDepartmentHistoryMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ShiftId, t.DepartmentId, t.EmployeeId });

            // Properties
            this.Property(t => t.ShiftId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DepartmentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.EmployeeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ORG_EmployeeDepartmentHistory");
            this.Property(t => t.ShiftId).HasColumnName("ShiftId");
            this.Property(t => t.DepartmentId).HasColumnName("DepartmentId");
            this.Property(t => t.EmployeeId).HasColumnName("EmployeeId");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.ORG_Department)
                .WithMany(t => t.ORG_EmployeeDepartmentHistory)
                .HasForeignKey(d => d.DepartmentId);
            this.HasRequired(t => t.ORG_Employee)
                .WithMany(t => t.ORG_EmployeeDepartmentHistory)
                .HasForeignKey(d => d.EmployeeId);
            this.HasRequired(t => t.ORG_Shift)
                .WithMany(t => t.ORG_EmployeeDepartmentHistory)
                .HasForeignKey(d => d.ShiftId);

        }
    }
}
