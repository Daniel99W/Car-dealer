﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.DTO
{
    public class CarParametersQueryDTO
    {

        public int Page { get; set; } = 1;
        public string? Brand { get; set; }
        public string? CarType { get; set; }
        public string? Title { get; set; }
        public int? ProductionYear { get; set; }

        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public bool? OrderBy { get; set; }
        [Required]
        public int CarsPerPage { get; set; }
    }
}
