using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.DTO
{
    public class GetMessageDTO
    {
        public Guid Id { get; set; }

        public Guid SenderId { get; set; }

        public string? Subject { get; set; }

        public string Content { get; set; }

        public GetUserDTO UserDTO { get; set; }


    }
}
