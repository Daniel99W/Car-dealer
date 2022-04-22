using Core.CarDealer.Commands.Cars;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using MediatR;

namespace Core.CarDealer.CommandsHandler.Cars
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, Car>
    {
        private IRepositoryCar _repositoryCar;
        public UpdateCarCommandHandler(IRepositoryCar repositoryCar)
        {
            _repositoryCar = repositoryCar;
        }
        public async Task<Car> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            Car? car = _repositoryCar.Update(new Car()
            {
                Id = request.Id,
                CarNumber = request.CarNumber,
                ProductionYear = request.ProductionYear,
                Title = request.Title,
                Price = request.Price,
                SecondHand = request.SecondHand,
                AddingDate = request.AddingDate,
                UserId = request.UserId,
                FuelType = request.FuelType,
                Description = request.Description,
                Model = request.Model,
                CilindricCapacity = request.CilindricCapacity,
                BrandId = request.BrandId,
                CarTypeId = request.CarTypeId
            });

            await _repositoryCar.SaveChangesAsync();
            return await Task.FromResult(car);
        }
    }
}
