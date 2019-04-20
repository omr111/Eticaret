using System;
using System.Collections.Generic;

namespace ETicaret.Entities.Models
{
    public partial class MessageReply
    {
        public System.Guid Id { get; set; }
        public string Text { get; set; }
        public System.Guid MessageId { get; set; }
        public int Member_Id { get; set; }
        public System.DateTime AddedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual Member Member { get; set; }
        public virtual Message Message { get; set; }
    }
}
