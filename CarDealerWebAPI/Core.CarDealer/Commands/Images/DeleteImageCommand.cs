using MediatR;

namespace Core.CarDealer.Commands.Images
{
    public class DeleteImageCommand : IRequest<Guid>
    {
        public Guid CarId { get; set; }

        public string ImageName { get; set; }
    }
}
