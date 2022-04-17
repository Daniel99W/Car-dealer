using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.DTO
{
    public class GetMessagesDTO
    {
        [Required]
        public Guid ReceiverId { get; set; }
        [Required]
        public Guid SenderId { get; set; }
    }
}
