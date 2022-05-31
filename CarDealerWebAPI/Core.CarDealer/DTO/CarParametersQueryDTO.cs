using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.DTO
{
    public class CarParametersQueryDTO
    {
        [Required]
        public int Page { get; set; } = 1;
        public Guid? BrandId { get; set; }
        public Guid? CarTypeId { get; set; }
        public string? Title { get; set; }
        public int? MinProductionYear { get; set; }
        public int? MaxProductionYear { get; set; }

        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public bool? OrderBy { get; set; }
        
        [Required]
        public int CarsPerPage { get; set; }
    }
}
