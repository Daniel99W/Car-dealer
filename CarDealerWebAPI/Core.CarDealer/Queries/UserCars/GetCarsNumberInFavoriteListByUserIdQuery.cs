using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Queries.UserCars
{
    public class GetCarsNumberInFavoriteListByUserIdQuery : IRequest<int>
    {
        public Guid UserId { get; set; }
    }
}
