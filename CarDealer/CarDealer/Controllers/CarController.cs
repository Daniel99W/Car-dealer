using CarDealer.Models;
using Infrastructure.CarDealer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CarDealer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarController : ControllerBase
    {

        private CarRepository carRepository;
        public CarController(CarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> Get(int id)
        {
            return new ActionResult<Car>(await carRepository.Read(id)); 
        }

        [HttpPost]
        public async void Post(Car car)
        {
            carRepository.Create(car);
        }

        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            Car car = await carRepository.Read(id);
            carRepository.Delete(car);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetAllCars()
        {

            return new ActionResult<IEnumerable<Car>>(await carRepository.GetAllCars());
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<Car>> GetCarByUser(int userId)
        {
            return new ActionResult<Car>(await carRepository.GetCarByUserId(userId));
        }
    }
}
