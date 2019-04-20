using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ETicaret.Entities.Models.Mapping
{
    public class ProductReviewMap : EntityTypeConfiguration<ProductReview>
    {
        public ProductReviewMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.text)
                .IsRequired()
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("ProductReview");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.customerId).HasColumnName("customerId");
            this.Property(t => t.productId).HasColumnName("productId");
            this.Property(t => t.YildizSayisi).HasColumnName("YildizSayisi");
            this.Property(t => t.text).HasColumnName("text");
            this.Property(t => t.AddedDate).HasColumnName("AddedDate");

            // Relationships
            this.HasRequired(t => t.Member)
                .WithMany(t => t.ProductReviews)
                .HasForeignKey(d => d.customerId);
            this.HasRequired(t => t.Product)
                .WithMany(t => t.ProductReviews)
                .HasForeignKey(d => d.productId);

        }
    }
}
