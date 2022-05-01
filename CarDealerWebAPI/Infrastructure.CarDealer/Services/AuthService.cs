using Core.CarDealer.Constants;
using Core.CarDealer.DTO;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace Infrastructure.CarDealer.Services
{
    public class AuthService : IServiceAuth
    {
        private IRepositoryUser _userRepository;
        private IRepositoryRole _repositoryRole;
        private IConfiguration _configuration;

        public AuthService(
            IRepositoryUser userRepository,
            IConfiguration configuration,
            IRepositoryRole repositoryRole)
            
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _repositoryRole = repositoryRole;
           
        }   

        public async Task<User> AddRol(User user)
        {
            user.Role = await _repositoryRole.Read((Guid)user.RoleId);
            return user;
        }

        public bool CheckPassword(LoginDTO loginDTO, User existingUser)
        {
            if (BC.Verify(loginDTO.Password, existingUser.Password))
                return true;
            return false;
        }

        public async Task<JwtSecurityToken> GetJwt(User user)
        {
            SymmetricSecurityKey authSignKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            DateTime dateTime = DateTime.Now.AddHours(1);

            user = await AddRol(user);

            List<Claim> authClaims = new()
            {
                new Claim(UserClaimTypes.UserId.ToString(), user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.Name.ToString())
            };

            return new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: dateTime,
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSignKey, SecurityAlgorithms.HmacSha256)
                );
        }

        public async Task SignUpUser(User user,Guid roleId)
        {
            user.Password = BC.HashPassword(user.Password);
            user.RoleId = roleId;
            _userRepository.Create(user);
            await _userRepository.SaveChangesAsync();
        }
    }
}
