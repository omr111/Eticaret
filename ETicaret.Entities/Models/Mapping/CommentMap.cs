using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ETicaret.Entities.Models.Mapping
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Text)
                .IsRequired()
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Comments");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Text).HasColumnName("Text");
            this.Property(t => t.Member_Id).HasColumnName("Member_Id");
            this.Property(t => t.ToWhoId).HasColumnName("ToWhoId");
            this.Property(t => t.Product_Id).HasColumnName("Product_Id");
            this.Property(t => t.AddedDate).HasColumnName("AddedDate");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.Member)
                .WithMany(t => t.Comments)
                .HasForeignKey(d => d.Member_Id);
            this.HasRequired(t => t.Member1)
                .WithMany(t => t.Comments1)
                .HasForeignKey(d => d.ToWhoId);
            this.HasRequired(t => t.Product)
                .WithMany(t => t.Comments)
                .HasForeignKey(d => d.Product_Id);

        }
    }
}
