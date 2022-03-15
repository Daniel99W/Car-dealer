using CarDealer.Models;
using Core.CarDealer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private UserRepository userRepository;

        public UserController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await userRepository.Read(id);
        }

        [HttpPost]
        public void Post(User user)
        {
            userRepository.Create(user);
        }

        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            User user = await userRepository.Read(id);
            userRepository.Delete(user);
        }
    }
}
