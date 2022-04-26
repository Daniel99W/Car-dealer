using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Queries.UserCars
{
    public class GetUserFavoriteCarByUserIdQuery : IRequest<IEnumerable<Car>>
    {
        public Guid UserId { get; set; }
    }
}
