using Core.CarDealer.DTO;
using Core.CarDealer.Models;
using System.IdentityModel.Tokens.Jwt;

namespace Core.CarDealer.Interfaces
{
    public interface IServiceAuth
    {
        public Task SignUpUser(User user,Guid roleId);
        public bool CheckPassword(LoginDTO loginDTO, User existingUser);
        public Task<JwtSecurityToken> GetJwt(User user);

        public Task<User> AddRol(User user);
    }
}
