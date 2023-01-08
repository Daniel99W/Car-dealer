using Core.CarDealer.Models;
using MediatR;

namespace Core.CarDealer.Commands.Mesages
{
    public class CreateUnitOfWorkMessagesCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public string Content { get; set; }

        public string Subject { get; set; }

        public Guid ReceiverId { get; set; }
    }
}
