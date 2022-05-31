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

        public Guid Id { get; set; }
        public string Content { get; set; } = null!;
        public Guid? UserId { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<MessageTo> MessageTos { get; set; }
    }
}
