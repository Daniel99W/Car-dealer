﻿using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Queries.Brands
{
    public class GetBrandQuery : IRequest<Brand>
    {
        public Guid Id { get; set; }
    }
}