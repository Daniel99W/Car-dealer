using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using Core.CarDealer.Queries;
using Core.CarDealer.Queries.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.QueriesHandler.Users
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        IRepositoryUser _repositoryUser;
        public GetUserByIdQueryHandler(IRepositoryUser repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }
        public async Task<User>? Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repositoryUser.Read(request.Id);
        }
    }
}
