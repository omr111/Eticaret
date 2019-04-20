using System;
using System.Collections.Generic;

namespace ETicaret.Entities.Models
{
    public partial class Message
    {
        public Message()
        {
            this.MessageReplies = new List<MessageReply>();
        }

        public System.Guid Id { get; set; }
        public string Subject { get; set; }
        public bool IsRead { get; set; }
        public System.DateTime AddedDate { get; set; }
        public string ModifiedDate { get; set; }
        public virtual ICollection<MessageReply> MessageReplies { get; set; }
    }
}
