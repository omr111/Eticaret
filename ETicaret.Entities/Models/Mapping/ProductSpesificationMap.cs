using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ETicaret.Entities.Models.Mapping
{
    public class ProductSpesificationMap : EntityTypeConfiguration<ProductSpesification>
    {
        public ProductSpesificationMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.SpeCaption)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SpeDescription)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ProductSpesifications");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.SpeCaption).HasColumnName("SpeCaption");
            this.Property(t => t.SpeDescription).HasColumnName("SpeDescription");

            // Relationships
            this.HasRequired(t => t.Product)
                .WithMany(t => t.ProductSpesifications)
                .HasForeignKey(d => d.ProductId);

        }
    }
}
