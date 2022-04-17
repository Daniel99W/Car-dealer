using System;
using System.Collections.Generic;

namespace Core.CarDealer.Models
{
    public partial class MessageTo
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? MessageId { get; set; }

        public virtual Message? Message { get; set; }
        public virtual User? User { get; set; }
    }
}
