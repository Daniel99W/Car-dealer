using System;
using System.Collections.Generic;

#nullable disable

namespace CarDealer.Models
{
    public partial class Message
    {
        public Message()
        {
            MessageTos = new HashSet<MessageTo>();
        }

        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<MessageTo> MessageTos { get; set; }
    }
}
