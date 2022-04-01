using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.DTO
{
    public class PaginatedDTO<T>
    {
        public int? NextPage { get; set; }
        public int? PrevPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<T> Items { get; set; }

     
    }

}
