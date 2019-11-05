using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ETicaret.Entities.Models.Mapping
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.AdresDescription)
                .IsRequired()
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("Addresses");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AdresDescription).HasColumnName("AdresDescription");
            this.Property(t => t.Member_Id).HasColumnName("Member_Id");
            this.Property(t => t.AddedDate).HasColumnName("AddedDate");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.Member)
                .WithMany(t => t.Addresses)
                .HasForeignKey(d => d.Member_Id);

        }
    }
}
