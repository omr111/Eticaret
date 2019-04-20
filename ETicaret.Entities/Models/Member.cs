using System;
using System.Collections.Generic;

namespace ETicaret.Entities.Models
{
    public partial class Member
    {
        public Member()
        {
            this.Addresses = new List<Address>();
            this.Comments = new List<Comment>();
            this.Comments1 = new List<Comment>();
            this.MemberPictures = new List<MemberPicture>();
            this.MessageReplies = new List<MessageReply>();
            this.Orders = new List<Order>();
            this.ProductReviews = new List<ProductReview>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Bio { get; set; }
        public System.DateTime AddedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public int MemberType { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Comment> Comments1 { get; set; }
        public virtual ICollection<MemberPicture> MemberPictures { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<MessageReply> MessageReplies { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ProductReview> ProductReviews { get; set; }
    }
}
