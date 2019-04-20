using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ETicaret.Entities.Models.Mapping
{
    public class RegionMap : EntityTypeConfiguration<Region>
    {
        public RegionMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.RegionName)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Region");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.RegionName).HasColumnName("RegionName");
        }
    }
}
