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
        private IServiceBlob _blobService;
        private IMapper _mapper;

        public CreateCarCommandHandler(
            IRepositoryCar carRepository,
            IServiceBlob blobService,
            IMapper mapper)

        {
            _carRepository = carRepository;
            _blobService = blobService;
            _mapper = mapper;
        }
        

        public async Task<Car> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            Car car = _carRepository.Create(_mapper.Map<Car>(request));
            Console.WriteLine(car.CarNumber);
            await _carRepository.SaveChangesAsync();

            return await Task.FromResult(car);
        }

    }
}
