using AutoMapper;
using Core.CarDealer.Commands;
using Core.CarDealer.Commands.Cars;
using Core.CarDealer.Commands.UserCars;
using Core.CarDealer.Commands.Users;
using Core.CarDealer.DTO;
using Core.CarDealer.Models;
using Core.CarDealer.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Configurations
{
    public static class ConfigureMapper
    {
        public static void Configure(IMapperConfigurationExpression mapperConfigurationExpression)
        {
             mapperConfigurationExpression.CreateMap<CarParametersQueryDTO,GetCarsByFiltersQuery>();
             mapperConfigurationExpression.CreateMap<CreateCarDTO,CreateCarCommand>();
             mapperConfigurationExpression.CreateMap<Car,UpdateCarCommand>();
             mapperConfigurationExpression.CreateMap<CreateUserDTO,CreateUserCommand>();
             mapperConfigurationExpression.CreateMap<CreateUserCommand,User>();
             mapperConfigurationExpression.CreateMap<User,GetUserDTO>();
             mapperConfigurationExpression.CreateMap<CreateCarCommand,Car>();
             mapperConfigurationExpression.CreateMap<CreateUserCarCommand,UserCar>();
             mapperConfigurationExpression.CreateMap<FavoriteDTO,CreateUserCarCommand>();
             mapperConfigurationExpression.CreateMap<Brand,GetBrandDTO>();
             mapperConfigurationExpression.CreateMap<CarType,GetCarTypeDTO>();
             mapperConfigurationExpression.CreateMap<FuelType,FuelTypeDTO>();
             mapperConfigurationExpression.CreateMap<User,UserDTO>();
            mapperConfigurationExpression.CreateMap<UserDTO, UpdateUserCommand>();
            mapperConfigurationExpression.CreateMap<IEnumerable<Message>,IEnumerable<GetMessageDTO>>();
            mapperConfigurationExpression.CreateMap<Message,GetMessageDTO>();
        }


    }
}
