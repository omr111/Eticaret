using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ETicaret.Entities.Models.Mapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Address)
                .IsRequired()
                .HasMaxLength(750);

            this.Property(t => t.Status)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.Description)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Orders");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Member_Id).HasColumnName("Member_Id");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.AddedDate).HasColumnName("AddedDate");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.ShipVia).HasColumnName("ShipVia");

            // Relationships
            this.HasRequired(t => t.Member)
                .WithMany(t => t.Orders)
                .HasForeignKey(d => d.Member_Id);
            this.HasOptional(t => t.Shipper)
                .WithMany(t => t.Orders)
                .HasForeignKey(d => d.ShipVia);

        }
    }
}
