﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.DTO
{
    public class CreateCarDTO
    {

        public string Title { get; set; }

        public string CarNumber { get; set; }
        public int? ProductionYear { get; set; }
        public int Price { get; set; }
        public bool? SecondHand { get; set; }
        public DateTime AddingDate { get; set; }
        public Guid? UserId { get; set; }
        public Guid? FuelType { get; set; }
        public string Description { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int CilindricCapacity { get; set; }
        public Guid? BrandId { get; set; }
        public Guid? CarTypeId { get; set; }
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
