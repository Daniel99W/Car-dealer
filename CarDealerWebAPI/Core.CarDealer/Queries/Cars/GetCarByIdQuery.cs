﻿using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Queries
{
    public class GetCarByIdQuery : IRequest<Car>
    {
        public int Id { get; set; }
    }
}