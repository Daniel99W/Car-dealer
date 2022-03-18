using System;
using System.Collections.Generic;

namespace Core.CarDealer.Models
{
    public partial class Message
    {
        public Message()
        {
            MessageTos = new HashSet<MessageTo>();
        }

        public int Id { get; set; }
        public string Subject { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int? UserId { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<MessageTo> MessageTos { get; set; }
    }
}
