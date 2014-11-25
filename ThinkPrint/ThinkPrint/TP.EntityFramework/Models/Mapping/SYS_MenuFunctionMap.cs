using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TP.EntityFramework.Models.Mapping
{
    public class SYS_MenuFunctionMap : EntityTypeConfiguration<SYS_MenuFunction>
    {
        public SYS_MenuFunctionMap()
        {
            // Primary Key
            this.HasKey(t => t.MenuFunctionId);

            // Properties
            this.Property(t => t.MenuFunctionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("SYS_MenuFunction");
            this.Property(t => t.MenuFunctionId).HasColumnName("MenuFunctionId");
            this.Property(t => t.MenuId).HasColumnName("MenuId");
            this.Property(t => t.FunctionId).HasColumnName("FunctionId");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.SYS_Function)
                .WithMany(t => t.SYS_MenuFunction)
                .HasForeignKey(d => d.FunctionId);
            this.HasRequired(t => t.SYS_Menu)
                .WithMany(t => t.SYS_MenuFunction)
                .HasForeignKey(d => d.MenuId);

        }
    }
}
