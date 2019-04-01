using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ETicaret.Entities.Models.Mapping
{
    public class MessageReplyMap : EntityTypeConfiguration<MessageReply>
    {
        public MessageReplyMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Text)
                .IsRequired()
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("MessageReplies");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Text).HasColumnName("Text");
            this.Property(t => t.MessageId).HasColumnName("MessageId");
            this.Property(t => t.Member_Id).HasColumnName("Member_Id");
            this.Property(t => t.AddedDate).HasColumnName("AddedDate");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.Member)
                .WithMany(t => t.MessageReplies)
                .HasForeignKey(d => d.Member_Id);
            this.HasRequired(t => t.Message)
                .WithMany(t => t.MessageReplies)
                .HasForeignKey(d => d.MessageId);

        }
    }
}
