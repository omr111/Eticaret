using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ETicaret.Entities.Models.Mapping
{
    public class MemberMap : EntityTypeConfiguration<Member>
    {
        public MemberMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(25);

            this.Property(t => t.Surname)
                .HasMaxLength(25);

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.Bio)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("Members");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Surname).HasColumnName("Surname");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Bio).HasColumnName("Bio");
            this.Property(t => t.AddedDate).HasColumnName("AddedDate");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.MemberType).HasColumnName("MemberType");

            // Relationships
            this.HasRequired(t => t.Role)
                .WithMany(t => t.Members)
                .HasForeignKey(d => d.MemberType);

        }
    }
}
