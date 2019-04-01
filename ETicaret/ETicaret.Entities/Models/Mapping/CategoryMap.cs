using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ETicaret.Entities.Models.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(60);

            this.Property(t => t.CategoryPicPath)
                .HasMaxLength(150);

            this.Property(t => t.Description)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Categories");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.parentId).HasColumnName("parentId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.CategoryPicPath).HasColumnName("CategoryPicPath");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.AddedDate).HasColumnName("AddedDate");
            this.Property(t => t.ModifedDate).HasColumnName("ModifedDate");

            // Relationships
            this.HasOptional(t => t.Category1)
                .WithMany(t => t.Categories1)
                .HasForeignKey(d => d.parentId);

        }
    }
}
