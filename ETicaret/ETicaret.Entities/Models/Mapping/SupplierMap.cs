using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ETicaret.Entities.Models.Mapping
{
    public class SupplierMap : EntityTypeConfiguration<Supplier>
    {
        public SupplierMap()
        {
            // Primary Key
            this.HasKey(t => t.SupplierID);

            // Properties
            this.Property(t => t.CompanyName)
                .HasMaxLength(50);

            this.Property(t => t.ContactName)
                .HasMaxLength(50);

            this.Property(t => t.ContactTitle)
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .HasMaxLength(100);

            this.Property(t => t.PostalCode)
                .HasMaxLength(10);

            this.Property(t => t.Phone)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("Suppliers");
            this.Property(t => t.SupplierID).HasColumnName("SupplierID");
            this.Property(t => t.CompanyName).HasColumnName("CompanyName");
            this.Property(t => t.ContactName).HasColumnName("ContactName");
            this.Property(t => t.ContactTitle).HasColumnName("ContactTitle");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.CityID).HasColumnName("CityID");
            this.Property(t => t.PostalCode).HasColumnName("PostalCode");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.HomePage).HasColumnName("HomePage");
        }
    }
}
