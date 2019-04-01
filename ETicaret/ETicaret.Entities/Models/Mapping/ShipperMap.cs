using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ETicaret.Entities.Models.Mapping
{
    public class ShipperMap : EntityTypeConfiguration<Shipper>
    {
        public ShipperMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.CompanyName)
                .HasMaxLength(50);

            this.Property(t => t.phone)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Shippers");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.CompanyName).HasColumnName("CompanyName");
            this.Property(t => t.phone).HasColumnName("phone");
        }
    }
}
