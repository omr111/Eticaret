using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ETicaret.Entities.Models.Mapping
{
    public class MemberPictureMap : EntityTypeConfiguration<MemberPicture>
    {
        public MemberPictureMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.PicturePath)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("MemberPictures");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.MemberID).HasColumnName("MemberID");
            this.Property(t => t.PicturePath).HasColumnName("PicturePath");

            // Relationships
            this.HasRequired(t => t.Member)
                .WithMany(t => t.MemberPictures)
                .HasForeignKey(d => d.MemberID);

        }
    }
}
