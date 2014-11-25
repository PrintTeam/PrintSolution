using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class SAL_WorkProjectDetailMap : EntityTypeConfiguration<SAL_WorkProjectDetail>
    {
        public SAL_WorkProjectDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.WorkProjectDetailId);

            // Properties
            this.Property(t => t.Description)
                .HasMaxLength(225);

            // Table & Column Mappings
            this.ToTable("SAL_WorkProjectDetail");
            this.Property(t => t.WorkProjectDetailId).HasColumnName("WorkProjectDetailId");
            this.Property(t => t.WorkProjectId).HasColumnName("WorkProjectId");
            this.Property(t => t.BusinessComponentId).HasColumnName("BusinessComponentId");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.UnitPrice).HasColumnName("UnitPrice");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.BUS_BusinessComponent)
                .WithMany(t => t.SAL_WorkProjectDetail)
                .HasForeignKey(d => d.BusinessComponentId);
            this.HasRequired(t => t.SAL_WorkProject)
                .WithMany(t => t.SAL_WorkProjectDetail)
                .HasForeignKey(d => d.WorkProjectId);

        }
    }
}
