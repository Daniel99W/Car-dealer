using System;
using System.Collections.Generic;

#nullable disable

namespace CarDealer.Models
{
    public partial class MessageTo
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? MessageId { get; set; }

        public virtual Message Message { get; set; }
        public virtual User User { get; set; }
    }
}
