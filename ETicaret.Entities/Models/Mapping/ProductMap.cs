using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ETicaret.Entities.Models.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Caption)
                .IsRequired()
                .HasMaxLength(75);

            this.Property(t => t.Description)
                .IsRequired();

            this.Property(t => t.ThumpNailPicture)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Products");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Caption).HasColumnName("Caption");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ProductTypeID).HasColumnName("ProductTypeID");
            this.Property(t => t.ProductBrandID).HasColumnName("ProductBrandID");
            this.Property(t => t.ThumpNailPicture).HasColumnName("ThumpNailPicture");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.IsContinued).HasColumnName("IsContinued");
            this.Property(t => t.StarPoint).HasColumnName("StarPoint");
            this.Property(t => t.StarGivenMemberCount).HasColumnName("StarGivenMemberCount");
            this.Property(t => t.UnitsInStock).HasColumnName("UnitsInStock");
            this.Property(t => t.AddedDate).HasColumnName("AddedDate");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.Category_Id).HasColumnName("Category_Id");

            // Relationships
            this.HasRequired(t => t.Brand)
                .WithMany(t => t.Products)
                .HasForeignKey(d => d.ProductBrandID);
            this.HasRequired(t => t.Category)
                .WithMany(t => t.Products)
                .HasForeignKey(d => d.Category_Id);
            this.HasRequired(t => t.ProductType)
                .WithMany(t => t.Products)
                .HasForeignKey(d => d.ProductTypeID);

        }
    }
}
