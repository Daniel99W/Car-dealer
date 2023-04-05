using AutoMapper;
using Core.CarDealer.Commands;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using MediatR;

namespace Core.CarDealer.CommandsHandler.Cars
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand,Car>
    {
        private IRepositoryCar _carRepository;
        private ICloudStorageService _cloudStorageService;
        private IMapper _mapper;

        public CreateCarCommandHandler(
            IRepositoryCar carRepository,
            ICloudStorageService cloudStorageService,
            IMapper mapper)

        {
            _carRepository = carRepository;
            _cloudStorageService = cloudStorageService;
            _mapper = mapper;
        }
        

        public async Task<Car> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            Car car = _carRepository.Create(_mapper.Map<Car>(request));
            await _carRepository.SaveChangesAsync();
            return await Task.FromResult(car);
        }

    }
}
