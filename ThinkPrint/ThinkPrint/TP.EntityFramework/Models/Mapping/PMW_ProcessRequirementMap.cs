using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class PMW_ProcessRequirementMap : EntityTypeConfiguration<PMW_ProcessRequirement>
    {
        public PMW_ProcessRequirementMap()
        {
            // Primary Key
            this.HasKey(t => t.ProcessRequirementId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ProcessType)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.Illustrate)
                .HasMaxLength(225);

            // Table & Column Mappings
            this.ToTable("PMW_ProcessRequirement");
            this.Property(t => t.ProcessRequirementId).HasColumnName("ProcessRequirementId");
            this.Property(t => t.WorkProjectId).HasColumnName("WorkProjectId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ProcessType).HasColumnName("ProcessType");
            this.Property(t => t.Illustrate).HasColumnName("Illustrate");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.SAL_WorkProject)
                .WithMany(t => t.PMW_ProcessRequirement)
                .HasForeignKey(d => d.WorkProjectId);

        }
    }
}
