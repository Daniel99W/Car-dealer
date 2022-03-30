using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.DTO
{
    public class MessageDTO
    {
        public int senderId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public int receiverId { get; set; }
    }
}
