using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMediatR
{
    public class Mediator : IMediator
    {

        public Dictionary<IRequest<object>,IHandler<IRequest<object>,object>> HandlersRequests {  get; private set; }

        public Mediator()
        {
            HandlersRequests = new Dictionary<IRequest<object>, >();
        }

        public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            var reqType = request.GetType();

            if(!HandlersRequests.ContainsKey(reqType))
            {
                throw new Exception("No handler found!");
            }

            HandlersRequests.TryGetValue(reqType, out var requestHandler);

            return await Task.FromResult(requestHandler);
        }
    }
}
