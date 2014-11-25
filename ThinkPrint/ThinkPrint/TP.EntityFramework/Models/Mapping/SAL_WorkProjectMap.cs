using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class SAL_WorkProjectMap : EntityTypeConfiguration<SAL_WorkProject>
    {
        public SAL_WorkProjectMap()
        {
            // Primary Key
            this.HasKey(t => t.WorkProjectId);

            // Properties
            this.Property(t => t.ProjectName)
                .IsRequired()
                .HasMaxLength(225);

            this.Property(t => t.FileName)
                .HasMaxLength(100);

            this.Property(t => t.FilePath)
                .HasMaxLength(225);

            this.Property(t => t.Standard)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ProjectType)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.PartsType)
                .IsFixedLength()
                .HasMaxLength(6);

            this.Property(t => t.Description)
                .HasMaxLength(225);

            // Table & Column Mappings
            this.ToTable("SAL_WorkProject");
            this.Property(t => t.WorkProjectId).HasColumnName("WorkProjectId");
            this.Property(t => t.UnitId).HasColumnName("UnitId");
            this.Property(t => t.OrderId).HasColumnName("OrderId");
            this.Property(t => t.ProjectName).HasColumnName("ProjectName");
            this.Property(t => t.FileName).HasColumnName("FileName");
            this.Property(t => t.FilePath).HasColumnName("FilePath");
            this.Property(t => t.Standard).HasColumnName("Standard");
            this.Property(t => t.ProjectType).HasColumnName("ProjectType");
            this.Property(t => t.PartsType).HasColumnName("PartsType");
            this.Property(t => t.PNumber).HasColumnName("PNumber");
            this.Property(t => t.Description).HasColumnName("Description");

            // Relationships
            this.HasRequired(t => t.SAL_Order)
                .WithMany(t => t.SAL_WorkProject)
                .HasForeignKey(d => d.OrderId);
            this.HasRequired(t => t.SYS_Unit)
                .WithMany(t => t.SAL_WorkProject)
                .HasForeignKey(d => d.UnitId);

        }
    }
}
