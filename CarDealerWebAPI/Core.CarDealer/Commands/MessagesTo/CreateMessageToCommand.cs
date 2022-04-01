using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Commands.MessagesTo
{
    public class CreateMessageToCommand
    {
        public int receiverId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public int SenderId { get; set; }
    }
}
