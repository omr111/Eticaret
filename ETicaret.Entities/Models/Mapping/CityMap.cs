using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ETicaret.Entities.Models.Mapping
{
    public class CityMap : EntityTypeConfiguration<City>
    {
        public CityMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CityName, t.RegionID });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.CityName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.RegionID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Cities");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.CityName).HasColumnName("CityName");
            this.Property(t => t.RegionID).HasColumnName("RegionID");

            // Relationships
            this.HasRequired(t => t.Region)
                .WithMany(t => t.Cities)
                .HasForeignKey(d => d.RegionID);
            this.HasRequired(t => t.Supplier)
                .WithMany(t => t.Cities)
                .HasForeignKey(d => d.id);

        }
    }
}
